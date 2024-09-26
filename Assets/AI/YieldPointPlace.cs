using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class YieldPointPlace : CustomYieldInstruction
{
    public override bool keepWaiting 
    {  
        get 
        { 
            Vector3 distance = point.position - agent.position;
            if(Mathf.Abs(distance.magnitude) <= 2)
            {
                return false;
            }
            else { return true; }
        } 
    }

    Transform agent;

    Transform point;

    public YieldPointPlace(Transform agent, Transform point)
    {
        this.agent = agent;
        this.point = point;
    }
}