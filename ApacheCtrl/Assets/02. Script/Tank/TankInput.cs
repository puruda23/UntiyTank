using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// W,S �յ� A,D �¿� ���콺 ���� ������ ������ �ö󰡰ų� �������� ��
// ���콺 X�� �����϶� ���� �ﰢ�Լ��� �̿� �ؼ� Turret�� Y������ ȸ�� �ؾ� ��
// ��ź��Ʈ �Լ� Atan ��ũź��Ʈ
public class TankInput : MonoBehaviour
{
    public string hori = "Horizontal"; // �¿� �̵��� ���� �Է� ��
    public string verti = "Vertical"; // �յ� �̵��� ���� �Է� ��
    public string mouseScrollWheel = "Mouse ScrollWheel"; // ���콺 �� ��ũ�� �Է� ��
    public string Fire = "Fire1"; // �߻� �Է� �� (��: ���콺 ���� ��ư)

    public float h = 0f; // a,d ȸ�� �Է� ��
    public float v = 0f; // w,s �յ� �̵� �Է� ��
    public float m_scrollWheel = 0f; // ���콺 �� ��ũ�� �Է� ��
    public float axisRaw = 0f; // �Է� ���� ���� �� (GetAxisRaw ��� ��)
    public bool isFire = false; // �߻� �Է� ����

    void Start()
    {
        

    }

    
    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
        {
            h = 0f; v = 0f; // ���� ���� ���¿����� �Է��� ����
            m_scrollWheel = 0f; // ���콺 �� ��ũ�� �Է��� ����
            isFire = false; // �߻� �Է��� ����
            return; // Update �Լ� ����
        }
        h = Input.GetAxis(hori); // �¿� �̵� �Է�
        v = Input.GetAxis(verti); // �յ� �̵� �Է�
        m_scrollWheel = Input.GetAxisRaw(mouseScrollWheel); // ���콺 �� ��ũ�� �Է� / GetAxisRaw - ���(������) �Է�
        isFire = Input.GetButtonDown(Fire); // �߻� �Է� (���콺 ���� ��ư Ŭ�� �� true�� ����)
        axisRaw = Input.GetAxisRaw(verti); // �յ� �̵� �Է��� ���� ��

    }
}
