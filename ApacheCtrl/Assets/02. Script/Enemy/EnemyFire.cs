using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public Transform FirePos = null;
    public Transform FirePos_1 = null;
    //public AudioClip EffectClip;
    //public AudioClip shootClip;
    public int tankLayer;

    public GameObject expEffect;
    public AudioSource source;

    private EnemyAI enemyAI; // EnemyAI 스크립트 참조
    [SerializeField] private LeaserBeam beam; // 레이저 빔 스크립트 참조
    [SerializeField] private LeaserBeam beam_1; // 두 번째 레이저 빔 스크립트 참조
    [SerializeField] private AudioClip fireClip;
    [SerializeField] private AudioClip expClip;
    Transform tr;
    Ray ray1;
    Ray ray2;

    float curDelay = 0f;
    readonly float maxDelay = 2f;

    public bool isHit = false;
    Vector3 hitPoint;
    Vector3 nomal;
    Quaternion rot;
    GameObject eff;

    private string tankTag = "TANK";

    void Start()
    {
        tr = transform;
        source = GetComponent<AudioSource>();
        enemyAI = GetComponent<EnemyAI>();
        FirePos = transform.GetChild(3).transform;
        FirePos_1 = transform.GetChild(4).transform;
        beam = FirePos.GetComponentInChildren<LeaserBeam>();
        beam_1 = FirePos_1.GetComponentInChildren<LeaserBeam>();
        expEffect = Resources.Load<GameObject>("Effects/BigExplosionEffect");
        fireClip = Resources.Load<AudioClip>("Sounds/DestroyedExplosion");
        expClip = Resources.Load<AudioClip>("Sounds/ShootMissile");
        tankLayer = LayerMask.NameToLayer("TANK");
        curDelay = maxDelay;
    }

    
    void Update()
    {
        switch (enemyAI.state)
        {
            case EnemyAI.ApacheState.ATTACK:
                Fire();
                break;
        }
    }
    void Fire()
    {
        source.PlayOneShot(fireClip,1.0f);  
        RaycastHit hit;
        ray1 = new Ray(FirePos.position, FirePos.forward);
        ray2 = new Ray(FirePos_1.position, FirePos_1.forward);
        if(Physics.Raycast(ray1, out hit, Mathf.Infinity, 1<< tankLayer)
            || Physics.Raycast(ray2, out hit, Mathf.Infinity, 1 << tankLayer))
        {
            curDelay -= 0.1f;
            if (curDelay < 0)
            {
                SoundsManager.S_instance.PlaySfx(transform.position, expClip, false);
                curDelay = maxDelay;
                
                beam.FireRay(); // 레이저 빔 발사 / 라인 렌더러 효과를 표시할려고
                beam_1.FireRay(); // 두 번째 레이저 빔 발사
            }
            isHit = true;
           
            ShowEffect(hit);
        }
    }
    void ShowEffect(RaycastHit hit)
    {
        
        Vector3 hitpos = hit.point;
        Vector3 hitNormal = (FirePos.transform.position - hitPoint).normalized;
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, hitNormal);

        GameObject hitEffect = Instantiate(expEffect, hitpos,rot);
        Destroy(hitEffect, 1.5f);
        SoundsManager.S_instance.PlaySfx(hitpos, fireClip, false);
    }
}
