using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UIElements;

namespace NodeCanvas.Tasks.Actions {

	public class ChargeAT : ActionTask {

		float currRotate;
		float stopWatch;
		public float speed;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//Starting rotation
            currRotate = -90;
			stopWatch = 0;

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			stopWatch += Time.deltaTime;
			currRotate = -90 + stopWatch * speed;

			//Spins it around the main object based on how much time has passed and the speed
			agent.transform.rotation = Quaternion.Euler(0, currRotate, 0);
			//Becuase it starts at -90 it caps out at 270. So we have picked 265 to be safe to not pass over with how quick it's moving. 
			if (currRotate >= 265)
			{
				agent.transform.rotation = Quaternion.Euler(0, -90, 0); ;
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}