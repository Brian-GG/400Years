using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
*  This script controls all the functions of the pause menu, including buttons and key input and the UI itself
*  
* Script: PauseMenu
* @author  Brian Grigore and Greg Wang
* @version 1.0
* @since   2020-01-12
*/
public class PauseMenu : MonoBehaviour
{
    


    public static bool GamePaused; //checks if the game is paused
    public GameObject PauseMenuUI; // the UI of the menu
    

    // Update is called once per frame
    /**
    * Description: enables or disables the pause menu when the key is pressed
    * Pre-condition: The pause menu must exist
    * Post-condition: the pause menu will toggle its visibilty
    * @param none
    * @return none
    */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GamePaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }



    }
    /**
    * Description: sets the parameters for when the pause menu is being disabled, such as resuming time and closing the UI 
    * Pre-condition: The game must be already paused
    * Post-condition: the game will be unpaused
    * @param none
    * @return none
    */
    public void Resume()
    {
        PauseMenuUI.SetActive(false); //disables UI
        Time.timeScale = 1f; //sets time to normal
        GamePaused = false; //sets check to false
        
    }
    /**
    * Description: sets the parameters for when the pause menu is being enabled, such as stopping time and opening the UI 
    * Pre-condition: The game must be unpasued
    * Post-condition: the game will be paused
    * @param none
    * @return none
    */
    void Pause()
    {
        PauseMenuUI.SetActive(true); //enables UI
        Time.timeScale = 0f; // freezes time
        GamePaused = true; // sets checker to true

       


    }
    /**
    * Description: Controls button that sends user to the main menu
    * Pre-condition: the main menu must be unloaded and the pause menu must be enabled
    * Post-condition: the time will be set to normal and the main menu scene will be loaded
    * @param none
    * @return none
    */
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }
    /**
    * Description: quits the application when the quit button is pressed
    * Pre-condition: the application must be running and the quit button must be active
    * Post-condition: the application will quit
    * @param none
    * @return none
    */
    public void QuitGame()
    {
        Application.Quit();
    }



}

