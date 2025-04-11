using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class MoveAT : ActionTask {

        public BBParameter<Vector3> currentGoal;

        //public Transform point;
        public float duration;
        public float arcHeight = 2f;

        public Transform startingPosition;
        private Vector3 targetPosition;
        private float timeElapsed;
        public GameObject paint;
        public LayerMask myPaint;
        public float speed;

        public bool stolen;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            //Sets the goal in this script as the point that another node made
            targetPosition = currentGoal.value;
            //Sees how far it needs to travel
            duration = Vector3.Distance(agent.transform.position, currentGoal.value);
            timeElapsed = 0f;
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            //Don't do anything if the fisherman has caught you
            if (stolen)
            {
                EndAction(false);
            }

            timeElapsed += Time.deltaTime;

            //Sees how far it is in it's journey
            float y = timeElapsed / duration;

            //Sees how far off it should be to match the curved approach
            float arcOffset = (Mathf.Sin(y * Mathf.PI) * arcHeight);

            //Moves the enemy forward and to the right to match the arc
            agent.transform.LookAt(currentGoal.value);
            agent.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            agent.transform.Translate(Vector3.right * (speed/2) * arcOffset * Time.deltaTime);

            //If the enemy is close to it's goal, finish the task.
            if (Vector3.Distance(agent.transform.position, currentGoal.value) < 2)
            {
                EndAction(true);
            }

            //This is a fail safe. Based on the curved nature there are numbers you can plug in that would leave it in an infinite loop
            //To prepare for this after a certain time has passed it just gives up. 
            if (timeElapsed > 8)
            {
                EndAction(true);
            }

            //Looks at what is under it
            RaycastHit hit;
            Ray ray = new Ray(agent.transform.position, Vector3.down);
            Physics.Raycast(ray, out hit, Mathf.Infinity, myPaint);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity, myPaint))
            {
                //If there is paint, we don't put more. Even if it would look better to not do this, we don't want to crash the game spawning a paint every frame
            }
            else
            {
                //Spawns the paint
                UnityEngine.Object.Instantiate(paint, agent.transform.position + new Vector3(0,-0.6f,0), agent.transform.rotation);
            }
                
        }

        //Called when the task is disabled.
        protected override void OnStop()
        {

        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}