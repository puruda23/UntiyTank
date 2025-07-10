using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheCtrl : MonoBehaviour
{
    public float moveSpeed = 0f; // Apache의 이동 속도
    public float rotSpeed = 0f; // Apache의 회전 속도
    Transform tr; // Apache의 Transform 컴포넌트
    private float VerticalSpeed = 0f; // 수직 이동 속도
    Rigidbody rb; // Apache의 Rigidbody 컴포넌트
    //[Header("Apache Limit")]
    //public float UpperAngle = -30f; // Apache가 위로 회전할 수 있는 최대 각도
    //public float downAngle = 0f; // Apache가 아래로 회전할 수 있는 최대 각도
    //public float currentRotate = 0f; // 현재 Apache의 회전 각도
    [SerializeField] private ApacheInput input; // ApacheInput 스크립트의 인스턴스

    void Start()
    {
        tr = GetComponent<Transform>(); // Apache의 Transform 컴포넌트를 가져옴
        rb = GetComponent<Rigidbody>(); // Apache의 Rigidbody 컴포넌트를 가져옴
        input = GetComponent<ApacheInput>(); // ApacheInput 스크립트의 인스턴스를 가져옴
    }

    
    void FixedUpdate() // 키보드를 누르는 값 만큼 이동하기 위한 로직
    {
        #region 좌우로 회전 하는 로직 A,D
        if (Input.GetKey(KeyCode.A)) // A 키를 누르는 중이면
            rotSpeed += -0.05f; // 왼쪽으로 회전 속도를 증가시킴
        else if (Input.GetKey(KeyCode.D))
            rotSpeed += 0.05f; // D 키를 누르는 중이면 오른쪽으로 회전 속도를 증가시킴
        else // 누르지 않았을 때 
        {
            if (rotSpeed > 0f) rotSpeed += -0.1f; // 서서히 회전하다가 멈춘다
            else if (rotSpeed < 0f) rotSpeed += 0.1f; 
        }
        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime); // Y축을 기준으로 회전
        #endregion
        #region 앞뒤로 이동 하는 로직 W,S
        if (Input.GetKey(KeyCode.W)) // W 키를 누르는 중이면
            moveSpeed += 0.05f; // 앞으로 이동 속도를 증가시킴
        else if (Input.GetKey(KeyCode.S)) // S 키를 누르는 중이면
            moveSpeed += -0.05f; // 뒤로 이동 속도를 증가시킴
        else // 누르지 않았을 때 
        {
            if (moveSpeed > 0f) moveSpeed += -0.1f; // 서서히 이동하다가 멈춘다
            else if (moveSpeed < 0f) moveSpeed += 0.1f;
        }
        tr.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self); // Z축을 기준으로 이동
        #endregion
        #region 수직(상하) 이동 로직 Space↑, LeftShift↓
        if(Input.GetKey(KeyCode.Space)) // Space 키를 누르는 중이면
            VerticalSpeed += 0.03f; // 위로 이동 속도를 증가시킴
        else if (Input.GetKey(KeyCode.LeftShift)) // LeftShift 키를 누르는 중이면
            VerticalSpeed += -0.03f; // 아래로 이동 속도를 증가시킴
        else // 누르지 않았을 때 
        {
            if (VerticalSpeed > 0f) VerticalSpeed += -0.03f; // 서서히 이동하다가 멈춘다
            else if (VerticalSpeed < 0f) VerticalSpeed += 0.03f;
        }
        tr.Translate(Vector3.up * VerticalSpeed * Time.deltaTime, Space.Self); // Y축을 기준으로 이동
        #endregion
        #region 몸체의 위아래 회전
        //float wheel = enemyAI.m_scrollWheel; // 마우스 휠 스크롤 입력 값
        //float angle = Time.deltaTime * rotSpeed * wheel; // 회전 각도 계산
        //if (wheel <= 0.01f) // 몸체를 올릴때 (마우스 휠을 위로 굴릴때)
        //{
        //    currentRotate += angle; // 현재 회전 각도 업데이트
        //    if (currentRotate > UpperAngle) // 몸체가 위로 회전할 수 있는 최대 각도를 초과하면
        //    {
        //        tr.Rotate(angle, 0f, 0f); // 몸체를 최대 각도로 회전 / 올린다
        //    }
        //    else
        //    {
        //        currentRotate = UpperAngle; // 현재 회전 각도를 최대 각도로 설정 / 제한한다
        //    }
        //}
        //else // 몸체를 내릴때 (마우스 휠을 아래로 굴릴때)
        //{
        //    currentRotate += angle; // 현재 회전 각도 업데이트
        //    if (currentRotate < downAngle) // 몸체가 위로 회전할 수 있는 최대 각도를 초과하면
        //    {
        //        tr.Rotate(angle, 0f, 0f); // 몸체를 최대 각도로 회전 / 내린다
        //    }
        //    else
        //    {
        //        currentRotate = downAngle; // 현재 회전 각도를 최대 각도로 설정 / 제한한다
        //    }
        //}
        #endregion

    }
}
