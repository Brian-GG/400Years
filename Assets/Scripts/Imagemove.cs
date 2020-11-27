using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*  This script controls the movement of the airplane image in the end screen scene by updating it's coordinate positon.
*  
* Script: Imagemove
* @author  Brian Grigore and Greg Wang
* @version 1.0
* @since   2020-01-12
*/

public class Imagemove : MonoBehaviour
{
    Vector3 tempPos; //gets the current coordinates of the image

    /**
    * Description: when the scene starts, get the position of the game object
    * Pre-condition: the game object must be active and the scene must be active
    * Post-condition: the image will move as long as the scene is active
    * @param none
    * @return none
    */
    void Start()
    {
        Vector3 tempPos = transform.position; // get current position at start
        
    }

    // Update is called once per frame
    // every frame the game object will move 5 units in the positive x direction
    void FixedUpdate()
    {

        tempPos.y = 693; //sets new y
        tempPos.x += 5f; //sets new x
        transform.position = tempPos; // loads new coordinates to image
    }
}
