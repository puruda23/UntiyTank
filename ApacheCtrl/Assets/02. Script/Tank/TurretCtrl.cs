using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCtrl : MonoBehaviour
{
    Ray ray; // ����
    RaycastHit hit; // �浹 ���� �浹 ��ġ,�Ÿ�,����
    float rotSpeed = 5000f; // ��ž�� ȸ�� �ӵ�
    Transform tr; // ��ž�� Transform ������Ʈ
    float maxDistance = 100f; // ������ ���� �ִ� �Ÿ�

    void Start()
    {
        tr = transform; // ��ž�� Transform ������Ʈ�� ������

    }

    
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ���콺 ��ġ���� ������ ���
             // ������ ���콺 ����Ʈ �������� �߻� ��
        Debug.DrawRay(ray.origin, ray.direction * 100f,Color.green); // ���� �ð�ȭ
        if(Physics.Raycast(ray, out hit, maxDistance, 1<<6)) // ������ 60 �ٹ濡�� �ͷ��ο� �¾Ҵٸ�
        {
            Vector3 relative = tr.InverseTransformPoint(hit.point); // ��ž�� ���� ��ǥ��� ��ȯ
            // InverseTransformPoint - ������ ���� ������ ���� ��ǥ�� ���� ��ǥ�� ��ȯ   // ����-> �Ϲ� ������ ����
            float angle = Mathf.Atan2(relative.x,relative.z) * Mathf.Rad2Deg; // ��� ��ǥ�� �̿��� ���� ���
            // ����� = ��ź��Ʈ(��������.x, ��������.z) * PI*2/360
            tr.Rotate(0f, angle * Time.deltaTime * 5f, 0f); // ��ž�� ȸ����Ų��

        }


    }
}
