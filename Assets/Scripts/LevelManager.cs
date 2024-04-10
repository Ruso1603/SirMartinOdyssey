using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int level;

    [Header("Player")]
    public Transform player;
    public Stats stats;
    public Transform playerPivot;

    [Header("Character points")]
    public Transform characterPoint01;

    [Header("Flags")]
    public Flag flag01;
    public Flag flag02;
    public Flag flag03;
    public Flag flag04;

    [Header("Sensors")]
    public Sensor sensor01;

    [Header("Switches")]
    public Switch switch01;
    public Switch switch02;
    public Switch switch03;
    public Switch switch04;
    public Switch switch05;
    public Switch switch06;
    public Switch switch07;
    public Switch switch08;

    [Header("Doors")]
    public Door door01;
    public Door door02;
    public Door door03;
    public Door door04;
    public Door door05;
    public Door door06;
    public Door door07;
    public Door door08;

    [Header("Lights")]
    public Transform light01;
    public Transform light02;
    public Transform light03;
    public Transform light04;
    public Transform light05;


    [Header("Rotating walls")]
    public RotatingWall rotatingWall01;
    public RotatingWall rotatingWall02;
    public RotatingWall rotatingWall03;
    public RotatingWall rotatingWall04;
    public RotatingWall rotatingWall05;

    // public PlayableDirector sequence01;


    // 0 Normal play
    // 1 Puzzle minigame
    public int state;

    public float timer;
    public float totalTime;


    // Start is called before the first frame update
    void Start()
    {

        // Set initial position
        
        player.position = characterPoint01.position;
        playerPivot.rotation = characterPoint01.rotation;

        PlayerPrefs.SetInt("LastLevel", level);
        PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
        if(level == 1)
        {
            ///////////////////
            // Level 1 logic //
            ///////////////////

            if (state == 0)
            {
                // Todavía no hemos empezado el minijuego
                if(sensor01.presence)
                {
                    // Arrancamos el minijuego
                    timer = 120;
                    totalTime = 120;
                    state = 1;
                }
            }
            else if(state == 1)
            {
                // Estamos en el minijuego


                timer = timer - Time.deltaTime;

                if (switch01.on)
                {
                    rotatingWall01.facing = 3;
                }

                if (switch02.on)
                {
                    rotatingWall02.facing = 3;
                }

                if (switch03.on)
                {
                    rotatingWall03.facing = 1;
                }

                if (switch04.on)
                {
                    rotatingWall04.facing = 1;
                }

                if (switch05.on)
                {
                    rotatingWall05.facing = 3;
                }

                if( flag01.isUp &&
                    flag02.isUp &&
                    flag03.isUp &&
                    flag04.isUp )
                {
                    SceneManager.LoadScene(2);
                }

                if(timer <= 0)
                {
                    SceneManager.LoadScene(0);
                }

                if(stats.hearts <= 0)
                {
                    SceneManager.LoadScene(0);
                }



            }

            if (Input.GetKeyDown(KeyCode.F9))
            {
                SceneManager.LoadScene(2);
            }
        }
        else if(level == 2)
        {
            ///////////////////
            // Level 2 logic //
            ///////////////////

            if (switch01.on)
            {
                door02.opened = true;
            }

            if (switch02.on)
            {
                door01.opened = true;
                light02.gameObject.SetActive(true);
            }

            if (switch06.on &&
                (switch03.on == true && switch04.on == false && switch05.on == true ||
                 switch03.on == false && switch04.on == true && switch05.on == true))
            {
                door04.opened = true;
                door06.opened = true;
                light05.gameObject.SetActive(true);
            }
            else if(switch06.on)
            {
                switch06.on = false;
            }

            if(switch07.on)
            {
                door08.opened = true;
                light04.gameObject.SetActive(true);
            }

            if (switch08.on)
            {
                door03.opened = true;
                light03.gameObject.SetActive(true);
                light01.gameObject.SetActive(true);
                sensor01.gameObject.SetActive(true);
            }

            if(sensor01.presence)
            {
                SceneManager.LoadScene(0);
            }


            if (stats.hearts <= 0)
            {
                SceneManager.LoadScene(0);
            }

            if (Input.GetKeyDown(KeyCode.F9))
            {
                SceneManager.LoadScene(0);
            }
        }


    }
}
