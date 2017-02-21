using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {

    protected IState state;
    protected Dictionary< Enum, IState > stateMap = new Dictionary<Enum, IState>();

    public Enum CurrentState
    {
        get
        {
            return state.id;
        }

        set
        {
            if( state != null && value != state.id )
                state.OnExit();

            state = GetState( value );
            state.OnEnter();
        }
    }

    public StateMachine()
    {

    }

    public void AddState( State s )
    {
        s.SetStateMachine( this );
        stateMap.Add( s.id, s );
    }

    public IState GetState( Enum t )
    {
        return stateMap[t];
    }

    public void Update()
    {
        if( state != null )
        {
            state.OnUpdate();
        }
    }

}