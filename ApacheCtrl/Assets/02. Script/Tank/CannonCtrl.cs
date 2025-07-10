using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCtrl : MonoBehaviour
{
    public float rotSpeed = 5000f; // ������ ȸ�� �ӵ�
    [SerializeField] TankInput input; // TankInput ��ũ��Ʈ�� �ν��Ͻ�
    private Transform tr; // Cannon�� Transform ������Ʈ
    // ���� ȸ�� ���� ����
    [Header("Cannon Limit")]
    public float UpperAngle = -30f; // ������ ���� ȸ���� �� �ִ� �ִ� ����
    public float downAngle = 0f; // ������ �Ʒ��� ȸ���� �� �ִ� �ִ� ����
    public float currentRotate = 0f; // ���� ������ ȸ�� ����

    void Start()
    {
        tr = GetComponent<Transform>(); // Cannon�� Transform ������Ʈ�� ������
        input = GetComponentInParent<TankInput>(); // �θ� ������Ʈ���� TankInput ��ũ��Ʈ�� �ν��Ͻ��� ������
        
    }

    
    void Update()
    {
        // localRotation - �θ�� ���� ȸ������ �ʰ� ���� ȸ���Ѵ�
        #region Cannon Rotate -(����)������ ȸ��
        //float wheel = -enemyAI.m_scrollWheel; // ���콺 �� ��ũ�� �Է� ��
        //float angle = Time.deltaTime * rotSpeed *wheel; // ȸ�� ���� ���
        //if (wheel <= -0.01f) // - �ϱ� ������ �ø���
        //{
        //    currentRotate += angle; // ���� ȸ�� ���� ������Ʈ
        //    if (currentRotate > UpperAngle) // ������ ���� ȸ���� �� �ִ� �ִ� ������ �ʰ��ϸ�
        //    {
        //        tr.Rotate(angle,0f,0f); // ������ �ִ� ������ ȸ�� / �ø���
        //    }
        //    else
        //    {
        //        currentRotate = UpperAngle; // ���� ȸ�� ������ �ִ� ������ ���� / �����Ѵ�
        //    }
        //}
        //else // ������ ������
        //{
        //    currentRotate += angle; // ���� ȸ�� ���� ������Ʈ
        //    if (currentRotate < downAngle) // ������ ���� ȸ���� �� �ִ� �ִ� ������ �ʰ��ϸ�
        //    {
        //        tr.Rotate(angle, 0f, 0f); // ������ �ִ� ������ ȸ�� / ������
        //    }
        //    else
        //    {
        //        currentRotate = downAngle; // ���� ȸ�� ������ �ִ� ������ ���� / �����Ѵ�
        //    }
        //}
        #endregion
        #region Cannon Rotate +(���)������ ȸ�� 
        float wheel = input.m_scrollWheel; // ���콺 �� ��ũ�� �Է� ��
        float angle = Time.deltaTime * rotSpeed * wheel; // ȸ�� ���� ���
        if (wheel <= 0.01f) // - �ϱ� ������ �ø���
        {
            currentRotate += angle; // ���� ȸ�� ���� ������Ʈ
            if (currentRotate > UpperAngle) // ������ ���� ȸ���� �� �ִ� �ִ� ������ �ʰ��ϸ�
            {
                tr.Rotate(angle, 0f, 0f); // ������ �ִ� ������ ȸ�� / �ø���
            }
            else
            {
                currentRotate = UpperAngle; // ���� ȸ�� ������ �ִ� ������ ���� / �����Ѵ�
            }
        }
        else // ������ ������
        {
            currentRotate += angle; // ���� ȸ�� ���� ������Ʈ
            if (currentRotate < downAngle) // ������ ���� ȸ���� �� �ִ� �ִ� ������ �ʰ��ϸ�
            {
                tr.Rotate(angle, 0f, 0f); // ������ �ִ� ������ ȸ�� / ������
            }
            else
            {
                currentRotate = downAngle; // ���� ȸ�� ������ �ִ� ������ ���� / �����Ѵ�
            }
        }
        #endregion
        //tr.Rotate(wheel * Time.deltaTime * rotSpeed, 0f, 0f); // 360�� ȸ�� �ӵ��� ���� ���� ȸ��

    }
}
