using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Targetable target;

    public void SetTarget(Targetable target)
    {
        this.target = target;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
    }
}
