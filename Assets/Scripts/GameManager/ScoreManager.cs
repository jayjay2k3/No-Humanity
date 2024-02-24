using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI high_score;

    public TextMeshProUGUI score_end_game;
    public GameObject retry_canvas;
    public bool stop;
    float time=0;

    public LaserManager laserManager;
    public BulletManager bulletManager;

    public GameObject character;

    
    void Awake() 
    {
        if(SceneManager.GetActiveScene().name=="GameScene")
        {
            update_high_score();
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop && SceneManager.GetActiveScene().name=="GameScene")
        {
            time+=1f*Time.deltaTime;
            score.text=time.ToString("0.00");
        }
        
    }


    void update_high_score()
    {
        high_score.text= PlayerPrefs.GetFloat("high_score").ToString("0.00");
    }

    public void game_stop()
    {
        stop=true;
        if(time>PlayerPrefs.GetFloat("high_score"))
        {
            PlayerPrefs.SetFloat("high_score",time);
            PlayerPrefs.Save();
            score_end_game.color=Color.red;
        }
        else
        {
            score_end_game.color=Color.black;
        }
        score_end_game.text=score.text;
        Time.timeScale=0;
        retry_canvas.SetActive(true);
    }


    public void retry()
    {
        Bullet[] bullets;
        GameObject[]  lasers;
        GameManagerr[] gameSystems;
        bullets=FindObjectsOfType<Bullet>();
        lasers=GameObject.FindGameObjectsWithTag("Laser");
       
        gameSystems=FindObjectsOfType<GameManagerr>();

        foreach(var child in gameSystems)
        {
            child.realtime=0;
        }
        foreach( var child in bullets)
        {
            Destroy(child.gameObject);
        }

        foreach( var child in lasers)
        {
            Destroy(child.gameObject);
        }

       
       
        time=0;
        score.text=time.ToString("0.00");
        retry_canvas.SetActive(false);
        Time.timeScale=1;

        laserManager.realtime=2;
        bulletManager.realtime=0;
        character.SetActive(true);

        stop=false;
        update_high_score();
    }

    public void ToMenu()
    {
        retry();
        SceneManager.LoadScene("StartMenu");
    }
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
        
        
    }
}
