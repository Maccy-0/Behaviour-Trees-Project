using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class paint : MonoBehaviour
{
    //Script for both types of paint on the ground

    public LayerMask badPaint; //This changes based on which team it's a part of
    float timer;

    // Start is called before the first frame update
    void Start()
    {

        timer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        

        timer += Time.deltaTime;
        //We check for a timer so that recently placed paint will stay and the old will be destroyed
        if (timer > 1)
        {
            //Check it it's touching the other color of paint
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.3f, badPaint);

            if (colliders.Length > 0)
            {
                //If there is, destroy itself
                Destroy(gameObject);
            }


        }

        
    }
}
