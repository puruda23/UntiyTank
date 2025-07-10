using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmos : MonoBehaviour
{
    public Color _color = Color.red; // Gizmos의 색상을 설정할 수 있는 public 변수
    public float _radius = 0.1f; // Gizmos의 반지름을 설정할 수 있는 public 변수
    public void OnDrawGizmos()
    {
        Gizmos.color = _color; // Gizmos의 색상을 설정 
        Gizmos.DrawSphere(transform.position, _radius);
        // 현재 오브젝트의 위치에 반지름이 _radius인 구체를 그립니다.
    }
}
