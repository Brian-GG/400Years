using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
*  This script is used to control the items that appear per season
*  so winter items appear in winter
*  
* Script: SetSeasons
* @author  Greg Wang and Brian Grigore
* @version 1.0
* @since   2020-01-12
*/
public class SetSeasons : MonoBehaviour
{
    //Establish arrays to determine which game objects appear when
    public Time_Storage Current_Time;
    [SerializeField] GameObject[] Winter;
    [SerializeField] GameObject[] Summer;
    [SerializeField] GameObject[] Spring;
    [SerializeField] GameObject[] Fall;

    public string Season;


        /**
        * Description: Checks the seasons and turns on and off the objects in that array based on what season it is
        * Pre-condition: The season arrays must be filled out
        * Post-condition: The seasons will determine what objects are on screen
        * @param none
        * @return none
        */

    void Update()
    {
        Season = Current_Time.GetSeason();

        //if its winter turn on all winter objects and off all others
        if(Season == "Winter")
        {
            
            for (int i = 0; i < Summer.Length; i++)
            {
                Summer[i].SetActive(false);

            }
            for (int i = 0; i < Fall.Length; i++)
            {
                Fall[i].SetActive(false);

            }
            for (int i = 0; i < Spring.Length; i++)
            {
                Spring[i].SetActive(false);

            }
            for (int i = 0; i < Winter.Length; i++)
            {
                Winter[i].SetActive(true);


            }
        }

        //if its summer turn on all winter objects and off all others
        else if (Season == "Summer")
        {
            for (int i = 0; i < Winter.Length; i++)
            {
                Winter[i].SetActive(false);

            }
            for (int i = 0; i < Fall.Length; i++)
            {
                Fall[i].SetActive(false);

            }
            for (int i = 0; i < Spring.Length; i++)
            {
                Spring[i].SetActive(false);

            }
            for (int i = 0; i < Summer.Length; i++)
            {
                Summer[i].SetActive(true);


            }
        }

        //if its spring turn on all winter objects and off all others
        else if (Season == "Spring")
        {
            for (int i = 0; i < Winter.Length; i++)
            {
                Winter[i].SetActive(false);

            }
            for (int i = 0; i < Fall.Length; i++)
            {
                Fall[i].SetActive(false);

            }
            for (int i = 0; i < Summer.Length; i++)
            {
                Summer[i].SetActive(false);

            }
            for (int i = 0; i < Spring.Length; i++)
            {
                Spring[i].SetActive(true);

            }
        }

        //if its fall turn on all winter objects and off all others
        else if (Season == "Fall")
        {
            for(int i = 0; i < Winter.Length; i++)
            {
                Winter[i].SetActive(false);

            }
            
            for (int i = 0; i < Summer.Length; i++)
            {
                Summer[i].SetActive(false);

            }
            for (int i = 0; i < Spring.Length; i++)
            {
                Spring[i].SetActive(false);

            }
            for (int i = 0; i < Fall.Length; i++)
            {
                Fall[i].SetActive(true);

            }
        }





    }
}
