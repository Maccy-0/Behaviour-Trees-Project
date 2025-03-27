using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


namespace NodeCanvas.Tasks.Actions {


	public class PaintAT : ActionTask {

		public Texture2D canvasTexture;
		public Color myColor = Color.red; //Red only for testing

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{

			RaycastHit hit;
			Ray ray = new Ray(agent.transform.position + Vector3.down, Vector3.down);

			if (Physics.Raycast(ray, out hit))
			{
				Vector3 paintPoint = hit.textureCoord;
                Vector2 brushPosition = new Vector2(paintPoint.x * canvasTexture.width, paintPoint.y * canvasTexture.height);

                int xStart = Mathf.FloorToInt(brushPosition.x - 1 * canvasTexture.width);
                int yStart = Mathf.FloorToInt(brushPosition.y - 1 * canvasTexture.height);
                int xEnd = Mathf.FloorToInt(brushPosition.x + 1 * canvasTexture.width);
                int yEnd = Mathf.FloorToInt(brushPosition.y + 1 * canvasTexture.height);


                for (int x = xStart; x < xEnd; x++)
                {
                    for (int y = yStart; y < yEnd; y++)
                    {
                        if (x >= 0 && x < canvasTexture.width && y >= 0 && y < canvasTexture.height)
                        {
                            canvasTexture.SetPixel(x, y, myColor);
                        }
                    }
                }
                canvasTexture.Apply(); 
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