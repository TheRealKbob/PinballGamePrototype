using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    Enum id { get; }
    void OnEnter();
    void OnExit();
    void OnUpdate();
}

public class State : IState
{
    protected StateMachine machine;
    public Enum id { get; private set; }

    public State( Enum id )
    {
        this.id = id;
    }

    public void SetStateMachine( StateMachine machine )
    {
        this.machine = machine;
    }

    public virtual void OnEnter()
    {
        
    }

    public virtual void OnExit()
    {
    }

    public virtual void OnUpdate()
    {

    }
}