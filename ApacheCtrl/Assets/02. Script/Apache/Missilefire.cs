using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missilefire : MonoBehaviour
{
    public Transform FirePos; // �߻� ��ġ
    public Transform FirePos_1; // �� ��° �߻� ��ġ
    private ApacheInput input; // ApacheInput ��ũ��Ʈ ����
    [SerializeField] private LeaserBeam beam; // ������ �� ��ũ��Ʈ ����
    [SerializeField] private LeaserBeam beam_1; // �� ��° ������ �� ��ũ��Ʈ ����
    public GameObject expEffect; // ���� ����Ʈ ������
    private AudioSource source; // ���� �ҽ�
    [SerializeField] private AudioClip fireClip; // �߻� ���� Ŭ��
    [SerializeField] private AudioClip expClip; // ���� ���� Ŭ��
    Ray ray; // ������ �߻�� Ray
    [SerializeField] int TerrainLayer; // ���� ���̾�
    public bool isHit = false; // �������� �浹�ߴ��� ����
    Vector3 hitPoint;
    Vector3 _normal;
    Quaternion rot;
    GameObject eff; // ���� ����Ʈ �ν��Ͻ�

    void Start()
    {
        source = GetComponent<AudioSource>(); // AudioSource ������Ʈ ��������
        input = GetComponent<ApacheInput>();
        FirePos = transform.GetChild(3).transform; // �߻� ��ġ�� �ڽ� ������Ʈ���� ã��
        FirePos_1 = transform.GetChild(4).transform; // �� ��° �߻� ��ġ�� �ڽ� ������Ʈ���� ã��
        beam = FirePos.GetComponentInChildren<LeaserBeam>(); // �߻� ��ġ���� LeaserBeam ������Ʈ ã��
        beam_1 = FirePos_1.GetComponentInChildren<LeaserBeam>(); // �� ��° �߻� ��ġ���� LeaserBeam ������Ʈ ã��
        expEffect = Resources.Load<GameObject>("Effects/BigExplosionEffect"); // ���� ����Ʈ ������ �ε�
        fireClip = Resources.Load<AudioClip>("Sounds/ShootMissile");
        expClip = Resources.Load<AudioClip>("Sounds/DestroyedExplosion");
        TerrainLayer = LayerMask.NameToLayer("TERRAIN"); // ���� ���̾� �̸��� ��������
    }

    
    void Update()
    {
        if (input.isFire)
        {
            Fire();
        }
    }
    void Fire()
    {
        source.PlayOneShot(fireClip, 1.0f); // �߻� ���� ���
        RaycastHit hit; // ������ �浹 ������ ������ ����
        ray = new Ray(FirePos.position, FirePos.forward); // �߻� ��ġ�� �������� Ray ����
        ray = new Ray(FirePos_1.position, FirePos_1.forward); // �� ��° �߻� ��ġ�� �������� Ray ����
        if (Physics.Raycast(ray, out hit, 200f, 1<< TerrainLayer))
        {
            isHit = true; // �������� ������ �浹������ ǥ��
            beam.FireRay(); // ������ �� �߻� / ���� ������ ȿ���� ǥ���ҷ���
            beam_1.FireRay(); // �� ��° ������ �� �߻�
            ShowEffect(hit);
        }
    }
    void ShowEffect(RaycastHit hit)
    {
        if(isHit)
        {
            hitPoint = hit.point; // �浹 ����
            _normal = hit.normal; // �浹 ǥ���� ���� ����
            rot = Quaternion.FromToRotation(Vector3.up, _normal); // ���� ���͸� �������� ȸ��
            eff = Instantiate(expEffect, hitPoint, rot); // ���� ����Ʈ �ν��Ͻ� ����
            Destroy(eff, 1.5f); // 1.5�� �Ŀ� ���� ����Ʈ ����
            source.PlayOneShot(expClip, 1.0f); // ���� ���� ���
        }
        else
        {
            hitPoint = ray.GetPoint(200f); // �������� �浹���� ���� ���, 200 ���� �Ÿ��� ���� ������
            _normal = -ray.direction; // ������ ������ �ݴ� ���͸� �������� ���
            rot = Quaternion.FromToRotation(Vector3.up, _normal); // ���� ���͸� �������� ȸ��
            eff = Instantiate(expEffect, hitPoint, rot); // ���� ����Ʈ �ν��Ͻ� ����
            Destroy(eff, 1.5f); // 1.5�� �Ŀ� ���� ����Ʈ ����
            source.PlayOneShot(expClip, 1.0f); // ���� ���� ���
        }
        
    }
}
