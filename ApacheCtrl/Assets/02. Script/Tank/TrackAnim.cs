using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAnim : MonoBehaviour
{
    private float _scrollSpeed = 1.0f; // Ʈ�� �ִϸ��̼��� ��ũ�� �ӵ�
    private MeshRenderer _meshRenderer; // MeshRenderer ������Ʈ
    TankInput input; // TankInput ��ũ��Ʈ�� �ν��Ͻ�
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>(); // MeshRenderer ������Ʈ�� ������
        input = GetComponentInParent<TankInput>(); // �θ� ������Ʈ���� TankInput ��ũ��Ʈ�� �ν��Ͻ��� ������
    }

    
    void Update()
    {
        var offset = Time.time * _scrollSpeed * input.axisRaw; // w,s �յ� �̵� �Է¿� ���� Ʈ�� �ִϸ��̼��� �̵��� ���
        // �Ϲ� base �ؽ�ó
        _meshRenderer.material.SetTextureOffset("_MainTex",new Vector2(offset,offset)); // ���� �ؽ�ó�� �������� ����
        // �븻 ���� �ؽ�ó
        _meshRenderer.material.SetTextureOffset("_BumpMap", new Vector2(0f,offset)); // ���� ���� �������� ����

    }
}
