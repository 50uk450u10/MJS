using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] List<GameObject> points;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Patrol());
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
