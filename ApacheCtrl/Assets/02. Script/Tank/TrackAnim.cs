using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAnim : MonoBehaviour
{
    private float _scrollSpeed = 1.0f; // 트랙 애니메이션의 스크롤 속도
    private MeshRenderer _meshRenderer; // MeshRenderer 컴포넌트
    TankInput input; // TankInput 스크립트의 인스턴스
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>(); // MeshRenderer 컴포넌트를 가져옴
        input = GetComponentInParent<TankInput>(); // 부모 오브젝트에서 TankInput 스크립트의 인스턴스를 가져옴
    }

    
    void Update()
    {
        var offset = Time.time * _scrollSpeed * input.axisRaw; // w,s 앞뒤 이동 입력에 따라 트랙 애니메이션의 이동을 계산
        // 일반 base 텍스처
        _meshRenderer.material.SetTextureOffset("_MainTex",new Vector2(offset,offset)); // 메인 텍스처의 오프셋을 설정
        // 노말 맵의 텍스처
        _meshRenderer.material.SetTextureOffset("_BumpMap", new Vector2(0f,offset)); // 범프 맵의 오프셋을 설정

    }
}
