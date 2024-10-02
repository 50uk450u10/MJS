using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] List<GameObject> points;
    [SerializeField] GameObject player;
    [SerializeField] Transform target;
    States states = States.Patrol;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Patrol());
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider player)
        {

        }

        //dot product
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Vector3 forwardDirection = transform.forward;
        float dot = Vector3.Dot(forwardDirection, directionToTarget);

        if (dot > 0.5f ) { states = States.Pursue; }

        switch (states)
        {
            case States.Patrol:
                StartCoroutine(Patrol());
                break;
            case States.Investigate:
                StopCoroutine(Patrol());
                break;
            case States.Pursue:
                StopCoroutine(Patrol());
                transform.position = target.position;
                break;
            default:
                states = States.Patrol;
                break;
        }
    }

    IEnumerator Patrol()
    {
        int i = 0;
        while (true)
        {
            agent.SetDestination(points[i].transform.position);
            yield return new YieldPointPlace(agent.transform, points[i].transform);
            i++;
            if(i > points.Count - 1)
            {
                i = 0;
            }
        }
    }

    enum States
    {
        Patrol,
        Investigate,
        Pursue
    }
}
