using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPonit : MonoBehaviour
{
    public Color lineColor = Color.black; // 경로 포인트의 선 색상
    [SerializeField] public List<Transform> PatrolList; // 다음 경로 포인트들
    [SerializeField] float radius = 2f; // 경로 포인트의 반지름

    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor; // Gizmos의 색상을 설정
        PatrolList = new List<Transform>(); // 경로 포인트 리스트 초기화
        Transform[] pTransform = GetComponentsInChildren<Transform>(); // 자식 오브젝트의 Transform 컴포넌트를 가져옴
        for (int i = 0; i < pTransform.Length; i++)
        {
            if (pTransform[i] != this.transform) // 자기 자신을 제외
            {
                PatrolList.Add(pTransform[i]); // 경로 포인트 리스트에 추가
            }
        }
        for(int i = 0; i < PatrolList.Count; i++)
        {
            Vector3 currentPos = PatrolList[i].position; // 현재 경로 포인트 위치
            Vector3 prevPos = Vector3.zero; // 이전 경로 포인트 위치
            if (i > 0)
                prevPos =PatrolList[i - 1].position; // 이전 경로 포인트 위치 설정
            else if (i == 0 && PatrolList.Count > 1)
                prevPos = PatrolList[PatrolList.Count - 1].position; // 첫 번째 경로 포인트의 이전 위치 설정
            Gizmos.DrawLine(prevPos, currentPos); // 이전 경로 포인트와 현재 경로 포인트를 연결하는 선을 그림
            Gizmos.DrawWireSphere(currentPos, radius); // 현재 경로 포인트 위치에 반지름을 가진 구체를 그림
        }
    }

}
