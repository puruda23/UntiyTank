using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmos : MonoBehaviour
{
    public Color _color = Color.red; // Gizmos�� ������ ������ �� �ִ� public ����
    public float _radius = 0.1f; // Gizmos�� �������� ������ �� �ִ� public ����
    public void OnDrawGizmos()
    {
        Gizmos.color = _color; // Gizmos�� ������ ���� 
        Gizmos.DrawSphere(transform.position, _radius);
        // ���� ������Ʈ�� ��ġ�� �������� _radius�� ��ü�� �׸��ϴ�.
    }
}
