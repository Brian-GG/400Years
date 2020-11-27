using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
   *  This script is used to make it so that after the player
   *  gives the food to the village, the village constructs a 
   *  bridge over time
   * 
   * Script:  BridgeScript
   * @author  Greg Wang and Brian Grigore
   * @version 1.0
   * @since   2020-01-11
   */
public class BridgeScript : MonoBehaviour
{

   

    //Declare whatever objects we need to expand the bridge:
    /* The player
     * Which layer counts as wheat
     * Whether or not the player is holding wheat
     * When the bridge starts to expand
     * Flagging the start of the expand
     * All the houses
     * The current time object
     * The original bridge sprite to copy
     * Whether or not we can grow the bridge
     * The timeuntil next expand
     * Whether or not we started expanding
     * How many times we expanded
     * And the start time of the expansion
     * 
     */

    [SerializeField] public GameObject Player;
    public LayerMask whatIsWheat;
    public bool hasWheat;
    public bool canGrow;
    public int startTime;
    public bool flag;

    [SerializeField] GameObject[] Houses;
    [SerializeField] Time_Storage Current_Time;
    public GameObject Original;
    public GameObject PlayerObject;
    public bool Able_to_grow = false;
    public int TimeUntilNext = 25000;
    public bool Started = false;
    public int counter = 0;
    public int StartTime;

    // Start is called before the first frame update
    void Start()
    {
        TimeUntilNext = 25000;
    }

    /**
    * Description: Checks to see if the player picked up and dropped wheat or not
    * Pre-condition: The player must exist and have wheat to pick up
    * Post-condition: The bridge will be able to expand because the wheat was placed
    * @param none
    * @return none
    */
    void CheckForWheat()
    {
        
        Vector3 Position = this.transform.position;
        Vector3 PlyrP = PlayerObject.transform.position;
        //Shoots a ray downward from the player position to check for wheat
        RaycastHit2D hitInfoWheat = Physics2D.Raycast(Player.transform.position, Vector2.down, 10, whatIsWheat);
        if (hitInfoWheat.collider != null && !hasWheat)
        {
            //If the player presses Q they collect the wheat
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hasWheat = true;
            }

        }

        else if (hasWheat && hitInfoWheat.collider == null)
        {
            //If they have wheat ad place it down then the bridge can grow
            if (Input.GetKeyDown(KeyCode.Q))
            {
                canGrow = true;
            }

        }


    }


    /**
    * Description: Expands the bridge based on when it started expanding and whether or not the bridge can expand
    * Pre-condition: The game has to have checked for the wheat and the player and wheat object need to be present
    * (So it can't be winter since wheat isn't active then) and the original bridge object must exist
    * Post-condition: The bridge will expand based on how long it's been since the bridge started expanding
    * @param none
    * @return none
    */
    void Update()
    {

        CheckForWheat();
        //If the bridge can expand, then flag that we're starting to expand
        if (canGrow == true && flag == false)
        {
            startTime = Current_Time.GetYearTime();
            flag = true;
        }


        //Wait a while before starting to grow
        if (canGrow == true && Current_Time.GetYearTime() > startTime + 3000)
        {
            Able_to_grow = true;
        }

        else
        {
            Able_to_grow = false;
        }

        
        //If you haven't started growing, then start
        if (Able_to_grow && Input.GetKeyDown(KeyCode.Space) && Started == false)
        {
            StartTime = Current_Time.GetYearTime();
        }
        //If you've started, then wait until time is up to create a new bridge
        //Then once you reach 10 bridge objects, start adding some to the second lake
        else if (Able_to_grow && Input.GetKey(KeyCode.Space))
        {
            TimeUntilNext -= (Current_Time.GetYearTime() - StartTime);
            if (TimeUntilNext <= 0 && counter < 10)
            {
                Original = Instantiate(Original, new Vector3(Original.transform.position.x + 3f, Original.transform.position.y, Original.transform.position.z), Quaternion.identity);
                Started = false;
                counter++;
                TimeUntilNext = 25000;
            }
            else if(TimeUntilNext <= 0 && counter == 10) 
            {
                Original = Instantiate(Original, new Vector3(Original.transform.position.x + 21f, Original.transform.position.y + 2f, Original.transform.position.z), Quaternion.identity);
                Started = false;
                counter++;
                TimeUntilNext = 25000;
            }
            else if(TimeUntilNext <= 0 && counter < 13)
            {
                Original = Instantiate(Original, new Vector3(Original.transform.position.x + 3f, Original.transform.position.y, Original.transform.position.z), Quaternion.identity);
                Started = false;
                counter++;
                TimeUntilNext = 25000;
            }

        }
        //Else nothing happens
        else
        {

        }
    }
}
