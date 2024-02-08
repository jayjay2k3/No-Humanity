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
                    velocity=base_velocity;
                    break;

                
               
                case TouchPhase.Moved:
                   
                    Vector3 new_pos=Camera.main.ScreenToWorldPoint(current_touch.position) - startPos;
                    if(velocity<=1.5f)
                    {
                        velocity+=0.5f*Time.deltaTime;
                    }
                    transform.position= Vector3.MoveTowards(transform.position,new_pos*velocity,0.8f);
                    
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
