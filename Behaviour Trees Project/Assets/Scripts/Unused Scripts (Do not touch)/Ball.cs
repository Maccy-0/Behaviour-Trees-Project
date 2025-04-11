using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(ballKick());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ballKick()
    {
        this.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(1f, 5f), -7.5f);
        rb.velocity = new Vector3(0f, 0f, Random.Range(5f, 15f));

        yield return new WaitForSeconds(4f);

        StartCoroutine(ballKick());

        yield return null;
    }
}
