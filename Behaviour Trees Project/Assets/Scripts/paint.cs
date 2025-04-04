using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class paint : MonoBehaviour
{
    public LayerMask badPaint;
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

        if (timer > 1)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.3f, badPaint);

            if (colliders.Length > 0)
            {
                Destroy(gameObject);
            }


        }

        
    }
}
