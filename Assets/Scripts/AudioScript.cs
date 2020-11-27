using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*  This script plays background music for the entire game by using an audiosource object
*  
* Script: AudioScript
* @author  Brian Grigore and Greg Wang
* @version 1.0
* @since   2020-01-12
*/

public class AudioScript : MonoBehaviour
{

    //tells the program what clip and source to use when playing
    public AudioClip MusicClip;
    public AudioSource MusicSource;



    // Start is called before the first frame update
    /**
     * Description: Plays background music throughout the entire game
     * Pre-condition: The audio source component and the audio clip must both be properly imported
     * Post-condition: When the program is run the audio clip will play
     * @param none
     * @return none
     */
    void Start()
    {
        //loads appropriate clip and plays for the whole game
        MusicSource.clip = MusicClip;
        MusicSource.Play();

    }

   
    
}
