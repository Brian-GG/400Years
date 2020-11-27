using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /**
    *  This script is here to make the camera and the background follow
    *  the player wherever he/she is 
    * 
    * Script:  Follow_player
    * @author  Greg Wang and Brian Grigore
    * @version 1.0
    * @since   2020-01-05
    */
//Declare that we need stuff like the player, camera speed and the X and Y offset
public class Follow_Player : MonoBehaviour
{
    
    public GameObject PlayerObject;

    public float speed = 3.0f;

    [SerializeField] public float X_Offset = 10;

    [SerializeField] public float Y_Offset = 0;


    /**
      * Description: Checks where the player is and then moves the object this script
      * is attached to the player with a bit of offset
      * Pre-condition: The player must exist and this script must be attached to the object 
      * that wants to follow the player
      * Post-condition: This object will follow the player
      * @param none
      * @return none
      */
    void Update()
    {
        //Calculate the velocity of this object
        float velocity = speed * Time.deltaTime;

        Vector3 position = this.transform.position;

        //Special case for the opening sequence
        if(position.x > -6 && position.x < 5)
        {
            Y_Offset = 3;
            speed = 0.8f;
        }
        //Else the offset is normal and so is the speed
        else
        {
            Y_Offset = 0;
            speed = 3f;
        }

        //Sends this object to the desired location with Mathf.Lerp
        position.y = Mathf.Lerp(this.transform.position.y, PlayerObject.transform.position.y + Y_Offset, velocity);

        position.x = Mathf.Lerp(this.transform.position.x, PlayerObject.transform.position.x + X_Offset, velocity);

        this.transform.position = position;
    }
}
