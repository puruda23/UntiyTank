using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missilefire : MonoBehaviour
{
    public Transform FirePos; // 발사 위치
    public Transform FirePos_1; // 두 번째 발사 위치
    private ApacheInput input; // ApacheInput 스크립트 참조
    [SerializeField] private LeaserBeam beam; // 레이저 빔 스크립트 참조
    [SerializeField] private LeaserBeam beam_1; // 두 번째 레이저 빔 스크립트 참조
    public GameObject expEffect; // 폭발 이펙트 프리팹
    private AudioSource source; // 사운드 소스
    [SerializeField] private AudioClip fireClip; // 발사 사운드 클립
    [SerializeField] private AudioClip expClip; // 폭발 사운드 클립
    Ray ray; // 레이저 발사용 Ray
    [SerializeField] int TerrainLayer; // 지형 레이어
    public bool isHit = false; // 레이저가 충돌했는지 여부
    Vector3 hitPoint;
    Vector3 _normal;
    Quaternion rot;
    GameObject eff; // 폭발 이펙트 인스턴스

    void Start()
    {
        source = GetComponent<AudioSource>(); // AudioSource 컴포넌트 가져오기
        input = GetComponent<ApacheInput>();
        FirePos = transform.GetChild(3).transform; // 발사 위치를 자식 오브젝트에서 찾기
        FirePos_1 = transform.GetChild(4).transform; // 두 번째 발사 위치를 자식 오브젝트에서 찾기
        beam = FirePos.GetComponentInChildren<LeaserBeam>(); // 발사 위치에서 LeaserBeam 컴포넌트 찾기
        beam_1 = FirePos_1.GetComponentInChildren<LeaserBeam>(); // 두 번째 발사 위치에서 LeaserBeam 컴포넌트 찾기
        expEffect = Resources.Load<GameObject>("Effects/BigExplosionEffect"); // 폭발 이펙트 프리팹 로드
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
        ray = new Ray(FirePos_1.position, FirePos_1.forward); // 두 번째 발사 위치와 방향으로 Ray 생성
        if (Physics.Raycast(ray, out hit, 200f, 1<< TerrainLayer))
        {
            isHit = true; // 레이저가 지형에 충돌했음을 표시
            beam.FireRay(); // 레이저 빔 발사 / 라인 렌더러 효과를 표시할려고
            beam_1.FireRay(); // 두 번째 레이저 빔 발사
            ShowEffect(hit);
        }
    }
    void ShowEffect(RaycastHit hit)
    {
        if(isHit)
        {
            hitPoint = hit.point; // 충돌 지점
            _normal = hit.normal; // 충돌 표면의 법선 벡터
            rot = Quaternion.FromToRotation(Vector3.up, _normal); // 법선 벡터를 기준으로 회전
            eff = Instantiate(expEffect, hitPoint, rot); // 폭발 이펙트 인스턴스 생성
            Destroy(eff, 1.5f); // 1.5초 후에 폭발 이펙트 삭제
            source.PlayOneShot(expClip, 1.0f); // 폭발 사운드 재생
        }
        else
        {
            hitPoint = ray.GetPoint(200f); // 레이저가 충돌하지 않은 경우, 200 단위 거리의 점을 가져옴
            _normal = -ray.direction; // 레이저 방향의 반대 벡터를 법선으로 사용
            rot = Quaternion.FromToRotation(Vector3.up, _normal); // 법선 벡터를 기준으로 회전
            eff = Instantiate(expEffect, hitPoint, rot); // 폭발 이펙트 인스턴스 생성
            Destroy(eff, 1.5f); // 1.5초 후에 폭발 이펙트 삭제
            source.PlayOneShot(expClip, 1.0f); // 폭발 사운드 재생
        }
        
    }
}
