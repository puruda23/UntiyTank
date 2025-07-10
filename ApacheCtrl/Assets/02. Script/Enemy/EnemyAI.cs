using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum ApacheState { PATROL, ATTACK, DESTROY }
    public ApacheState state = ApacheState.PATROL;

    [Header("Patrol")]
    [SerializeField] List<Transform> patrolPoints;
    [Header("Speed")] [SerializeField] float rotSpeed = 15f, moveSpeed = 10f;
    Transform myTr;
    int currentPatrolIndex = 0;
    float wayCheck = 12f;
    public bool isSearch = true;

    void Start()
    {
        var pObj = GameObject.Find("PathPonits");
        if (pObj != null)
            pObj.GetComponentsInChildren<Transform>(patrolPoints);
        patrolPoints.RemoveAt(0);

        myTr = GetComponent<Transform>();
        

    }

    
    void FixedUpdate()
    {
        if (isSearch)
            WayPatrol();
        else
            Attack();


    }
    private void Update()
    {
        CheckP();
    }
    void WayPatrol()
    {
        state = ApacheState.PATROL;
        Vector3 movePos = patrolPoints[currentPatrolIndex].position - myTr.position;
        myTr.rotation = Quaternion.Slerp(myTr.rotation, Quaternion.LookRotation(movePos),
            Time.deltaTime * rotSpeed);
        myTr.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        Search();
    }
    void Search()
    {
        float tankFindDist = (GameObject.FindWithTag("TANK").transform.position - myTr.position).magnitude;
        if (tankFindDist <= 100f)
        {
            isSearch = false;
        }
    }
   
    void CheckP()
    {
        if (Vector3.Distance(myTr.position, patrolPoints[currentPatrolIndex].position) < wayCheck)
        {
            if (currentPatrolIndex == patrolPoints.Count - 1)
                currentPatrolIndex = 0;
            else
                currentPatrolIndex++;
        }
    }
    void Attack()
    {
        state = ApacheState.ATTACK;
        Vector3 targetDist = (GameObject.FindWithTag("TANK").transform.position - myTr.position);
        myTr.rotation = Quaternion.Slerp(myTr.rotation,Quaternion.LookRotation(targetDist.normalized),Time.deltaTime * rotSpeed);
        if (targetDist.magnitude >100f) 
            isSearch = true;
    }
}
