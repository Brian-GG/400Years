using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   /**
   *  This script is used to spawn an apple once the first one is gone by deactivating the
   *  first when the player picks it up and then activating it after a certain amount of time
   * 
   * Script:  Spawn_Apple
   * @author  Greg Wang and Brian Grigore
   * @version 1.0
   * @since   2020-01-11
   */

public class Spawn_Apple : MonoBehaviour
{
    //The current time
    public Time_Storage Current_Time;

    public GameObject Player;


    //The two apple gameobjects
    public GameObject Apple1;
    public GameObject Apple2;
    
    //Whether or not the apples are grabbed
    public bool Apple1_grabbed = false;
    public bool Apple2_grabbed = false;
    
    //The respawn timers for the apples
    public float Respawn_timer1;
    public float Respawn_timer2;
    
    //The check for the player and apple
    public LayerMask whatIsPlayer;
    public LayerMask whatIsApple;
    public LayerMask whatIsApple2;

    //How long the check goes for
    public float distance = 10;



    /**
        * Description: Checks to see if the player picked up and dropped wheat or not
        * Pre-condition: The player must exist and have wheat to pick up
        * Post-condition: The bridge will be able to expand because the wheat was placed
        */
    void Update()
    {
        RaycastHit2D hitInfo1 = Physics2D.Raycast(Player.transform.position, Vector2.down, distance, whatIsApple);
        
        //Check to see if the player is right above the apple and pick it up to disable the apple
        if (hitInfo1 != null && Player.transform.position.x > 102.9 && Player.transform.position.x < 103.5)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Apple1.SetActive(false);
                Apple1_grabbed = true;
            }
        }

        //if the apple gets grabbed the timer should start for its respawn
        if(Apple1_grabbed == true)
        {
            Respawn_timer1 = Current_Time.GetYearTime() + 1000;
            Apple1_grabbed = false;
        }

        //If the current time goes over respawn timer, respawn the apple
        if(Current_Time.GetYearTime() >= Respawn_timer1)
        {
            Apple1.SetActive(true);
        }

        RaycastHit2D hitInfo2 = Physics2D.Raycast(Player.transform.position, Vector2.down, distance, whatIsApple2);

        //Check to see if the player is right above the apple and pick it up to disable the apple
        if (hitInfo2 != null && Player.transform.position.x > 315 && Player.transform.position.x < 316.1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Apple2.SetActive(false);
                Apple2_grabbed = true;
            }
        }

        //if the apple gets grabbed the timer should start for its respawn
        if (Apple2_grabbed == true)
        {
            Respawn_timer2 = Current_Time.GetYearTime() + 1000;
            Apple2_grabbed = false;
        }        
        
        //If the current time goes over respawn timer, respawn the apple
        if (Current_Time.GetYearTime() >= Respawn_timer2)
        {
            Apple2.SetActive(true);
        }

    }
}
