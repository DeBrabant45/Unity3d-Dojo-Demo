using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.AI
{
    [CreateAssetMenu(menuName = "StateMachine/AI/Decisions/Look")]
    public class LookDecision : AIDecision
    {
        public override bool Decide(AIStateController controller)
        {
            bool targetVisable = Look(controller);
            return targetVisable;
        }

        private bool Look(AIStateController controller)
        {
            bool isPlayerInSightRange = Physics.CheckSphere(controller.transform.position, controller.AIStats.SightRange, controller.Layer);
            //RaycastHit hit;
            //Debug.DrawRay(controller.transform.position, controller.transform.forward.normalized * 5/*controller.enemyStats.lookRange*/, Color.green);
            //if (Physics.SphereCast(controller.transform.position, 100/*controller.EyeSight.lookSphereCastRadius*/,
            //    controller.transform.forward, out hit, 2/*controller.enemyStats.lookRange*/)
            //    && hit.collider.CompareTag("Player"))
            if(isPlayerInSightRange != false)
            {
                //controller.ChaseTarget = hit.transform;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
