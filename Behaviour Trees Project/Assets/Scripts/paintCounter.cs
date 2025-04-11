using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SceneManagement;

public class paintCounter : MonoBehaviour
{
    public TMP_Text counterText;
    public float bluePaint;
    public float redPaint;
    public float bluePaintMax;
    private string redTag = "RedPaint";
    private string blueTag = "BluePaint";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] redObjects = GameObject.FindGameObjectsWithTag(redTag);
        redPaint = redObjects.Length;

        GameObject[] blueObjects = GameObject.FindGameObjectsWithTag(blueTag);
        bluePaint = blueObjects.Length;

        if (bluePaint > bluePaintMax)
        {
            bluePaintMax = bluePaint;
        }

        counterText.text = "Highscore: " + bluePaintMax.ToString() + "\nBlue Paint: " + bluePaint.ToString() + "\nRed Paint: " + redPaint.ToString();
    }
}
