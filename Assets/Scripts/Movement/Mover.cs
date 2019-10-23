using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement

{
    public class Mover : MonoBehaviour
    {

        NavMeshAgent navMeshAgent;
       // Animator animator;

        void Start() {
            navMeshAgent = GetComponent<NavMeshAgent>();
          //  animator = GetComponent<Animator>();
        }

        void Update()
        {

            UpdateAnimator();
            //animator.Play("Attack");
            
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            // GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
        


        public void MoveTo(Vector3 destination)
        {
            
            //navMeshAgent.destination = destination;
            navMeshAgent.SetDestination(destination);

            navMeshAgent.isStopped = false;
          
             
            
        }
        public void Stop() {
            navMeshAgent.isStopped = true;
        }
    }

}