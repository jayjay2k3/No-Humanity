using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteManager : GameManagerr
{
    public GameObject meteorite;
    GameObject shot_bullet;
    public GameObject warningSign;
    public GameObject[] spawning_spots;
    public float spawning_time;

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public void Update()
    {
        realtime+=Time.deltaTime*1f;
        if(realtime>=spawning_time-1.5f)
        {
            warningSign.SetActive(true);
        }
        if(realtime>=spawning_time)
        {
            realtime=0;
            warningSign.SetActive(false);
            spawn_bullet();
        }
    }

    void spawn_bullet()
    {
        foreach(GameObject spot in spawning_spots)
            {
                int random= Random.Range(0,2);
                if(random==0)
                {
                    continue;
                }
                else
                {
                    shot_bullet=Instantiate(meteorite,spot.transform.position,Quaternion.identity);
                    shot_bullet.GetComponent<Rigidbody2D>().velocity=Vector2.down*speed;
                }
                
                
                
            }

            
    }
}
