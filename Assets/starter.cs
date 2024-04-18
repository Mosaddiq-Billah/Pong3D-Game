using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starter : MonoBehaviour
{
    private GameController gamecontroller;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        gamecontroller = FindObjectOfType<GameController>();
        anim = GetComponent<Animator>();
    }

    public void StartCountDown()
    {
        anim.SetTrigger("StartCountdown");
    }

    public void StartGame()
    {
        gamecontroller.StartGame();
    }
}
