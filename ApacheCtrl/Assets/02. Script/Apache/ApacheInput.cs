using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheInput : MonoBehaviour
{
    //public string mouseScrollWheel = "Mouse ScrollWheel"; // 마우스 휠 스크롤 입력 축
    public string Fire = "Fire1"; // 발사 입력 축 (예: 마우스 왼쪽 버튼)

    public float h = 0f; // 좌우 이동 입력 값
    public float v = 0f; // 앞뒤 이동 입력 값
    //public float m_scrollWheel = 0f; // 마우스 휠 스크롤 입력 값
    public bool isFire = false; // 발사 입력 여부


    void Start()
    {
        
    }

    
    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
        {
            h = 0f; v = 0f; // 게임 오버 상태에서는 입력을 무시
            //m_scrollWheel = 0f; // 마우스 휠 스크롤 입력을 무시
            isFire = false; // 발사 입력을 무시
            return; // Update 함수 종료
        }
        isFire = Input.GetButtonDown(Fire); // 발사 입력 (마우스 왼쪽 버튼 클릭 시 true로 설정)
        //m_scrollWheel = Input.GetAxisRaw(mouseScrollWheel); // 마우스 휠 스크롤 입력 / GetAxisRaw - 즉시(빠르게) 입력
        
    }
}
