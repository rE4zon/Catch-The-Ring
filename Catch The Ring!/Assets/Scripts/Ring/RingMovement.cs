using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RingMovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] private float timeForNewPath;

    bool inCoroutine;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    { 
        if(!inCoroutine)
        {
            StartCoroutine(DoSomething());
        }    
    }

    private Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator DoSomething()
    {
        inCoroutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        inCoroutine = false;
    }

    private void GetNewPath()
    {
        navMeshAgent.SetDestination(getNewRandomPosition());
    }
}
