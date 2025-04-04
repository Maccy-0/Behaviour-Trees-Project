using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class FishAT : ActionTask {

        public BBParameter<GameObject> bobber;
		int state; //0 = thrown, 1 = pulled back;
		public float throwSpeed;
		public float pullSpeed;

		public GameObject player;
		public GameObject enemy;
		public playerBrush playerCode;
        public BBParameter<int> stolen;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (state == 0) 
			{
                bobber.value.transform.Translate(new Vector3(0, 0, throwSpeed * Time.deltaTime));
				if (bobber.value.transform.position.x < -9)
				{
					state = 1;
				}
            }
            if (state == 1)
            {
                bobber.value.transform.Translate(new Vector3(0, 0, -pullSpeed * Time.deltaTime));
                if (bobber.value.transform.position.x > 9)
                {
					bobber.value.transform.position = new Vector3(9, bobber.value.transform.position.y, bobber.value.transform.position.z);
                    state = 0;
					EndAction(true);
                }
            }


            if (Vector3.Distance(bobber.value.transform.position, player.transform.position) < 1)
            {
				Debug.Log("Got you!");
				player.transform.position = bobber.value.transform.position;
				playerCode.stolen = true;
				stolen.value = 1;
            }

            if (Vector3.Distance(bobber.value.transform.position, enemy.transform.position) < 1)
            {
                Debug.Log("Got him!");
                enemy.transform.position = bobber.value.transform.position;
            }


            /* To do here:
			 * Make it so it detects when they are no longer caught to start everything again (In stolenCT)
			 */
        }

		//Called when the task is disabled.
		protected override void OnStop() {
            playerCode.stolen = false;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}