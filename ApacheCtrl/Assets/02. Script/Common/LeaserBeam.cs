using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaserBeam : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    Transform tr;


    void Start()
    {
        tr =GetComponent<Transform>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false; // 월드 좌표계를 사용하지 않도록 설정
        lineRenderer.enabled = false; // LineRenderer를 비활성화하여 시작 시 보이지 않도록 설정

    }
    public void FireRay() //public 이니까 밖에서 호출 가능 
    {
                       // 위치  , 방향  / 어느 위치에서 어디 방향으로 가는지 
        Ray ray = new Ray(tr.position + (Vector3.up * 0.02f), tr.forward); // 현재 오브젝트의 위치와 방향을 기준으로 Ray 생성
        RaycastHit hit;
        // 라인렌더러 첫번째 점을 레이 시작점으로 설정 /ray.origin - Ray의 시작점
        lineRenderer.SetPosition(0,tr.InverseTransformPoint(ray.origin)); // Ray의 시작점을 LineRenderer의 첫 번째 위치로 설정
                                    // 월드 좌표를 로컬 좌표로 변환
        if (Physics.Raycast(ray, out hit, 200f, 1<<6)) // 레이캐스트를 사용하여 충돌을 감지
        {     // 200 유닛 범위 안에서 터레인에 광선이 맞았다면
            lineRenderer.SetPosition(1,tr.InverseTransformPoint(hit.point)); // Ray가 충돌한 지점을 LineRenderer의 두 번째 위치로 설정
            // 끝점은 맞은 위치로 잡고
        }
        else // 맞지 않고 계속 날아 가는 경우에는
        {
            lineRenderer.SetPosition(1,tr.InverseTransformPoint(ray.GetPoint(200f))); // Ray의 끝점을 200 유닛 떨어진 지점으로 설정
            // 맞지 않은 경우에는 끝점을 대략 200유닛으로 설정
        }
        // 레이저 빔을 보여주기 위해 ShowLeaserBeam 코루틴을 시작
        StartCoroutine(ShowLeaserBeam()); // ShowLeaserBeam 코루틴을 시작하여 LineRenderer를 활성화
    }
    IEnumerator ShowLeaserBeam()
    {
        lineRenderer.enabled = true; // LineRenderer를 활성화하여 레이저 빔을 표시
        yield return new WaitForSeconds(Random.Range(0.1f,0.3f)); // 0.1초에서 0.3초 사이의 랜덤 시간 동안 대기
        lineRenderer.enabled = false; // 일정 시간이 지난 후 LineRenderer를 비활성화하여 레이저 빔을 숨김
    }


}
