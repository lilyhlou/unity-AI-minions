using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
    public class MoveDestination : MonoBehaviour {
       
       public Transform goal;
       private  UnityEngine.AI.NavMeshAgent agent;
       
       void Start () {
         agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
         agent.destination = goal.position; 
       }
       private void Update() {
          //Vector3 direction = transform.DirectionTo(agent.destination);
          float distance = Vector3.Distance(agent.destination, transform.position);

          if (distance > 0.1) {
             //LookToward(agent.destination, distance);
             //float distanceBasedSpeedModifier = GetSpeedModifier(distance);

            agent.Move(transform.forward * Time.deltaTime);

          }

       }
    }
