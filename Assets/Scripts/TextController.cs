using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/**
*  This script is used to control the text that comes up on screen for the player 
*  
* Script: TextController
* @author  Greg Wang and Brian Grigore
* @version 1.0
* @since   2020-01-11
*/
public class TextController : MonoBehaviour
{
    //Player Object
    [SerializeField] GameObject Plry;

    //The current time
    public Time_Storage Timed;
    
    //The different text fields that need to be modified
    public Text YearText;
    public Text TitleText;
    public Text FillerText;
    public Text FillerText2;
    public Text InstructionsText;
    
    //The current year and the length of a year
    public int YearNumber = 0;
    public int YearPeriod = 220;

    //The target times for filler and instruction text
    private float targetTimeF1 = 4f;
    private float targetTimeF2 = 7f;
    private float targetTimeI = 1f;

    public string SeasonText;



        /**
        * Description: Checks what year it is and then displays it on screen
        * Pre-condition: The seasons must have defined time periods
        * Post-condition: The seasons and year will be displayed on screen
        * 
        */
    void setYearText()
    {
        YearNumber = Timed.GetYearTime() / YearPeriod;
        //First eighth of the year, displays winter
        if (Timed.GetYearTime() % YearPeriod <= YearPeriod / 8)
        {

            Timed.SetSeason("Winter");

        }

        //Quarter of the year is Spring
        else if (Timed.GetYearTime() % YearPeriod <= (YearPeriod / 4) + (YearPeriod / 8))
        {

            Timed.SetSeason("Spring");

        }

        //Half of the year is Summer
        else if (Timed.GetYearTime() % YearPeriod <= (YearPeriod / 2) + (YearPeriod / 8))
        {

            Timed.SetSeason("Summer");

        }

        //Third quarter is Fall
        else if (Timed.GetYearTime() % YearPeriod <= (YearPeriod * 3 / 4) + (YearPeriod / 8))
        {

            Timed.SetSeason("Fall");

        }

        //Last bit is Winter
        else
        {
            Timed.SetSeason("Winter");
        }

        YearText.text = "Year: " + YearNumber + System.Environment.NewLine + Timed.GetSeason();
    }



       /**
       * Description: Sets the title text for the beginning of the game
       * Pre-condition: The player must exist
       * Post-condition: It will show the title 
       * 
       */

    private void setTitleText()
    {
        Vector3 position = Plry.transform.position;
        //In this position, the title will show up on screen
        if (position.x > -7 && position.x < 1)
        {
            TitleText.text = "Patience";
        }
        else
        {
            TitleText.text = "";
        }

    }

       /**
       * Description: Sets the filler text for throughout the game
       * Pre-condition: The player must exist
       * Post-condition: It will show the title 
       * 
       */
    private void setFillerText1()
    {
        targetTimeF1 -= Time.deltaTime;
        Vector3 position = Plry.transform.position;
        //All these if statements are for ranges where the filler should be seen at by the player
        if (position.x > -24 && position.x < -16)
        {
            FillerText.text = "On this new world " + System.Environment.NewLine + "To save it...";
        }
        else if (position.x > 33 && position.x < 41)
        {
            FillerText.text = "Sometimes he just " + System.Environment.NewLine + "Needed to wait";
        }
        else if (position.x > 74 && position.x < 80)
        {
            FillerText.text = "Some things took time to grow";
        }
        else if (position.x > 129 && position.x < 142 && position.y > 0)
        {
            FillerText.text = "The villagers were starving";
        }
        else if (position.x > 379 && position.x < 400)
        {
            FillerText.text = "In the end,";
        }
        else
        {
            FillerText.text = "";
        }


    }

    /**
       * Description: Sets the filler text for throughout the game
       * Pre-condition: The player must exist
       * Post-condition: It will show the title 
       * 
       */
    private void setInstructionsText1()
    {
        
        targetTimeI -= Time.deltaTime;
        Vector3 position = Plry.transform.position;
        //All these if statements are for ranges where the instructions should be seen at by the player

        if (position.x > -37 && position.x < -29 && targetTimeI <= 0)
        {
            InstructionsText.text = "[Press <- and -> to move]";
        }
        else if(position.x > 41 && position.x < 49)
        {
            InstructionsText.text = "[Hold Space to wait]";
        }
        else if(position.x > 49 && position.x < 53)
        {
            InstructionsText.text = "You can't wait underwater";
        }
        else if(position.x > 74 && position.x < 80)
        {
            InstructionsText.text = "[Press the up and down to climb]";
        }
        else if (position.x > 98 && position.x < 104)
        {
            InstructionsText.text = "[Press E to pick up and plant the apple]";
        }
        else if (position.x > 188 && position.x < 200)
        {
            InstructionsText.text = "[Press Q to pick up and plant wheat]";
        }
        else
        {
            InstructionsText.text = "";
        }

    }
    /**
       * Description: Sets the filler text for throughout the game
       * Pre-condition: The player must exist
       * Post-condition: It will show the filler text in the right ranges 
       * 
       */
    private void setFillerText2()
    {        
        //All these if statement are for ranges where the filler should be seen at by the player
        targetTimeF2 -= Time.deltaTime;
        Vector3 position = Plry.transform.position;
        if (position.x > -16 && position.x < -10)
        {
            FillerText2.text = "He just needed, " + System.Environment.NewLine + "A bit more...";
        }
        else if (position.x > 33 && position.x < 41)
        {
            FillerText2.text = "For the perfect time";
        }
        else if (position.x > 129 && position.x < 142 && position.y > 0)
        {
            FillerText2.text = "And couldn't complete the bridge";
        }
        else if (position.x > 400 && position.x < 420)
        {
            FillerText2.text = "He was able to stop the calamity";
        }
        else if (position.x > 200 && position.x < 220)
        {
            FillerText2.text = "He needed help to cross this obstacle";
        }
        else
        {
            FillerText2.text = "";
        }


    }




       /**
       * Description: Runs all of the function previously listed
       * Pre-condition: The text changing functions must exist
       * Post-condition: It will show the text based off the previous methods
       */
    void Update()
    {
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (SceneIndex > 0) {
            setYearText();

            setTitleText();

            setFillerText1();

            setFillerText2();

            setInstructionsText1();
        }

    }


}