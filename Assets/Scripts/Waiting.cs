using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

/**
*  This script is used as the users way to wait
*  and speed time up
*
* Script: 
* @author  Greg Wang and Brian Grigore
* @version 1.0
* @since   2020-01-09
*/
public class Waiting : MonoBehaviour
{
    //The stored time
    [SerializeField] Time_Storage Timed;

    //The audio clips to play when waiting
    public AudioClip timetravelstart; // sets refrences to the audio clips and the audio source
    public AudioClip timetravelend;
    public AudioSource MusicSource;

    //The distance and check water
    public float distance_y;
    public LayerMask whatIsWater;

    // Start just sets the year time to the correct year time at the start of the game
    void Start()
    {
        Timed.SetYearTime((220 / 8) + 10);

        Debug.Log("Started game");

    }
    //Target time to reach
    public int targetTime = 0;

    //How fast waiting speeds up time
    public float WaitRate = 2.0f;

    /**
       * Description: Adds time to the time storage and plays the sound when Space is pressed
       * Pre-condition: The player exist and has a time storage object put in
       * Post-condition: The player will be able to change time by waiting
       */
    void FixedUpdate()
    {

        RaycastHit2D hitInfoWater = Physics2D.Raycast(transform.position, Vector2.up, distance_y, whatIsWater);
        //As long as the player isn't underwater
        if (hitInfoWater.collider == null)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Timed.SetYearTime(Timed.GetYearTime() + (int)WaitRate);
                MusicSource.clip = timetravelstart; //sets the clip and plays the sound effect from the source
                MusicSource.Play();
            }

            else if (Input.GetKeyUp(KeyCode.Space))
            {
                WaitRate = 0;
                MusicSource.clip = timetravelend; //sets the clip and plays the sound effect from the source
                MusicSource.Play();

            }

            else if (Input.GetKey(KeyCode.Space))
            {
                Timed.SetYearTime(Timed.GetYearTime() + (int)WaitRate);
                WaitRate += 0.03f;
                if (WaitRate > 200)
                {
                    WaitRate = 200;
                }
            }

        }

        

        


    }


}
