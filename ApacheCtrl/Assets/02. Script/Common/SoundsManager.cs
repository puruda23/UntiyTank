using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager S_instance; // �Ǳ���
    public bool isMute = false; // ���Ұ�

    void Awake()
    {
        if (S_instance == null) S_instance = this;
        else if (S_instance != this) Destroy(gameObject);

    }
    public void PlaySfx(Vector3 pos, AudioClip clip,bool isLooped)
    {
        if (isMute) return; // ���ҰŽ� ���� ����

        GameObject soundObj = new GameObject("SoundSFX~~");
        soundObj.transform.position = pos;
        AudioSource audioSource = soundObj.AddComponent<AudioSource>();
        // AddComponent - ���۳�Ʈ�� ������ ���� �����Ѵ�
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
