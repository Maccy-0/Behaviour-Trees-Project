using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class RadPointAT : ActionTask {

        public BBParameter<Vector3> currentGoal;
		Vector3 randomSpot;
		public LayerMask floor;

        public BBParameter<Renderer> enemyRenderer;
        public Material colour;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            RaycastHit hit;
            Ray ray = new Ray(agent.transform.position, Vector3.down);
            Physics.Raycast(ray, out hit, Mathf.Infinity, floor);

            randomSpot = new Vector3(Random.Range(-7, 7), 0, Random.Range(-7, 7));
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, floor))
            {
                currentGoal.value = randomSpot;

                enemyRenderer.value.material = colour;
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