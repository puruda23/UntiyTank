using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// W,S 앞뒤 A,D 좌우 마우스 휘을 굴리면 포신이 올라가거나 내려가야 함
// 마우스 X로 움직일때 마다 삼각함수를 이용 해서 Turret이 Y축으로 회전 해야 함
// 역탄젠트 함수 Atan 아크탄젠트
public class TankInput : MonoBehaviour
{
    public string hori = "Horizontal"; // 좌우 이동을 위한 입력 축
    public string verti = "Vertical"; // 앞뒤 이동을 위한 입력 축
    public string mouseScrollWheel = "Mouse ScrollWheel"; // 마우스 휠 스크롤 입력 축
    public string Fire = "Fire1"; // 발사 입력 축 (예: 마우스 왼쪽 버튼)

    public float h = 0f; // a,d 회전 입력 값
    public float v = 0f; // w,s 앞뒤 이동 입력 값
    public float m_scrollWheel = 0f; // 마우스 휠 스크롤 입력 값
    public float axisRaw = 0f; // 입력 축의 원시 값 (GetAxisRaw 사용 시)
    public bool isFire = false; // 발사 입력 여부

    void Start()
    {
        

    }

    
    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
        {
            h = 0f; v = 0f; // 게임 오버 상태에서는 입력을 무시
            m_scrollWheel = 0f; // 마우스 휠 스크롤 입력을 무시
            isFire = false; // 발사 입력을 무시
            return; // Update 함수 종료
        }
        h = Input.GetAxis(hori); // 좌우 이동 입력
        v = Input.GetAxis(verti); // 앞뒤 이동 입력
        m_scrollWheel = Input.GetAxisRaw(mouseScrollWheel); // 마우스 휠 스크롤 입력 / GetAxisRaw - 즉시(빠르게) 입력
        isFire = Input.GetButtonDown(Fire); // 발사 입력 (마우스 왼쪽 버튼 클릭 시 true로 설정)
        axisRaw = Input.GetAxisRaw(verti); // 앞뒤 이동 입력의 원시 값

    }
}
