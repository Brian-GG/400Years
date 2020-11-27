using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*  This script controls the movement of the "the end" text in the end screen scene by updating it's coordinate positon.
*  
* Script: Textmove
* @author  Brian Grigore and Greg Wang
* @version 1.0
* @since   2020-01-12
*/

public class Textmove : MonoBehaviour
{
    Vector3 tempPos;//defines current coordinates of text
    // Start is called before the first frame update
    void Start()
    {
        Vector3 tempPos = transform.position; //gets current text coordinates
        
        

    }


    /**
    * Description: when the scene starts, get the position of the game object
    * Pre-condition: the game object must be active and the scene must be active
    * Post-condition: the text will move by 5 in positive x until it reaches the middle of the screen
    * @param none
    * @return none
    */
    //update happens once per frame
    void FixedUpdate()
    {
        if (tempPos.x < 1100f)//unitl reached middle of screen
        {
            tempPos.y = 693;//sets y
            tempPos.x += 5f;//sets x
            transform.position = tempPos;//sends to object

        }
       
    }
}
