using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow_houses : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    public Time_Storage Current_Time;
    public LayerMask whatIsWheat;
    public bool hasWheat;
    public bool canGrow;
    public int startTime;
    public bool flag;
    [SerializeField] GameObject[] Houses;



    // Start is called before the first frame update
    void Start()
    {
        hasWheat = false;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfoWheat = Physics2D.Raycast(Player.transform.position, Vector2.down, 10, whatIsWheat);
        if (hitInfoWheat.collider != null && !hasWheat)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hasWheat = true;
            }

        }

        else if (hasWheat && hitInfoWheat.collider == null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                canGrow = true;
            }

        }

        if(canGrow == true && flag == false)
        {
            startTime = Current_Time.GetYearTime();
            flag = true;
        }

        if (Current_Time.GetYearTime() > startTime + 5000 && canGrow == true)
        {

            for (int i = 0; i < Houses.Length; i++)
            {
                Houses[i].SetActive(false);
            }

            Houses[4].SetActive(true);

        }
        else if (Current_Time.GetYearTime() > startTime + 3000 && canGrow == true)
        {

            for (int i = 0; i < Houses.Length; i++)
            {
                Houses[i].SetActive(false);
            }

            Houses[3].SetActive(true);

        }

        else if(Current_Time.GetYearTime() > startTime + 2000 && canGrow == true)
        {
            for (int i = 0; i < Houses.Length; i++)
            {
                Houses[i].SetActive(false);
            }

            Houses[2].SetActive(true);
        }
        else if (Current_Time.GetYearTime() > startTime + 1000 && canGrow == true)
        {
            for (int i = 0; i < Houses.Length; i++)
            {
                Houses[i].SetActive(false);
            }

            Houses[1].SetActive(true);
        }

        else
        {
            Houses[0].SetActive(true);

            for (int i = 1; i < Houses.Length; i++)
            {
                Houses[i].SetActive(false);
            }
        }

    }
}
