using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public LevelManager levelManager;

    public Inventory inventory;
    public Stats stats;

    public bool isHomeScreen;

    public Animator menuHomeAnimator;
    public Animator menuOptionsAnimator;
    public Animator menuMessageAnimator;
    public Animator menuHUDAnimator;
    public Animator menuPauseAnimator;
    public Animator menuInventoryAnimator;

    // 0 Home
    // 1 Options
    // 2 Message
    // 3 HUD
    // 4 Pause
    // 5 Inventory
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

    [Header("Inventory")]

    public TextMeshProUGUI armorText;
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI swordText;

    public TextMeshProUGUI heartsText;
    public TextMeshProUGUI cubesText;

    public Transform inventoryPreview;
    public Transform inventoryPreviewArmorNormal;
    public Transform inventoryPreviewArmorPower;
    public Transform inventoryPreviewArmorMagic;
    public Transform inventoryPreviewShieldNormal;
    public Transform inventoryPreviewShieldPower;
    public Transform inventoryPreviewShieldMagic;
    public Transform inventoryPreviewSwordNormal;
    public Transform inventoryPreviewSwordPower;
    public Transform inventoryPreviewSwordMagic;

    // Options

    int comingFromMenu;


    // Start is called before the first frame update
    void Start()
    {
        if (isHomeScreen)
        {
            // Estamos en la pantalla de inicio: Abrimos el men� home

            menu = 0;

            menuHomeAnimator.SetBool("BoolShowing", true);
            menuOptionsAnimator.SetBool("BoolShowing", false);
            menuMessageAnimator.SetBool("BoolShowing", false);
            menuHUDAnimator.SetBool("BoolShowing", false);
            menuPauseAnimator.SetBool("BoolShowing", false);
            menuInventoryAnimator.SetBool("BoolShowing", false);

            inventoryPreview.gameObject.SetActive(false);

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
            menuInventoryAnimator.SetBool("BoolShowing", false);

            inventoryPreview.gameObject.SetActive(false);

            Time.timeScale = 1;
        }

        musicSlider.value = AudioListener.volume;

        // Esto sirve para que el jugador no pueda sacar el 
        // cursor del rat�n de la ventana
        Cursor.lockState = CursorLockMode.Confined;


    }

    // Update is called once per frame
    void Update()
    {
        // Codigo de test
        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    menu = 0;
        //}
        //else if (Input.GetKeyDown(KeyCode.F2))
        //{
        //    menu = 1;
        //}
        //else if (Input.GetKeyDown(KeyCode.F3))
        //{
        //    menu = 2;
        //}

        if (menu == 0)
        {
            // Estamos en HOME

            menuHomeAnimator.SetBool("BoolShowing", true);
            menuOptionsAnimator.SetBool("BoolShowing", false);
            menuMessageAnimator.SetBool("BoolShowing", false);
            menuHUDAnimator.SetBool("BoolShowing", false);
            menuPauseAnimator.SetBool("BoolShowing", false);
            menuInventoryAnimator.SetBool("BoolShowing", false);

            inventoryPreview.gameObject.SetActive(false);

        }
        else if (menu == 1)
        {
            // Estamos en OPTIONS

            menuHomeAnimator.SetBool("BoolShowing", false);
            menuOptionsAnimator.SetBool("BoolShowing", true);
            menuMessageAnimator.SetBool("BoolShowing", false);
            menuHUDAnimator.SetBool("BoolShowing", false);
            menuPauseAnimator.SetBool("BoolShowing", false);
            menuInventoryAnimator.SetBool("BoolShowing", false);

            inventoryPreview.gameObject.SetActive(false);

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
            menuInventoryAnimator.SetBool("BoolShowing", false);

            inventoryPreview.gameObject.SetActive(false);

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
            menuInventoryAnimator.SetBool("BoolShowing", false);

            inventoryPreview.gameObject.SetActive(false);

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

            // Miramos si hay que cambiar de men�

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menu = 4;
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                menu = 5;
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
            menuInventoryAnimator.SetBool("BoolShowing", false);

            inventoryPreview.gameObject.SetActive(false);

            Time.timeScale = 0;
        }
        else if(menu == 5)
        {
            // Estamos en INVENTORY

            menuHomeAnimator.SetBool("BoolShowing", false);
            menuOptionsAnimator.SetBool("BoolShowing", false);
            menuMessageAnimator.SetBool("BoolShowing", false);
            menuHUDAnimator.SetBool("BoolShowing", false);
            menuPauseAnimator.SetBool("BoolShowing", false);
            menuInventoryAnimator.SetBool("BoolShowing", true);

            inventoryPreview.gameObject.SetActive(true);

            // Actualizamos textos para que coincidan con el inventario

            if (inventory.body == 0)
            {
                armorText.text = "Normal";

            }
            else if (inventory.body == 1)
            {
                armorText.text = "Power";
            }
            else
            {
                armorText.text = "Magic";
            }

            if (inventory.shield == 0)
            {
                shieldText.text = "Normal";
            }
            else if (inventory.shield == 1)
            {
                shieldText.text = "Power";
            }
            else
            {
                shieldText.text = "Magic";
            }

            if (inventory.sword == 0)
            {
                swordText.text = "Normal";
            }
            else if (inventory.sword == 1)
            {
                swordText.text = "Power";
            }
            else
            {
                swordText.text = "Magic";
            }

            // Actualizamos preview

            inventoryPreviewArmorNormal.gameObject.SetActive(false);
            inventoryPreviewArmorPower.gameObject.SetActive(false);
            inventoryPreviewArmorMagic.gameObject.SetActive(false);
            inventoryPreviewShieldNormal.gameObject.SetActive(false);
            inventoryPreviewShieldPower.gameObject.SetActive(false);
            inventoryPreviewShieldMagic.gameObject.SetActive(false);
            inventoryPreviewSwordNormal.gameObject.SetActive(false);
            inventoryPreviewSwordPower.gameObject.SetActive(false);
            inventoryPreviewSwordMagic.gameObject.SetActive(false);

            if (inventory.body == 0)
            {
                inventoryPreviewArmorNormal.gameObject.SetActive(true);

            }
            else if (inventory.body == 1)
            {
                inventoryPreviewArmorPower.gameObject.SetActive(true);
            }
            else
            {
                inventoryPreviewArmorMagic.gameObject.SetActive(true);
            }

            if (inventory.shield == 0)
            {
                inventoryPreviewShieldNormal.gameObject.SetActive(true);

            }
            else if (inventory.shield == 1)
            {
                inventoryPreviewShieldPower.gameObject.SetActive(true);
            }
            else
            {
                inventoryPreviewShieldMagic.gameObject.SetActive(true);
            }

            if (inventory.sword == 0)
            {
                inventoryPreviewSwordNormal.gameObject.SetActive(true);

            }
            else if (inventory.sword == 1)
            {
                inventoryPreviewSwordPower.gameObject.SetActive(true);
            }
            else
            {
                inventoryPreviewSwordMagic.gameObject.SetActive(true);
            }

            // Actualizamos textos para que coincidan con los stats

            heartsText.text = "" + stats.hearts;
            cubesText.text = "" + stats.cubes;

            // Miramos si hay que cambiar de men�

            if (Input.GetKeyDown(KeyCode.I))
            {
                menu = 3;
            }

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

    public void OnHomeQuit()
    {
        Application.Quit(0);
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

    public void OnInventoryContinue()
    {
        menu = 3;
    }

    public void OnInventoryArmorLeft()
    {
        inventory.body = inventory.body - 1;

        if(inventory.body < 0) { inventory.body = 0; }
    }

    public void OnInventoryArmorRight()
    {
        inventory.body = inventory.body + 1;

        if (inventory.body > 2) { inventory.body = 2; }
    }

    public void OnInventoryShieldLeft()
    {
        inventory.shield = inventory.shield - 1;

        if (inventory.shield < 0) { inventory.shield = 0; }

    }

    public void OnInventoryShieldRight()
    {
        inventory.shield = inventory.shield + 1;

        if (inventory.shield > 2) { inventory.shield = 2; }

    }

    public void OnInventorySwordLeft()
    {
        inventory.sword = inventory.sword - 1;

        if (inventory.sword < 0) { inventory.sword = 0; }
    }

    public void OnInventorySwordRight()
    {
        inventory.sword = inventory.sword + 1;

        if (inventory.sword > 2) { inventory.sword = 2; }
    }

}
