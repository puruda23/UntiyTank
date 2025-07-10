using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaserBeam : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    Transform tr;


    void Start()
    {
        tr =GetComponent<Transform>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false; // ���� ��ǥ�踦 ������� �ʵ��� ����
        lineRenderer.enabled = false; // LineRenderer�� ��Ȱ��ȭ�Ͽ� ���� �� ������ �ʵ��� ����

    }
    public void FireRay() //public �̴ϱ� �ۿ��� ȣ�� ���� 
    {
                       // ��ġ  , ����  / ��� ��ġ���� ��� �������� ������ 
        Ray ray = new Ray(tr.position + (Vector3.up * 0.02f), tr.forward); // ���� ������Ʈ�� ��ġ�� ������ �������� Ray ����
        RaycastHit hit;
        // ���η����� ù��° ���� ���� ���������� ���� /ray.origin - Ray�� ������
        lineRenderer.SetPosition(0,tr.InverseTransformPoint(ray.origin)); // Ray�� �������� LineRenderer�� ù ��° ��ġ�� ����
                                    // ���� ��ǥ�� ���� ��ǥ�� ��ȯ
        if (Physics.Raycast(ray, out hit, 200f, 1<<6)) // ����ĳ��Ʈ�� ����Ͽ� �浹�� ����
        {     // 200 ���� ���� �ȿ��� �ͷ��ο� ������ �¾Ҵٸ�
            lineRenderer.SetPosition(1,tr.InverseTransformPoint(hit.point)); // Ray�� �浹�� ������ LineRenderer�� �� ��° ��ġ�� ����
            // ������ ���� ��ġ�� ���
        }
        else // ���� �ʰ� ��� ���� ���� ��쿡��
        {
            lineRenderer.SetPosition(1,tr.InverseTransformPoint(ray.GetPoint(200f))); // Ray�� ������ 200 ���� ������ �������� ����
            // ���� ���� ��쿡�� ������ �뷫 200�������� ����
        }
        // ������ ���� �����ֱ� ���� ShowLeaserBeam �ڷ�ƾ�� ����
        StartCoroutine(ShowLeaserBeam()); // ShowLeaserBeam �ڷ�ƾ�� �����Ͽ� LineRenderer�� Ȱ��ȭ
    }
    IEnumerator ShowLeaserBeam()
    {
        lineRenderer.enabled = true; // LineRenderer�� Ȱ��ȭ�Ͽ� ������ ���� ǥ��
        yield return new WaitForSeconds(Random.Range(0.1f,0.3f)); // 0.1�ʿ��� 0.3�� ������ ���� �ð� ���� ���
        lineRenderer.enabled = false; // ���� �ð��� ���� �� LineRenderer�� ��Ȱ��ȭ�Ͽ� ������ ���� ����
    }


}
