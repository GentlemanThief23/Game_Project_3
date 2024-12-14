using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

namespace SG
{
    public class EnemyLocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        public CharacterStats currentTarget;
        
        NavMeshAgent navmeshAgent;
        public Rigidbody enemyRigidBody;

        public LayerMask detectionLayer;

        public float distanceFromTarget;
        public float stoppingDistance = 1f;

        public float rotatioSpeed = 15;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
        }

        public void HandleDetection()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);

            for (int i = 0; i < colliders.Length; i++)
            {
                CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

                if (characterStats != null) 
                {
                    Vector3 targetDirection = characterStats.transform.position - transform.position;
                    float viewableAngle = Vector3.Angle(targetDirection, transform.forward);   

                    if (viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
                    {
                        currentTarget = characterStats;
                    }
                }
            }
        }

        public void HandleMoveToTarget()
        {
            if (enemyManager.isPerforminAction)
                return;
        }

       
    }
}
