using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*  This script is used letting the player get on the boat from underneath
*  and make them stay on top of the boat
*
* Script: Boat_Script
* @author  Greg Wang and Brian Grigore
* @version 1.0
* @since   2020-01-12
*/

public class Boat_Script : MonoBehaviour
{
    //Take the top of the boat where the player will stand on and the player gameobject
    public Collider2D Boat_Top;
    public GameObject Player;


       /**
       * Description: Checks where the player is and then sees wether or not the boat should interact with them
       * Pre-condition: The player must exist and the boat should have a hitbox for the player to collide with
       * Post-condition: The boat will allow the player onto it when they come from under the boat
       * @param none
       * @return none
       */

    void Update()
    {
        //check is the player is above or below the boat
        if(Player.transform.position.y > Boat_Top.transform.position.y+6f)
        {
            //If they are above, enable the collider so the player stays on the boat
            Boat_Top.enabled = true;

        }
        else
        {
            //If not, let the player go through the boat platform
            Boat_Top.enabled = false;

        }

    }
}
