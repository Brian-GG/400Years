using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
/**
*  This script controls the highscore system by reading from a text file, updating or adding the players score,
*  sorting the scores, and displaying the top 10
* Script: ScoreScript
* @author  Brian Grigore Greg Wang
* @version 1.0
* @since   2020-01-12
*/

public class ScoreScript : MonoBehaviour
{

    public InputField nameField; //input for player's name
    [SerializeField] Time_Storage newscore; //players score
    protected string path; //string to hold filepath
    private string userName; //string to hold username
    // Text fields to control displaying text
    [SerializeField] private Text name1text = null;
    [SerializeField] private Text name2text = null;
    [SerializeField] private Text name3text = null;
    [SerializeField] private Text name4text = null;
    [SerializeField] private Text name5text = null;
    [SerializeField] private Text name6text = null;
    [SerializeField] private Text name7text = null;
    [SerializeField] private Text name8text = null;
    [SerializeField] private Text name9text = null;
    [SerializeField] private Text name10text = null;
    [SerializeField] private Text score1text = null;
    [SerializeField] private Text score2text = null;
    [SerializeField] private Text score3text = null;
    [SerializeField] private Text score4text = null;
    [SerializeField] private Text score5text = null;
    [SerializeField] private Text score6text = null;
    [SerializeField] private Text score7text = null;
    [SerializeField] private Text score8text = null;
    [SerializeField] private Text score9text = null;
    [SerializeField] private Text score10text = null;
    [SerializeField] private GameObject input = null; //input display object
    [SerializeField] private GameObject displayscores = null; //displayscores object
    [SerializeField] private GameObject airplane = null; // airplane image object
    [SerializeField] private GameObject endtext = null; //the end text object

    /**
    * Description: controller for what happens when the submit button is pressed,
    * sets parameters such as user's name and score, gets file, sets visuals, calls calculator method
    * Pre-condition: the button must be initialized properly and must be pressed
    * Post-condition: the listhighscores method will run and the visuals will be updated
    * @param none
    * @return none
    */
    public void OnSubmit()
    {
        userName = nameField.text; // sets username
        Debug.Log("Entered:" + userName);
        path = Application.dataPath + "/highscores.txt"; //gets text filepath
        ListHighScores(); //calls calculator method
        //sets up UI
        input.SetActive(false); 
        displayscores.SetActive(true);
        airplane.SetActive(false);
        endtext.SetActive(false);

    }
    /**
    * Description: reads save file and finds if player already has  their name entered and updates their score,
    * if no matching name is found player is added to the list, the list is sorted, and saved back into the file,
    * the display fields are set up
    * Pre-condition: the onsubmit method must be called and the file must exist
    * Post-condition: the highscores will be displayed
    * @param none
    * @return none
    */
    void ListHighScores()
    {

        string newuser = userName; //gets user's name and score
        int userscore = (newscore.GetYearTime() / 220);

        //creating array lists to calculate highscores
        List<string> names = new List<string>();
        List<int> scores = new List<int>();
        List<string> displayscores = new List<string>();
        List<string> displaynames = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            //adds empty spaces in case there are less than 10 entries
            displayscores.Add(" ");
            displaynames.Add(" ");

        }



        int counter = 0; //counter for file reading
        string line; //temporary string for file reading

        

        // Read the file and display it line by line.  
        System.IO.StreamReader file = new System.IO.StreamReader(Application.dataPath + "/highscores.txt"); //opens file
        Debug.Log("Entering File");
        while ((line = file.ReadLine()) != null)
        {
            //tries to add to int array for score, if it cant it adds entry to string array for names
            counter++;
            try
            {
                scores.Add(System.Convert.ToInt32(line));
                Debug.Log(line);
            }
            catch
            {
                names.Add(line);
                Debug.Log(line);

            }
        }

        file.Close(); //closes file
        Debug.Log("There were " + counter + " lines.");

        




        //creates two arrays from the arraylists for searcing and sorting
        string[] namesarray = names.ToArray();
        int[] scoresarray = scores.ToArray();
        //debugging
        for (int i = 0; i < namesarray.Length; i++)
        {
            Debug.Log(namesarray[i]);
            Debug.Log(scoresarray[i]);
        }

        //binary search algorithim to determine wether to add a new entry or update an existing one
        int index = BinarySearch(namesarray, 0, namesarray.Length - 1, newuser);

        if (index >= 0) //checks to see if the user is already in the save file
        {

            if (userscore < scoresarray[index]) //if the user got a new high score, update their high score
            {
                scores[index] = userscore;
                scoresarray[index] = userscore;

            }




        }
        else // if not in system, adds a new user and their score
        {
            names.Add(newuser);
            scores.Add(userscore);
        }
        //insertion sort algorithim (fastest) to sort highscores
        InsertSort(scores, names);
        for (int i = 0; i < names.Count; i++)
        {
            Debug.Log(names[i]);
            Debug.Log(scores[i]);
        }
        //prepares top 10 saves for displaying
        for (int i = 0; i < scores.Count; i++)
        {
            displayscores[i] = scores[i].ToString();
            displaynames[i] = names[i];
        }



        //sets display text values
        name1text.text = displaynames[0];
        name2text.text = displaynames[1];
        name3text.text = displaynames[2];
        name4text.text = displaynames[3];
        name5text.text = displaynames[4];
        name6text.text = displaynames[5];
        name7text.text = displaynames[6];
        name8text.text = displaynames[7];
        name9text.text = displaynames[8];
        name10text.text = displaynames[9];
        score1text.text = displayscores[0];
        score2text.text = displayscores[1];
        score3text.text = displayscores[2];
        score4text.text = displayscores[3];
        score5text.text = displayscores[4];
        score6text.text = displayscores[5];
        score7text.text = displayscores[6];
        score8text.text = displayscores[7];
        score9text.text = displayscores[8];
        score10text.text = displayscores[9];

        List<string> rewritre = new List<string>(); //arraylist to rewrite save file
        //formats data in proper format to be saved, with name then score on the next line
        for (int i = 0; i < names.Count; i++)
        {
            rewritre.Add(names[i]);
            rewritre.Add(displayscores[i]);
        }

        File.WriteAllLines(Application.dataPath + "/highscores.txt", rewritre); //writes to file then closes file



    }
    //binarysearch algorithim
    int BinarySearch(string[] namesarray, int left, int right, string newuser)
    {

        int middle;

        if (left > right)
        {
            return -1;
        }

        middle = (left + right) / 2;

        if (namesarray[middle].Equals(newuser))
        {
            return middle;
        }



        if (string.Compare(newuser, namesarray[middle], System.StringComparison.CurrentCulture) < 0)
        {
            Debug.Log("option1");
            return BinarySearch(namesarray, left, middle - 1, newuser);
        }
        else
        {
            Debug.Log("option2");
            return BinarySearch(namesarray, middle + 1, right, newuser);
        }






    }




    //insertion sort algorithim
    void InsertSort(List<int> scores, List<string> names)
    {
        for (int top = 1; top < scores.Count; top++)
        {
            int item = scores[top];
            string item2 = names[top];
            int i = top;

            while (i > 0 && item < scores[i - 1])
            {
                scores[i] = scores[i - 1];
                names[i] = names[i - 1];
                i--;
            }

            scores[i] = item;
            names[i] = item2;
        }
    }
    /**
    * Description: controls the button to go back to the main menu by loading the main menu scene
    * Pre-condition: the listhighscores method must be called and the scores must be displayed
    * Post-condition: the main menu scene will be loaded
    * @param none
    * @return none
    */

    public void Buttonclick ()
    {
        SceneManager.LoadScene(0);
    }




}

