using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Vector3 touchPos;
    public Rigidbody2D rb;
    public Vector3 dir;
    public float speed;
    private Touch current_touch;
    Vector3 startPos;
    public float pos_diffence=1.5f;
    float velocity=1f;
    public float base_velocity;

    private float xMin, xMax;
    private float yMin, yMax;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        var spriteSize = GetComponent<SpriteRenderer>().bounds.size.x * .5f; // Working with a simple box here, adapt to you necessity

        var cam = Camera.main;// Camera component to get their size, if this change in runtime make sure to update values
        var camHeight = cam.orthographicSize;
        var camWidth = cam.orthographicSize * cam.aspect;

        yMin = -camHeight + spriteSize ; // lower bound
        yMax = camHeight - spriteSize ; // upper bound
        
        xMin = -camWidth + spriteSize; // left bound
        xMax = camWidth - spriteSize; // right bound 

        
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
                    velocity=base_velocity;
                    break;

                
                
                case TouchPhase.Moved:
                   
                    Vector2 new_pos=Camera.main.ScreenToWorldPoint(current_touch.position) - startPos;
                    if(velocity<=1.5f)
                    {
                        velocity+=0.5f*Time.deltaTime;
                    }
                    
                    Vector2 validPos;
                    validPos=new_pos*velocity;
                    if(validPos.x>=xMax)
                    {
                        validPos.x=xMax;
                    }
                    else if(validPos.x<=xMin)
                    {
                        validPos.x=xMin;
                    }

                    if(validPos.y>=yMax)
                    {
                        validPos.y=yMax;
                    }
                    else if(validPos.y<=yMin)
                    {
                        validPos.y=yMin;
                    }
                    transform.position= Vector3.MoveTowards(transform.position,validPos,0.8f);
                   
                    break;
                
                
            }
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        gameObject.transform.position= new Vector3(0,0,0);
        scoreManager.game_stop();
        
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Projectiles" || other.tag=="Laser")
        {
            Die();
        }
    }

}
