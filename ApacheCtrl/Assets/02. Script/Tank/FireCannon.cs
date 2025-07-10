using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public Transform FirePos; // 발사 위치
    private TankInput input; // TankInput 스크립트 참조
    [SerializeField] 
    private LeaserBeam beam; // 레이저 빔 스크립트 참조
    public GameObject expEffect; // 폭발 이펙트 프리팹
    private AudioSource source; // 사운드 소스
    [SerializeField] private AudioClip fireClip; // 발사 사운드 클립
    [SerializeField] private AudioClip expClip; // 폭발 사운드 클립
    Ray ray; // 레이저 발사용 Ray
    [SerializeField]
    int TerrainLayer; // 지형 레이어
    public bool isHit = false; // 레이저가 충돌했는지 여부
    Vector3 hitPoint;
    Vector3 _normal;
    Quaternion rot;
    GameObject eff; // 폭발 이펙트 인스턴스

    void Start()
    {
        source = GetComponent<AudioSource>(); // AudioSource 컴포넌트 가져오기
        input = GetComponent<TankInput>();
        FirePos = transform.GetChild(4).GetChild(1).GetChild(1).transform; // 발사 위치를 자식 오브젝트에서 찾기
        beam = FirePos.GetComponentInChildren<LeaserBeam>(); // 발사 위치에서 LeaserBeam 컴포넌트 찾기
        expEffect = Resources.Load<GameObject>("Effects/BigExplosionEffect"); // 폭발 이펙트 프리팹 로드
        // Resources 폴더 안에 Effects 폴더 안 BigExplosionEffect 를 가져온다
        fireClip = Resources.Load<AudioClip>("Sounds/ShootMissile");
        expClip = Resources.Load<AudioClip>("Sounds/DestroyedExplosion");
        TerrainLayer = LayerMask.NameToLayer("TERRAIN"); // 지형 레이어 이름을 가져오기

    }


    void Update()
    {
        if (input.isFire)
        {
            Fire();
        }

    }
    void Fire()
    {
        source.PlayOneShot(fireClip, 1.0f); // 발사 사운드 재생
        RaycastHit hit; // 레이저 충돌 정보를 저장할 변수
        ray = new Ray(FirePos.position, FirePos.forward); // 발사 위치와 방향으로 Ray 생성
        if (Physics.Raycast(ray, out hit, 200f, 1<<TerrainLayer))
        {
            isHit = true; // 레이저가 지형에 충돌했음을 표시
            beam.FireRay(); // 레이저 빔 발사 / 라인 렌더러 효과를 표시할려고
            ShowEffect(hit);
        }
        else // 맞지 않았다면
        {
            isHit = false; // 레이저가 지형에 충돌하지 않았음을 표시
            beam.FireRay(); // 레이저 빔 발사 / 라인 렌더러 효과를 표시할려고
            ShowEffect(hit); // 충돌하지 않은 경우에도 폭발 이펙트 표시
        }
    }
    void ShowEffect(RaycastHit hit)
    {
        if (isHit)
        {
            hitPoint = hit.point; // 충돌 지점  // Vector3 hitPoint 를 써도 지역 변수로서 사용은 가능함
            _normal = (FirePos.position - hitPoint).normalized; // 타겟 위치에서 맞은 방향으로의 벡터 법선 벡터
            // 발사 방향으로 파티클이 보인다
            rot = Quaternion.FromToRotation(-Vector3.forward, _normal); // -Z 방향에서 충돌 지점의 법선 방향으로 회전
            // - 인 이유는 파티클이 뒤로 튀는데 잘보이게 돌려주려고 붙인다
            eff = Instantiate(expEffect, hitPoint, rot); // 폭발 이펙트 생성
            Destroy(eff, 1.5f); // 1.5초 후에 폭발 이펙트 삭제
            source.PlayOneShot(expClip, 1.0f); // 폭발 사운드 재생
        }
        else
        {
            // 맞지 않은 경우에는 200 유닛 떨어진 지점에서 자동 폭파
            hitPoint = ray.GetPoint(200f); 
            _normal = (FirePos.position - hitPoint).normalized; 
            rot = Quaternion.FromToRotation(-Vector3.forward, _normal); 
            eff = Instantiate(expEffect, hitPoint, rot); 
            Destroy(eff, 1.5f); 
            source.PlayOneShot(expClip, 1.0f); 
        }
    }
}
