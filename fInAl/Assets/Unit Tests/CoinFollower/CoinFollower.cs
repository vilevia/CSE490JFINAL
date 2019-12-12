using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CoinFollower : MonoBehaviour
{
    public CoinDetector coinDetectionZone;
    public GameObject currentTarget;
    public NavMeshAgent agent;
    private void Start() {
        coinDetectionZone.CoinDetectedEvent += assignTarget;
    }

    public void assignTarget(GameObject target) {
        currentTarget = target;
    }

    public void Update() {
        if (currentTarget != null) {
            agent.SetDestination(currentTarget.transform.position);
        }
        if(agent.remainingDistance <= agent.stoppingDistance) {
            Destroy(currentTarget.gameObject);
        }
    }
}
