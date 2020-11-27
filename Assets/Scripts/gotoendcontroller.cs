using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
*  This script controls what happens when the conditions to end the game are met, using a
*  collision event between the rock and the volcano
* Script: gotoendcontroller
* @author  Brian Grigore and Greg Wang
* @version 1.0
* @since   2020-01-12
*/
public class gotoendcontroller : MonoBehaviour
{



    //imports the rock and the volcano particles objects
    [SerializeField] private GameObject transition = null;
    [SerializeField] private GameObject volcanoash = null;

    /**
    * Description: checks to see if the rock has collided with the inside of the volcano
    * Pre-condition: The rock and volcano's box collider objects must properly trigger the oncollisionenter2D event
    * Post-condition: The end game sequence and transitions will begin, then the endscreen scene will be loaded 
    * @param none
    * @return none
    */

    private void OnCollisionEnter2D (Collision2D col)
    {
        //starts the ending sequence
        StartCoroutine(rockCoroutine());    
        
    }



    /**
     * Description: ends off the game by showing the rock blocking the volcano, then enabling text with an image as a transition,
     * then loading the next scene
     * Pre-condition: The scenes must be properly loaded in the build settings and the two game objects must collide
     * Post-condition: the transition image will show and the end screen will be loaded. 
     * @param none
     * @return none
     */
    IEnumerator rockCoroutine()
    {

        Debug.Log("hit second collider");
        volcanoash.SetActive(false); //stops the volcano ash
        yield return new WaitForSeconds(3); // waits 3 seconds
        transition.SetActive(true); //begins transition
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2); // loads next scene

    }

}
