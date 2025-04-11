using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Drawing;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CloseCT : ConditionTask {

		public GameObject player;
		public float detectionRadius;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			//Just checks if the brush (not the mouse) is in the radius around the enemy
            if (Vector3.Distance(agent.transform.position, player.transform.position) < detectionRadius)
            {
				return false;
            }

            return true;
		}
	}
}