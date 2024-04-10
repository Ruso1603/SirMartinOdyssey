using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public LevelManager levelManager;

    public Stats stats;

    public bool isHomeScreen;

    public Animator menuHomeAnimator;
    public Animator menuOptionsAnimator;
    public Animator menuMessageAnimator;
    public Animator menuHUDAnimator;
    public Animator menuPauseAnimator;

    // 0 Home
    // 1 Options
    // 2 Message
    // 3 HUD
    // 4 Pause
    public int menu;

    [Header("HUD")]

    public Transform heart1;
    public Transform heart2;
    public Transform heart3;

    public int hearts;

    public Transform clock;
    public RectTransform clockPointer;

    public bool clockEnabled;
    public float clockProgress;


    [Header("Options")]

    public Slider musicSlider;
    public Toggle fullScreenToggle;

    [Header("Message")]

    public string message;

    public TextMeshProUGUI messageText;

    int comingFromMenu;


    // Start is called before the first frame update
    void Start()
    {
        if(isHomeScreen)
        {
            // Estamos en la pantalla de inicio: Abrimos el menú home

            menu = 0;

            menuHomeAnimator.SetBool("BoolShowing", true);
            menuOptionsAnimator.SetBool("BoolShowing", false);
            menuMessageAnimator.SetBool("BoolShowing", false);
            menuHUDAnimator.SetBool("BoolShowing", false);
            menuPauseAnimator.SetBool("BoolShowing", false);

            Time.timeScale = 0;
        }
        else
        {
            // Estamos en un nivel de juego: Abrimos el HUD
            menu = 3;

            menuHomeAnimator.SetBool("BoolShowing", false);
            menuOptionsAnimator.SetBool("BoolShowing", false);
            menuMessageAnimator.SetBool("BoolShowing", false);
            menuHUDAnimator.SetBool("BoolShowing", true);
            menuPauseAnimator.SetBool("BoolShowing", false);

            Time.timeScale = 1;
        }

        musicSlider.value = AudioListener.volume;

    }

    // Update is called once per frame
    void Update()
    {
        // Codigo de test
        if (Input.GetKeyDown(KeyCode.F1))
        {
            menu = 0;
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            menu = 1;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            menu = 2;
        }

        if (menu == 0)
        {
            // Estamos en HOME

            menuHomeAnimator.SetBool("BoolShowing", true);
            menuOptionsAnimator.SetBool("BoolShowing", false);
            menuMessageAnimator.SetBool("BoolShowing", false);
            menuHUDAnimator.SetBool("BoolShowing", false);
            menuPauseAnimator.SetBool("BoolShowing", false);

        }
        else if (menu == 1)
        {
            // Estamos en OPTIONS

            menuHomeAnimator.SetBool("BoolShowing", false);
            menuOptionsAnimator.SetBool("BoolShowing", true);
            menuMessageAnimator.SetBool("BoolShowing", false);
            menuHUDAnimator.SetBool("BoolShowing", false);
            menuPauseAnimator.SetBool("BoolShowing", false);

            AudioListener.volume = musicSlider.value;
            Screen.fullScreen = fullScreenToggle.isOn;

        }
        else if (menu == 2)
        {
            // Estamos en MESSAGE

            menuHomeAnimator.SetBool("BoolShowing", false);
            menuOptionsAnimator.SetBool("BoolShowing", false);
            menuMessageAnimator.SetBool("BoolShowing", true);
            menuHUDAnimator.SetBool("BoolShowing", false);
            menuPauseAnimator.SetBool("BoolShowing", false);

            messageText.text = message;

            Time.timeScale = 0;

        }
        else if(menu == 3)
        {
            // Estamos en HUD

            menuHomeAnimator.SetBool("BoolShowing", false);
            menuOptionsAnimator.SetBool("BoolShowing", false);
            menuMessageAnimator.SetBool("BoolShowing", false);
            menuHUDAnimator.SetBool("BoolShowing", true);
            menuPauseAnimator.SetBool("BoolShowing", false);

            // Actualizamos corazones

            hearts = stats.hearts;

            if (hearts >= 1) { heart1.gameObject.SetActive(true); }
            else { heart1.gameObject.SetActive(false); }

            if (hearts >= 2) { heart2.gameObject.SetActive(true); }
            else { heart2.gameObject.SetActive(false); }

            if (hearts >= 3) { heart3.gameObject.SetActive(true); }
            else { heart3.gameObject.SetActive(false); }

            // Actualizamos reloj

            if (levelManager.state == 1)
            {
                clockEnabled = true;
                clockProgress = levelManager.timer / levelManager.totalTime;
            }
            else
            {
                clockEnabled = false;
            }

            if (clockEnabled)
            {
                clock.gameObject.SetActive(true);
                clockPointer.rotation = Quaternion.Euler(0, 0, -clockProgress * 360.0f);
            }
            else
            {
                clock.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menu = 4;
            }

            Time.timeScale = 1;
        }
        else if(menu == 4)
        {
            // Estamos en PAUSE

            menuHomeAnimator.SetBool("BoolShowing", false);
            menuOptionsAnimator.SetBool("BoolShowing", false);
            menuMessageAnimator.SetBool("BoolShowing", false);
            menuHUDAnimator.SetBool("BoolShowing", false);
            menuPauseAnimator.SetBool("BoolShowing", true);


            Time.timeScale = 0;
        }

    }

    public void OnHomeNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnHomeContinue()
    {
        int level;

        level = PlayerPrefs.GetInt("LastLevel", 1);

        SceneManager.LoadScene(level);
    }

    public void OnHomeOptions()
    {
        comingFromMenu = 0;
        menu = 1;
    }

    public void OnOptionsOk()
    {
        if(comingFromMenu == 0)
        {
            menu = 0;
        }
        else
        {
            menu = 4;
        }
    }

    public void OnPauseContinue()
    {
        menu = 3;
    }

    public void OnPauseOptions()
    {
        comingFromMenu = 4;
        menu = 1;
    }

    public void OnPauseExit()
    {
        SceneManager.LoadScene(0);
    }



}
