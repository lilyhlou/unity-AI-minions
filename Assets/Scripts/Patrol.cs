    // Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour {

        public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;
        private Animator anim;
        public GameObject treasureHunter;


        void Start () {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            anim.SetFloat("speed", 3f);

            agent.autoBraking = false;
            treasureHunter = GameObject.Find("TreasureHunter");
            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }

        private void FaceTarget(Vector3 destination) {
            agent.isStopped = true;
            Vector3 lookPos = destination - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            agent.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 180f);  
        }



        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.
               if ((treasureHunter.transform.position-this.transform.position).sqrMagnitude<4*4) {
                // the player is within a radius of 3 units to this game object
                FaceTarget(treasureHunter.transform.position);
                //agent.transform.LookAt(treasureHunter.transform.position);
                //gent.isStopped = true;
                anim.SetFloat("speed", 0f);
                print("IS STOPPED");

                } else {
                agent.isStopped = false;
                anim.SetFloat("speed", 3f);

                }

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }
