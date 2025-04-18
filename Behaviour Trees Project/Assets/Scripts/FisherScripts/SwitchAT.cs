using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SwitchAT : ActionTask {

        public BBParameter<Transform> currentPoint;
		public Transform point1;
        public Transform point2;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//There are 2 points in the scene
			//If this node activates that means the fisher has reached a node and needs to switch to the othere

			//So if looks at the current point, and then sets the other one as the new current point
			if (currentPoint.value == point1)
			{
				currentPoint.value = point2;

            }
			else
			{
                if (currentPoint.value == point2)
                {
					currentPoint.value = point1;
                }
            }
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