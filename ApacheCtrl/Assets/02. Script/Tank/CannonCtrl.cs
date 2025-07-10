using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCtrl : MonoBehaviour
{
    public float rotSpeed = 5000f; // 포신의 회전 속도
    [SerializeField] TankInput input; // TankInput 스크립트의 인스턴스
    private Transform tr; // Cannon의 Transform 컴포넌트
    // 포신 회전 각도 제한
    [Header("Cannon Limit")]
    public float UpperAngle = -30f; // 포신이 위로 회전할 수 있는 최대 각도
    public float downAngle = 0f; // 포신이 아래로 회전할 수 있는 최대 각도
    public float currentRotate = 0f; // 현재 포신의 회전 각도

    void Start()
    {
        tr = GetComponent<Transform>(); // Cannon의 Transform 컴포넌트를 가져옴
        input = GetComponentInParent<TankInput>(); // 부모 오브젝트에서 TankInput 스크립트의 인스턴스를 가져옴
        
    }

    
    void Update()
    {
        // localRotation - 부모와 같이 회전하지 않고 따로 회전한다
        #region Cannon Rotate -(음수)값으로 회전
        //float wheel = -enemyAI.m_scrollWheel; // 마우스 휠 스크롤 입력 값
        //float angle = Time.deltaTime * rotSpeed *wheel; // 회전 각도 계산
        //if (wheel <= -0.01f) // - 니까 포신을 올릴때
        //{
        //    currentRotate += angle; // 현재 회전 각도 업데이트
        //    if (currentRotate > UpperAngle) // 포신이 위로 회전할 수 있는 최대 각도를 초과하면
        //    {
        //        tr.Rotate(angle,0f,0f); // 포신을 최대 각도로 회전 / 올린다
        //    }
        //    else
        //    {
        //        currentRotate = UpperAngle; // 현재 회전 각도를 최대 각도로 설정 / 제한한다
        //    }
        //}
        //else // 포신을 내릴때
        //{
        //    currentRotate += angle; // 현재 회전 각도 업데이트
        //    if (currentRotate < downAngle) // 포신이 위로 회전할 수 있는 최대 각도를 초과하면
        //    {
        //        tr.Rotate(angle, 0f, 0f); // 포신을 최대 각도로 회전 / 내린다
        //    }
        //    else
        //    {
        //        currentRotate = downAngle; // 현재 회전 각도를 최대 각도로 설정 / 제한한다
        //    }
        //}
        #endregion
        #region Cannon Rotate +(양수)값으로 회전 
        float wheel = input.m_scrollWheel; // 마우스 휠 스크롤 입력 값
        float angle = Time.deltaTime * rotSpeed * wheel; // 회전 각도 계산
        if (wheel <= 0.01f) // - 니까 포신을 올릴때
        {
            currentRotate += angle; // 현재 회전 각도 업데이트
            if (currentRotate > UpperAngle) // 포신이 위로 회전할 수 있는 최대 각도를 초과하면
            {
                tr.Rotate(angle, 0f, 0f); // 포신을 최대 각도로 회전 / 올린다
            }
            else
            {
                currentRotate = UpperAngle; // 현재 회전 각도를 최대 각도로 설정 / 제한한다
            }
        }
        else // 포신을 내릴때
        {
            currentRotate += angle; // 현재 회전 각도 업데이트
            if (currentRotate < downAngle) // 포신이 위로 회전할 수 있는 최대 각도를 초과하면
            {
                tr.Rotate(angle, 0f, 0f); // 포신을 최대 각도로 회전 / 내린다
            }
            else
            {
                currentRotate = downAngle; // 현재 회전 각도를 최대 각도로 설정 / 제한한다
            }
        }
        #endregion
        //tr.Rotate(wheel * Time.deltaTime * rotSpeed, 0f, 0f); // 360도 회전 속도에 따라 포신 회전

    }
}
