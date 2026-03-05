using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseClick : MonoBehaviour
{
    public float timer = 60.0f; // 限時60秒
    public ControlledCharacter controlledCharacter; 

    public TextMeshPro timerText; 
    public GameObject Button; 

    private bool start = true; 
    private int touchStatus = 0;
    


    // Update is called once per frame
    void Update()
    {
       
        if (touchStatus == 0 && Input.touchCount > 0)
            touchStatus = 1;
        if (touchStatus == 1 && Input.touchCount == 0)
            touchStatus = 2;


        timerText.text = timer.ToString("F1"); 
        if (Input.GetMouseButtonDown(0) || touchStatus==2)
        {
            touchStatus = 0;
            controlledCharacter.Drink(); 
        }
       
        /*if (timer <= 0)
        {
            start = false;
            timerText.text = "0"; 
            Button.SetActive(true); // Hide 
        }
        */
    }
    public void ResetTimer()
    {
        timer = 60.0f; 
        start = true; 
        timerText.text = timer.ToString("F1"); 
        Button.SetActive(false); // Hide the button
        controlledCharacter.ResetCharacter();
    }
}
