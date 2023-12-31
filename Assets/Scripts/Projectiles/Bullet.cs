using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    GameObject shot_bullet;
    public GameObject[] spawning_spots_left;
    public GameObject[] spawning_spots_right;
    public GameObject[] spawning_spots_up;
    public GameObject[] spawning_spots_down;
    public float spawning_time,realtime=0;

    public float bullet_speed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        realtime+=Time.deltaTime*1f;

        if(realtime>=spawning_time)
        {
            realtime=0;

            foreach(GameObject spot in spawning_spots_left)
            {
                Quaternion angle=Quaternion.Euler(0,0,Random.Range(-45,-135));
                shot_bullet= Instantiate(bullet,spot.transform.position,angle);
                shot_bullet.GetComponent<Rigidbody2D>().AddForce(angle*Vector2.up*bullet_speed,ForceMode2D.Impulse);
            }

            foreach(GameObject spot in spawning_spots_right)
            {
                Quaternion angle=Quaternion.Euler(0,0,Random.Range(45,135));
                shot_bullet= Instantiate(bullet,spot.transform.position,angle);
                shot_bullet.GetComponent<Rigidbody2D>().AddForce(angle*Vector2.up*bullet_speed,ForceMode2D.Impulse);
            }
            
            foreach(GameObject spot in spawning_spots_up)
            {
                Quaternion angle=Quaternion.Euler(0,0,Random.Range(135,225));
                shot_bullet= Instantiate(bullet,spot.transform.position,angle);
                shot_bullet.GetComponent<Rigidbody2D>().AddForce(angle*Vector2.up*bullet_speed,ForceMode2D.Impulse);
            }
            
            foreach(GameObject spot in spawning_spots_down)
            {
                Quaternion angle=Quaternion.Euler(0,0,Random.Range(-45,45));
                shot_bullet= Instantiate(bullet,spot.transform.position,angle);
                shot_bullet.GetComponent<Rigidbody2D>().AddForce(angle*Vector2.up*bullet_speed,ForceMode2D.Impulse);
            }
        }
    }
}
