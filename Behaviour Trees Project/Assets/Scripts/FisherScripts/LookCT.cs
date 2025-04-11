using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UIElements;

namespace NodeCanvas.Tasks.Conditions {

	public class LookCT : ConditionTask {

        public LayerMask player;

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
            //Sends a raycast across the horizontal axis of the screen
            RaycastHit hit;
            Ray ray = new Ray(agent.transform.position, Vector3.left);
            Physics.Raycast(ray, out hit, Mathf.Infinity, player);

			//Says if it sees the player on that axis
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, player))
            {
				return true;
            }
            else
            {
                return false;
            }


            
		}
	}
}