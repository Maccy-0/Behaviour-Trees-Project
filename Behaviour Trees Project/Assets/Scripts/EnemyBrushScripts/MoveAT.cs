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
            targetPosition = currentGoal.value;
            duration = Vector3.Distance(agent.transform.position, currentGoal.value);
            //startingPosition.position = agent.transform.position;
            timeElapsed = 0f;


            /* Save for later. Might have been crazy when writing this
            timeSinceLastDirectionChange += Time.deltaTime;
            if (timeSinceLastDirectionChange > wanderDirectionChangeFrequency)
            {
                randomPoint = Random.insideUnitCircle.normalized;
                timeSinceLastDirectionChange = 0f;
                currentAccelerationDirection = new Vector3(randomPoint.x, agent.transform.position.y, randomPoint.y);
            }
            Debug.DrawLine(agent.transform.position, currentAccelerationDirection + agent.transform.position);
            acceleration.value += currentAccelerationDirection.normalized * Time.deltaTime * accelerationStrength;
            EndAction(true);
            */
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            if (stolen)
            {
                EndAction(false);
            }

            //if (timeElapsed < duration)
            //Debug.Log(arcOffset);
            //agent.transform.position += new Vector3(arcOffset, 0, 0);

            //agent.transform.position = currentPosition;
            //}
            timeElapsed += Time.deltaTime;

            float y = timeElapsed / duration;

            float arcOffset = (Mathf.Sin(y * Mathf.PI) * arcHeight);

            agent.transform.LookAt(currentGoal.value);
            agent.transform.Translate(Vector3.forward * 1 * Time.deltaTime);
            agent.transform.Translate(Vector3.right * arcOffset * Time.deltaTime);

            if (Vector3.Distance(agent.transform.position, currentGoal.value) < 2)
            {
                EndAction(true);
            }
            if (timeElapsed > 8)
            {
                EndAction(true);
            }


            RaycastHit hit;
            Ray ray = new Ray(agent.transform.position, Vector3.down);
            Physics.Raycast(ray, out hit, Mathf.Infinity, myPaint);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity, myPaint))
            {
                
            }
            else
            {
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