using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 touchPos;
    public Rigidbody2D rb;
    public Vector3 dir;
    public float speed;
    private Touch current_touch;
    Vector3 startPos;
    float sinTime;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {    
            current_touch=Input.GetTouch(0);
            switch(current_touch.phase)
            {
                case TouchPhase.Began:
                    startPos= Camera.main.ScreenToWorldPoint(current_touch.position)-transform.position;
                    break;

                case TouchPhase.Moved:
                    Vector3 new_pos=Camera.main.ScreenToWorldPoint(current_touch.position)- startPos;
                    sinTime+=Time.deltaTime*speed;
                    sinTime=Mathf.Clamp(sinTime,0,Mathf.PI);
                    float t= Evaluate(sinTime);
                    transform.position= Vector3.Lerp(startPos,new Vector3(new_pos.x,new_pos.y,0),t);
                    
                    break;
                
                
            }
        }
    }
   
    float Evaluate(float x)
    {
        return 0.5f*Mathf.Sin(x-Mathf.PI/2f) +0.5f;
    }

}
