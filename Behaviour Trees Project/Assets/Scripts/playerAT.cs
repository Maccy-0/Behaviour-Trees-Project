using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Net;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class playerAT : ActionTask {

        public BBParameter<Vector3> currentGoal;
		public GameObject player;
		float extensionLength = 3;

        public BBParameter<MateralData> Materals;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            Vector3 direction = (player.transform.position - agent.transform.position).normalized;


            currentGoal.value = player.transform.position + direction * extensionLength;

            Materals.value.enemyRenderer.material = Materals.value.Orange;

            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}