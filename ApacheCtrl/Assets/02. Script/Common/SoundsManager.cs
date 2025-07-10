using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager S_instance; // 실글톤
    public bool isMute = false; // 음소거

    void Awake()
    {
        if (S_instance == null) S_instance = this;
        else if (S_instance != this) Destroy(gameObject);

    }
    public void PlaySfx(Vector3 pos, AudioClip clip,bool isLooped)
    {
        if (isMute) return; // 음소거시 빠져 나감

        GameObject soundObj = new GameObject("SoundSFX~~");
        soundObj.transform.position = pos;
        AudioSource audioSource = soundObj.AddComponent<AudioSource>();
        // AddComponent - 컴퍼넌트가 없으면 새로 생성한다
        audioSource.clip = clip;
        audioSource.loop = isLooped;
        audioSource.minDistance = 20f;
        audioSource.maxDistance = 100f;
        audioSource.volume = 1.0f;
        audioSource.Play();

        Destroy(soundObj,audioSource.clip.length);


    }
    
    void Update()
    {
        
    }
}
