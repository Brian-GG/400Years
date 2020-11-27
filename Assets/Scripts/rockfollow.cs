using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*  This script controlls when the camera will switch to follow the rock during the ending of the game
*  
* Script: rockfollow
* @author  Brian Grigore and Greg Wang
* @version 1.0
* @since   2020-01-12
*/

public class rockfollow : MonoBehaviour
{

    
    
    [SerializeField] private GameObject maincam = null; //imports main camera
    [SerializeField] private GameObject rockcam = null; // imports rock camera

    /**
    * Description: switches between cameras to follow a different object
    * Pre-condition: the two trigger colliders must collide
    * Post-condition: the game will switch between cameras
    * @param Collider2D col
    * @return none
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hit first collider");
        rockcam.SetActive(true); //enables rock camera
        maincam.SetActive(false); // disables main camera
        

    }




}
