using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {
	//dis 6
	public class NearCT : ConditionTask {

        public BBParameter<Transform> ball;
        public BBParameter<Transform> goalie;
        float balldist;

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
			balldist = Vector3.Distance(goalie.value.position, ball.value.position);

			return balldist < 6;
		}
	}
}