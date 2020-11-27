using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/**
*  This script is used by the trees for when the time passes a certain point and we want to grow a tree
*
* Script: Growing
* @author  Greg Wang and Brian Grigore
* @version 1.0
* @since   2020-01-12
*/

public class Growing : MonoBehaviour
{

    //Creates all the variables needed such as the curent time, the original branch, player, starting time
    //And time until next growth
    [SerializeField] Time_Storage CurrentTime;
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
    * Description: Checks whether or not the tree can grow and grows it by adding another branch
    * Pre-condition: The player must exist and tree that's growing must exist with branches
    * Post-condition: The tree will grow when the time comes and the player can climb it
    * @param none
    * @return none
    */
    void Update()
    {
        //Checks to see if the player is close enough to grow the tree
        Vector3 Position = this.transform.position;
        Vector3 PlyrP = PlayerObject.transform.position;
        if (Position.x - 20 < PlyrP.x && PlyrP.x < Position.x + 20)
        {
            Able_to_grow = true;
        }
        else
        {
            Able_to_grow = false;
        }



        //If the tree is able to be grown, grow it when enough time passes
        if(Able_to_grow && Input.GetKeyDown(KeyCode.Space) && Started == false)
        {
            StartTime = CurrentTime.GetYearTime();
        }
        else if(Able_to_grow && Input.GetKey(KeyCode.Space))
        {
            TimeUntilNext -= (CurrentTime.GetYearTime() - StartTime);
            if(TimeUntilNext <= 0 && counter<5)
            {
                Original = Instantiate(Original, new Vector3(Original.transform.position.x, Original.transform.position.y + 1.5f, Original.transform.position.z), Quaternion.identity);

                Started = false;
                counter++;
                TimeUntilNext = 25000;
            }

        }
        else
        {

        }





        
    }
}
