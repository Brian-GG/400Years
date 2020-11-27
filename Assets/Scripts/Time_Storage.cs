using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Time")]

/**
*  This script is used as constructor for a scriptable object,
*  this object will store the current time, and the season in
*  string format
*   
*
* Script: Time_Storage
* @author  Greg Wang and Greg Wang
* @version 1.0
* @since   2020-01-09
*/

public class Time_Storage : ScriptableObject
{
    //The current time
    public int YearTime = 0;

    //The season's name
    public string Season;

     /**
       * Description: Returns the name of the season they're in as a string
       * @return Season
       */
    public string GetSeason()
    {
        return Season;
    }

    /**
       * Description: Allows the game to set the season that's stored
       * @param newSeason
       */
    public void SetSeason(string newSeason)
    {
        Season = newSeason;
    }

    /**
       * Description: Sends the one requesting it the current time
       * @return YearTime
       */
    public int GetYearTime()
    {
        return YearTime;
    }
    
    /**
       * Description: Allows scripts to change the time
       * @param newTime
       */
    public void SetYearTime(int newTime)
    {
        YearTime = newTime;
    }

}
