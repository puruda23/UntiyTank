using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null; // GameManager의 인스턴스를 저장할 정적 변수
    public bool isGameOver = false; // 게임 오버 상태를 나타내는 변수

    void Awake()
    {
        if (Instance == null) // GameManager의 인스턴스가 없으면
            Instance = this; // 현재 GameManager를 인스턴스로 설정
        else if (Instance != this)
            Destroy(gameObject); // 이미 인스턴스가 존재하면 현재 GameManager를 파괴
        
    }

    
}
