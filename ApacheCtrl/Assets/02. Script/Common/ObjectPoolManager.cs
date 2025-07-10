using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager P_instance;
    public List<Transform> SpawnList;
    public GameObject effectPrefab;
    public List<GameObject> effectPool;
    private int maxPool = 20;

    WaitForSeconds ws;
    //public Dictionary<string, Queue<GameObject>> poolDictionary; // pools∏¶ ¿˙¿Â«“ µÒº≈≥ ∏Æ
    void Awake()
    {
        ws = new WaitForSeconds(0.2f);
        if (P_instance == null)
            P_instance = this;
        else if (P_instance != this)
            Destroy(this.gameObject);
        StartCoroutine(CreateEffect());
    }
    IEnumerator CreateEffect()
    {
        yield return ws;
        GameObject objectPools = new GameObject("ObjectPools");
        for (int i = 0; i < maxPool; i++)
        {
            var bullet = Instantiate(effectPrefab, objectPools.transform);
            bullet.name = $"∆¯πﬂ {i + 1} π¯¬∞";
            bullet.SetActive(false);
            effectPool.Add(bullet);
        }
    }


    public GameObject GetEffect()
    {
        for (int i = 0; i < effectPool.Count; i++)
        {
            if (effectPool[i].activeSelf == false)
            {
                return effectPool[i];
            }
        }
        return null;
    }

}
