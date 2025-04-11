using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class RunAT : ActionTask {

        public BBParameter<Transform> ball;
        public BBParameter<Transform> goalie;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            goalie.value.transform.LookAt(ball.value);
            goalie.value.transform.position = Vector3.MoveTowards(goalie.value.transform.position, ball.value.position, 5 * Time.deltaTime);
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