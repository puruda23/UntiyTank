using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheCtrl : MonoBehaviour
{
    public float moveSpeed = 0f; // Apache�� �̵� �ӵ�
    public float rotSpeed = 0f; // Apache�� ȸ�� �ӵ�
    Transform tr; // Apache�� Transform ������Ʈ
    private float VerticalSpeed = 0f; // ���� �̵� �ӵ�
    Rigidbody rb; // Apache�� Rigidbody ������Ʈ
    //[Header("Apache Limit")]
    //public float UpperAngle = -30f; // Apache�� ���� ȸ���� �� �ִ� �ִ� ����
    //public float downAngle = 0f; // Apache�� �Ʒ��� ȸ���� �� �ִ� �ִ� ����
    //public float currentRotate = 0f; // ���� Apache�� ȸ�� ����
    [SerializeField] private ApacheInput input; // ApacheInput ��ũ��Ʈ�� �ν��Ͻ�

    void Start()
    {
        tr = GetComponent<Transform>(); // Apache�� Transform ������Ʈ�� ������
        rb = GetComponent<Rigidbody>(); // Apache�� Rigidbody ������Ʈ�� ������
        input = GetComponent<ApacheInput>(); // ApacheInput ��ũ��Ʈ�� �ν��Ͻ��� ������
    }

    
    void FixedUpdate() // Ű���带 ������ �� ��ŭ �̵��ϱ� ���� ����
    {
        #region �¿�� ȸ�� �ϴ� ���� A,D
        if (Input.GetKey(KeyCode.A)) // A Ű�� ������ ���̸�
            rotSpeed += -0.05f; // �������� ȸ�� �ӵ��� ������Ŵ
        else if (Input.GetKey(KeyCode.D))
            rotSpeed += 0.05f; // D Ű�� ������ ���̸� ���������� ȸ�� �ӵ��� ������Ŵ
        else // ������ �ʾ��� �� 
        {
            if (rotSpeed > 0f) rotSpeed += -0.1f; // ������ ȸ���ϴٰ� �����
            else if (rotSpeed < 0f) rotSpeed += 0.1f; 
        }
        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime); // Y���� �������� ȸ��
        #endregion
        #region �յڷ� �̵� �ϴ� ���� W,S
        if (Input.GetKey(KeyCode.W)) // W Ű�� ������ ���̸�
            moveSpeed += 0.05f; // ������ �̵� �ӵ��� ������Ŵ
        else if (Input.GetKey(KeyCode.S)) // S Ű�� ������ ���̸�
            moveSpeed += -0.05f; // �ڷ� �̵� �ӵ��� ������Ŵ
        else // ������ �ʾ��� �� 
        {
            if (moveSpeed > 0f) moveSpeed += -0.1f; // ������ �̵��ϴٰ� �����
            else if (moveSpeed < 0f) moveSpeed += 0.1f;
        }
        tr.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self); // Z���� �������� �̵�
        #endregion
        #region ����(����) �̵� ���� Space��, LeftShift��
        if(Input.GetKey(KeyCode.Space)) // Space Ű�� ������ ���̸�
            VerticalSpeed += 0.03f; // ���� �̵� �ӵ��� ������Ŵ
        else if (Input.GetKey(KeyCode.LeftShift)) // LeftShift Ű�� ������ ���̸�
            VerticalSpeed += -0.03f; // �Ʒ��� �̵� �ӵ��� ������Ŵ
        else // ������ �ʾ��� �� 
        {
            if (VerticalSpeed > 0f) VerticalSpeed += -0.03f; // ������ �̵��ϴٰ� �����
            else if (VerticalSpeed < 0f) VerticalSpeed += 0.03f;
        }
        tr.Translate(Vector3.up * VerticalSpeed * Time.deltaTime, Space.Self); // Y���� �������� �̵�
        #endregion
        #region ��ü�� ���Ʒ� ȸ��
        //float wheel = enemyAI.m_scrollWheel; // ���콺 �� ��ũ�� �Է� ��
        //float angle = Time.deltaTime * rotSpeed * wheel; // ȸ�� ���� ���
        //if (wheel <= 0.01f) // ��ü�� �ø��� (���콺 ���� ���� ������)
        //{
        //    currentRotate += angle; // ���� ȸ�� ���� ������Ʈ
        //    if (currentRotate > UpperAngle) // ��ü�� ���� ȸ���� �� �ִ� �ִ� ������ �ʰ��ϸ�
        //    {
        //        tr.Rotate(angle, 0f, 0f); // ��ü�� �ִ� ������ ȸ�� / �ø���
        //    }
        //    else
        //    {
        //        currentRotate = UpperAngle; // ���� ȸ�� ������ �ִ� ������ ���� / �����Ѵ�
        //    }
        //}
        //else // ��ü�� ������ (���콺 ���� �Ʒ��� ������)
        //{
        //    currentRotate += angle; // ���� ȸ�� ���� ������Ʈ
        //    if (currentRotate < downAngle) // ��ü�� ���� ȸ���� �� �ִ� �ִ� ������ �ʰ��ϸ�
        //    {
        //        tr.Rotate(angle, 0f, 0f); // ��ü�� �ִ� ������ ȸ�� / ������
        //    }
        //    else
        //    {
        //        currentRotate = downAngle; // ���� ȸ�� ������ �ִ� ������ ���� / �����Ѵ�
        //    }
        //}
        #endregion

    }
}
