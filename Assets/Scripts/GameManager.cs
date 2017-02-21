using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum State
    {
        MENU,
        PAUSED,
        PLAY
    }

    public State state;

    private StateMachine stateMachine;

    // Use this for initialization
    void Start()
    {

    }
}