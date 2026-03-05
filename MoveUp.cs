using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 0.001f; 
    public float timeToMove = 1.0f; 
    private float timer = 0.0f; 
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime; 
        gameObject.transform.localPosition += new Vector3(0f, speed* Time.deltaTime, 0f);
        if (timer >= timeToMove)
        {
            Destroy(this.gameObject);
        }
    }
}
