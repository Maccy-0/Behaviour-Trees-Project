using NodeCanvas.Tasks.Conditions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        if (!stolen)
        {

            RaycastHit hit;
            Ray ray = new Ray(transform.position, Vector3.down);
            Physics.Raycast(ray, out hit, Mathf.Infinity, myPaint);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, myPaint))
            {

            }
            else
            {
                UnityEngine.Object.Instantiate(paint, transform.position + new Vector3(0, -0.6f, 0), transform.rotation);
            }

        }
    }

    void OnMouseDown()
    {
        if (!stolen)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
        

    }

    void OnMouseDrag()
    {
        if (!stolen)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

}
