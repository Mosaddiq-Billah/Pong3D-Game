using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown_Script : MonoBehaviour
{
    public static int counts;
    public Text counting;
    public GameController game;
    public GameObject menubutton;
    public Text GO;
    //public string text = "GO!";
  

    /* public void Update()
     {   
         while(counts < 0) { 
         counting.text = counts.ToString();
         counts-=1;
         }
     }*/

    public void countdown()
    {
        counts = 3;
        menubutton.gameObject.SetActive(false);
        GO.gameObject.SetActive(false);
        counting.gameObject.SetActive(true);
        StartCoroutine(CountDownToStart());
        BallController.stopped = true;
    }

    IEnumerator CountDownToStart()
    {
        while(counts > 0) { 
        counting.text = counts.ToString();
        yield return new WaitForSeconds(1f);
        counts--;
        }
        //counting.text = text.ToString();
        counting.gameObject.SetActive(false);
        GO.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        GO.gameObject.SetActive(false);
        menubutton.gameObject.SetActive(true);
        BallController.stopped = false;
    }
    

}

