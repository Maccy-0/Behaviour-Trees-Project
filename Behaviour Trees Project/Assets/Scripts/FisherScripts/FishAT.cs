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
		public GameObject enemy1; //You know I wish I found a way to make this addaptive like everything else
        public GameObject enemy2;
        public GameObject enemy3;
        public GameObject enemy4;
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
            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			//Checking state to know if it's going forward or back
			if (state == 0) 
			{
				//Moves the bobber forward
                bobber.value.transform.Translate(new Vector3(0, 0, throwSpeed * Time.deltaTime));
				//Checks if it has 'hit' the wall
				if (bobber.value.transform.position.x < -9)
				{
					state = 1;
				}
            }
            if (state == 1)
            {
                //Pulls the bobber back
                bobber.value.transform.Translate(new Vector3(0, 0, -pullSpeed * Time.deltaTime));
                //Checks if it has been pulled fully back
                if (bobber.value.transform.position.x > 9)
                {
					//Resets the position incase it's off because of frames
					bobber.value.transform.position = new Vector3(9, bobber.value.transform.position.y, bobber.value.transform.position.z);
                    state = 0;
					EndAction(true);
                }
            }

			//Sees if the player is touching the bobber
            if (Vector3.Distance(bobber.value.transform.position, player.transform.position) < 1)
            {
				//Steals it
				player.transform.position = bobber.value.transform.position;
				//This is so the player knows it has been stolen on it's script
				playerCode.stolen = true;
				stolen.value = 1;
            }

            //Sees if the enemies are touching the bobber
            if (Vector3.Distance(bobber.value.transform.position, enemy1.transform.position) < 1)
            {
                //Steals it
                enemy1.transform.position = bobber.value.transform.position;
            }

            //Sees if the enemies are touching the bobber
            if (Vector3.Distance(bobber.value.transform.position, enemy2.transform.position) < 1)
            {
                //Steals it
                enemy2.transform.position = bobber.value.transform.position;
            }

            //Sees if the enemies are touching the bobber
            if (Vector3.Distance(bobber.value.transform.position, enemy3.transform.position) < 1)
            {
                //Steals it
                enemy3.transform.position = bobber.value.transform.position;
            }

            //Sees if the enemies are touching the bobber
            if (Vector3.Distance(bobber.value.transform.position, enemy4.transform.position) < 1)
            {
                //Steals it
                enemy4.transform.position = bobber.value.transform.position;
            }

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