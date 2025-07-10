using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheInput : MonoBehaviour
{
    //public string mouseScrollWheel = "Mouse ScrollWheel"; // ���콺 �� ��ũ�� �Է� ��
    public string Fire = "Fire1"; // �߻� �Է� �� (��: ���콺 ���� ��ư)

    public float h = 0f; // �¿� �̵� �Է� ��
    public float v = 0f; // �յ� �̵� �Է� ��
    //public float m_scrollWheel = 0f; // ���콺 �� ��ũ�� �Է� ��
    public bool isFire = false; // �߻� �Է� ����


    void Start()
    {
        
    }

    
    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
        {
            h = 0f; v = 0f; // ���� ���� ���¿����� �Է��� ����
            //m_scrollWheel = 0f; // ���콺 �� ��ũ�� �Է��� ����
            isFire = false; // �߻� �Է��� ����
            return; // Update �Լ� ����
        }
        isFire = Input.GetButtonDown(Fire); // �߻� �Է� (���콺 ���� ��ư Ŭ�� �� true�� ����)
        //m_scrollWheel = Input.GetAxisRaw(mouseScrollWheel); // ���콺 �� ��ũ�� �Է� / GetAxisRaw - ���(������) �Է�
        
    }
}
