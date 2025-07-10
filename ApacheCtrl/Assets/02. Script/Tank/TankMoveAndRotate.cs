using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveAndRotate : MonoBehaviour
{
    public float moveSpeed = 0f; // Tank�� �̵� �ӵ�
    public float rotSpeed = 0f; // Tank�� ȸ�� �ӵ�

    Transform tr; // Tank�� Transform ������Ʈ
    Rigidbody rb; // Tank�� Rigidbody ������Ʈ
    TankInput input; // TankInput ��ũ��Ʈ�� �ν��Ͻ�

    //private float HorizontalSpeed = 0f; // ���� �̵� �ӵ�

    void Start()
    {
        tr = GetComponent<Transform>(); // Tank�� Transform ������Ʈ�� ������
        rb = GetComponent<Rigidbody>(); // Tank�� Rigidbody ������Ʈ�� ������
        input = GetComponent<TankInput>(); // TankInput ��ũ��Ʈ�� �ν��Ͻ��� ������
        rb.centerOfMass = new Vector3(0f,-0.5f,0f); // Rigidbody�� ���� �߽����� ����

    }

    
    void Update() // ������ ���� �ؾ���
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
        {
            moveSpeed = 0f; // ���� ���� ���¿����� �̵� �ӵ��� 0���� ����
            rotSpeed = 0f; // ȸ�� �ӵ��� 0���� ����
            return; // Update �޼��� ����
        }
        // �̵� �ӵ��� ȸ�� �ӵ��� �Է¿� ���� ����
        moveSpeed = input.v * 5f; // w,s �Է¿� ���� �̵� �ӵ� ����
        rotSpeed = input.h * 5f; // a,d �Է¿� ���� ȸ�� �ӵ� ����
        // Tank�� �̵� �� ȸ��
       // rb.velocity = tr.forward * moveSpeed; // Tank�� ���� �������� �̵� �ӵ� ����
        // rb.velocity = tr.right * HorizontalSpeed; // ���� �̵� �ӵ� ���� (���� ������� ����)
        // rb.angularVelocity = tr.up * rotSpeed; // Tank�� ȸ�� �ӵ� ���� (���� ������� ����)
        // Transform�� �̿��� ȸ��
        tr.Translate(moveSpeed * Vector3.forward * Time.deltaTime, Space.Self); // Z���� �������� �̵�
        // Space.Self - ���� ������Ʈ�� ���� ��ǥ�踦 �������� �̵�
        tr.Translate(rotSpeed * Vector3.right * Time.deltaTime, Space.Self); // X���� �������� ȸ��
        tr.Rotate(Vector3.up * input.h * Time.deltaTime * 100f); // Y���� �������� ȸ��

    }
}
