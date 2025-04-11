using NodeCanvas.Tasks.Conditions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class playerBrush : MonoBehaviour
{
    public GameObject paint;
    public LayerMask myPaint;

    Vector3 screenPoint;
    Vector3 offset;

    public bool stolen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This checks if the fisherman has taken the brush. We do this because otherwise you could just hold onto it and the fisher could do nothing as it would snap back.
        if (!stolen)
        {
            //Looks at what is under it
            RaycastHit hit;
            Ray ray = new Ray(transform.position, Vector3.down);
            Physics.Raycast(ray, out hit, Mathf.Infinity, myPaint);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, myPaint))
            {
                //If there is paint, we don't put more. Even if it would look better to not do this, we don't want to crash the game spawning a paint every frame
            }
            else
            {
                //Spawns the paint
                UnityEngine.Object.Instantiate(paint, transform.position + new Vector3(0, -0.6f, 0), transform.rotation);
            }

        }
    }

    void OnMouseDown()
    {
        if (!stolen)
        {
            //Looks at where the mouse is compared to the object when clicked
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
        

    }

    void OnMouseDrag()
    {
        if (!stolen)
        {
            //Moves the object with the mouse
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            //This makes it so you can't move the object beond the boarders of the box. Overriding the above code.
            curPosition.x = Mathf.Clamp(curPosition.x, -9, 9);
            curPosition.z = Mathf.Clamp(curPosition.z, -9, 9);
            transform.position = curPosition;
        }
    }

}
