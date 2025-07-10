using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPonit : MonoBehaviour
{
    public Color lineColor = Color.black; // ��� ����Ʈ�� �� ����
    [SerializeField] public List<Transform> PatrolList; // ���� ��� ����Ʈ��
    [SerializeField] float radius = 2f; // ��� ����Ʈ�� ������

    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor; // Gizmos�� ������ ����
        PatrolList = new List<Transform>(); // ��� ����Ʈ ����Ʈ �ʱ�ȭ
        Transform[] pTransform = GetComponentsInChildren<Transform>(); // �ڽ� ������Ʈ�� Transform ������Ʈ�� ������
        for (int i = 0; i < pTransform.Length; i++)
        {
            if (pTransform[i] != this.transform) // �ڱ� �ڽ��� ����
            {
                PatrolList.Add(pTransform[i]); // ��� ����Ʈ ����Ʈ�� �߰�
            }
        }
        for(int i = 0; i < PatrolList.Count; i++)
        {
            Vector3 currentPos = PatrolList[i].position; // ���� ��� ����Ʈ ��ġ
            Vector3 prevPos = Vector3.zero; // ���� ��� ����Ʈ ��ġ
            if (i > 0)
                prevPos =PatrolList[i - 1].position; // ���� ��� ����Ʈ ��ġ ����
            else if (i == 0 && PatrolList.Count > 1)
                prevPos = PatrolList[PatrolList.Count - 1].position; // ù ��° ��� ����Ʈ�� ���� ��ġ ����
            Gizmos.DrawLine(prevPos, currentPos); // ���� ��� ����Ʈ�� ���� ��� ����Ʈ�� �����ϴ� ���� �׸�
            Gizmos.DrawWireSphere(currentPos, radius); // ���� ��� ����Ʈ ��ġ�� �������� ���� ��ü�� �׸�
        }
    }

}
