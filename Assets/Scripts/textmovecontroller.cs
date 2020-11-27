using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
*  This script delays the mving text that says "the end" in the endscene by 1 second
*  
* Script: textmovecontroller
* @author  Brian Grigore and Greg Wang
* @version 1.0
* @since   2020-01-12
*/
public class textmovecontroller : MonoBehaviour
{
   
    public GameObject movingtext; //imports the text object
    
    //start is called on the first frame
    void Start()
    {
        //calls wait method
        StartCoroutine(textCoroutine());

    }
    //IEnumerator method is like an auto counter
    IEnumerator textCoroutine()
    {

       
        //waits 1 second and then enables the text object
        yield return new WaitForSeconds(1);
        movingtext.SetActive(true);
        
        
        

    }




}
