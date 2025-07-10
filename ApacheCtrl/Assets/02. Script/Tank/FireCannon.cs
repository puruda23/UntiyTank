using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public Transform FirePos; // �߻� ��ġ
    private TankInput input; // TankInput ��ũ��Ʈ ����
    [SerializeField] 
    private LeaserBeam beam; // ������ �� ��ũ��Ʈ ����
    public GameObject expEffect; // ���� ����Ʈ ������
    private AudioSource source; // ���� �ҽ�
    [SerializeField] private AudioClip fireClip; // �߻� ���� Ŭ��
    [SerializeField] private AudioClip expClip; // ���� ���� Ŭ��
    Ray ray; // ������ �߻�� Ray
    [SerializeField]
    int TerrainLayer; // ���� ���̾�
    public bool isHit = false; // �������� �浹�ߴ��� ����
    Vector3 hitPoint;
    Vector3 _normal;
    Quaternion rot;
    GameObject eff; // ���� ����Ʈ �ν��Ͻ�

    void Start()
    {
        source = GetComponent<AudioSource>(); // AudioSource ������Ʈ ��������
        input = GetComponent<TankInput>();
        FirePos = transform.GetChild(4).GetChild(1).GetChild(1).transform; // �߻� ��ġ�� �ڽ� ������Ʈ���� ã��
        beam = FirePos.GetComponentInChildren<LeaserBeam>(); // �߻� ��ġ���� LeaserBeam ������Ʈ ã��
        expEffect = Resources.Load<GameObject>("Effects/BigExplosionEffect"); // ���� ����Ʈ ������ �ε�
        // Resources ���� �ȿ� Effects ���� �� BigExplosionEffect �� �����´�
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
        if (Physics.Raycast(ray, out hit, 200f, 1<<TerrainLayer))
        {
            isHit = true; // �������� ������ �浹������ ǥ��
            beam.FireRay(); // ������ �� �߻� / ���� ������ ȿ���� ǥ���ҷ���
            ShowEffect(hit);
        }
        else // ���� �ʾҴٸ�
        {
            isHit = false; // �������� ������ �浹���� �ʾ����� ǥ��
            beam.FireRay(); // ������ �� �߻� / ���� ������ ȿ���� ǥ���ҷ���
            ShowEffect(hit); // �浹���� ���� ��쿡�� ���� ����Ʈ ǥ��
        }
    }
    void ShowEffect(RaycastHit hit)
    {
        if (isHit)
        {
            hitPoint = hit.point; // �浹 ����  // Vector3 hitPoint �� �ᵵ ���� �����μ� ����� ������
            _normal = (FirePos.position - hitPoint).normalized; // Ÿ�� ��ġ���� ���� ���������� ���� ���� ����
            // �߻� �������� ��ƼŬ�� ���δ�
            rot = Quaternion.FromToRotation(-Vector3.forward, _normal); // -Z ���⿡�� �浹 ������ ���� �������� ȸ��
            // - �� ������ ��ƼŬ�� �ڷ� Ƣ�µ� �ߺ��̰� �����ַ��� ���δ�
            eff = Instantiate(expEffect, hitPoint, rot); // ���� ����Ʈ ����
            Destroy(eff, 1.5f); // 1.5�� �Ŀ� ���� ����Ʈ ����
            source.PlayOneShot(expClip, 1.0f); // ���� ���� ���
        }
        else
        {
            // ���� ���� ��쿡�� 200 ���� ������ �������� �ڵ� ����
            hitPoint = ray.GetPoint(200f); 
            _normal = (FirePos.position - hitPoint).normalized; 
            rot = Quaternion.FromToRotation(-Vector3.forward, _normal); 
            eff = Instantiate(expEffect, hitPoint, rot); 
            Destroy(eff, 1.5f); 
            source.PlayOneShot(expClip, 1.0f); 
        }
    }
}
