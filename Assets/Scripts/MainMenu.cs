using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
*  This script controls some of the buttons on the main menu screen
*  
* Script: MainMenu
* @author  Brian Grigore and Greg Wang
* @version 1.0
* @since   2020-01-12
*/
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    /**
    * Description: loads the game scene when the playgame button is clicked
    * Pre-condition: the game scene must be in the build list
    * Post-condition: the game scene will load
    * @param none
    * @return none
    */
    public void PlayGame()
    { 

        SceneManager.LoadScene(1); // loads the game scene
        

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
        Debug.Log("Quit!");
        Application.Quit(); //quits the application
    }

}
