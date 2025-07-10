using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null; // GameManager�� �ν��Ͻ��� ������ ���� ����
    public bool isGameOver = false; // ���� ���� ���¸� ��Ÿ���� ����

    void Awake()
    {
        if (Instance == null) // GameManager�� �ν��Ͻ��� ������
            Instance = this; // ���� GameManager�� �ν��Ͻ��� ����
        else if (Instance != this)
            Destroy(gameObject); // �̹� �ν��Ͻ��� �����ϸ� ���� GameManager�� �ı�
        
    }

    
}
