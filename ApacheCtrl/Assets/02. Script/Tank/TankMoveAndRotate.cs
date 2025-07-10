using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveAndRotate : MonoBehaviour
{
    public float moveSpeed = 0f; // Tank의 이동 속도
    public float rotSpeed = 0f; // Tank의 회전 속도

    Transform tr; // Tank의 Transform 컴포넌트
    Rigidbody rb; // Tank의 Rigidbody 컴포넌트
    TankInput input; // TankInput 스크립트의 인스턴스

    //private float HorizontalSpeed = 0f; // 수평 이동 속도

    void Start()
    {
        tr = GetComponent<Transform>(); // Tank의 Transform 컴포넌트를 가져옴
        rb = GetComponent<Rigidbody>(); // Tank의 Rigidbody 컴포넌트를 가져옴
        input = GetComponent<TankInput>(); // TankInput 스크립트의 인스턴스를 가져옴
        rb.centerOfMass = new Vector3(0f,-0.5f,0f); // Rigidbody의 무게 중심점을 설정

    }

    
    void Update() // 움직임 구현 해야함
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
        {
            moveSpeed = 0f; // 게임 오버 상태에서는 이동 속도를 0으로 설정
            rotSpeed = 0f; // 회전 속도도 0으로 설정
            return; // Update 메서드 종료
        }
        // 이동 속도와 회전 속도를 입력에 따라 설정
        moveSpeed = input.v * 5f; // w,s 입력에 따라 이동 속도 설정
        rotSpeed = input.h * 5f; // a,d 입력에 따라 회전 속도 설정
        // Tank의 이동 및 회전
       // rb.velocity = tr.forward * moveSpeed; // Tank의 전방 방향으로 이동 속도 적용
        // rb.velocity = tr.right * HorizontalSpeed; // 수평 이동 속도 적용 (현재 사용하지 않음)
        // rb.angularVelocity = tr.up * rotSpeed; // Tank의 회전 속도 적용 (현재 사용하지 않음)
        // Transform을 이용한 회전
        tr.Translate(moveSpeed * Vector3.forward * Time.deltaTime, Space.Self); // Z축을 기준으로 이동
        // Space.Self - 현재 오브젝트의 로컬 좌표계를 기준으로 이동
        tr.Translate(rotSpeed * Vector3.right * Time.deltaTime, Space.Self); // X축을 기준으로 회전
        tr.Rotate(Vector3.up * input.h * Time.deltaTime * 100f); // Y축을 기준으로 회전

    }
}
