using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCtrl : MonoBehaviour
{
    Ray ray; // 광선
    RaycastHit hit; // 충돌 정보 충돌 위치,거리,방향
    float rotSpeed = 5000f; // 포탑의 회전 속도
    Transform tr; // 포탑의 Transform 컴포넌트
    float maxDistance = 100f; // 광선이 닿을 최대 거리

    void Start()
    {
        tr = transform; // 포탑의 Transform 컴포넌트를 가져옴

    }

    
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 위치에서 광선을 쏜다
             // 광선이 마우스 포인트 방향으로 발사 됨
        Debug.DrawRay(ray.origin, ray.direction * 100f,Color.green); // 광선 시각화
        if(Physics.Raycast(ray, out hit, maxDistance, 1<<6)) // 광선이 60 근방에서 터레인에 맞았다면
        {
            Vector3 relative = tr.InverseTransformPoint(hit.point); // 포탑의 로컬 좌표계로 변환
            // InverseTransformPoint - 광선이 맞은 지점인 월드 좌표를 로컬 좌표로 변환   // 라디안-> 일반 각도로 변경
            float angle = Mathf.Atan2(relative.x,relative.z) * Mathf.Rad2Deg; // 상대 좌표를 이용해 각도 계산
            // 결과값 = 역탄젠트(로컬지점.x, 로컬지점.z) * PI*2/360
            tr.Rotate(0f, angle * Time.deltaTime * 5f, 0f); // 포탑을 회전시킨다

        }


    }
}
