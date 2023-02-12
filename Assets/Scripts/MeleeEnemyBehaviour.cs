using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent enemyNavMeshAgent;
    public GameObject target;
    public float attackRange= 2f;

    Vector3 enemyCoord;
    Vector3 targetCoord;
    Vector3 distanceFromTargetVector;

    // Update is called once per frame
    void Update()
    {
        //Acquire all necessary cords and distances
        if(!acquireSelfCoordsAndTargetCoords()){
            return;
        }
        calculateDistanceVector();

        //Decide what to do based on the distance form target
        if(isTargetInAttackRange()){
            meleeAttack();
        } else {
            followTarget();
        }
    }

    private bool acquireSelfCoordsAndTargetCoords(){
        if(Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out var enemyHitInfo)){
            enemyCoord = enemyHitInfo.point;
        } else {
            return false;
        }
        if(Physics.Raycast(target.transform.position, new Vector3(0f, -1f, 0f), out var hitInfo)){
            targetCoord = hitInfo.point;
            return true;
        } else {
            return false;
        }
    }
    private void calculateDistanceVector(){
        distanceFromTargetVector = enemyCoord - targetCoord;
        distanceFromTargetVector.y= 0f;
    }
    private void meleeAttack(){
        enemyNavMeshAgent.SetDestination(enemyCoord);
        return;
    }
    private void followTarget(){
        enemyNavMeshAgent.SetDestination(targetCoord);
    }
    private bool isTargetInAttackRange(){
        return (distanceFromTargetVector.magnitude < attackRange);
    }
}
