using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LaserManager : GameManagerr
{
    public GameObject laser;
    public int laser_each_round;
    public float spawning_time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public void Update()
    {
        realtime+=Time.deltaTime*1f;
        if(realtime>=spawning_time)
        {
            realtime=0;
            spawn_laser();
        }
    }

    void spawn_laser()
    {   
        for(int i=0; i<laser_each_round;i++)
        {
            Vector3 random_pos=new Vector3(0,Random.Range(-4f,4f),0);
            Quaternion angle= Quaternion.Euler(0,0,Random.Range(0f,360f));
            StartCoroutine(start_laser(random_pos,angle));
        }

    }

    IEnumerator  start_laser(Vector3 random_pos, Quaternion angle)
    {
        GameObject laser_beam=Instantiate(laser,random_pos,angle);     
        yield return new WaitForSeconds(1.5f);
        laser_beam.GetComponent<BoxCollider2D>().enabled=true;
        laser_beam.GetComponent<SpriteRenderer>().color= new Color(1,1,1,1f); 
        Destroy(laser_beam,0.5f);
    }
}
