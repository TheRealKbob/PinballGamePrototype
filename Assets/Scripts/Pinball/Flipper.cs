using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent( typeof( Rigidbody2D ), typeof( PolygonCollider2D ) ) ]
public class Flipper : MonoBehaviour {

    public const float ANGLE_AMOUNT = 30;

    public enum State
    {
        PRESSED,
        RELEASED
    }

    public enum Orientation
    {
        RIGHT,
        LEFT
    }

    public Orientation orientation;
    public float speed = 40;

    public Rigidbody2D rb2d{ get; private set; }

    public StateMachine stateMachine{ get; private set; }
    private State state;

    public int initialRotation{ get; private set; }

	// Use this for initialization
	void Start () {
        initialRotation = ( orientation == Orientation.LEFT ) ? 180 : 0;

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        stateMachine = new StateMachine();
        stateMachine.AddState( new FlipperStatePressed( this ) );
        stateMachine.AddState( new FlipperStateReleased( this ) );
        stateMachine.CurrentState = State.PRESSED;
	}
	
    public void Press()
    {
        stateMachine.CurrentState = State.PRESSED;
    }

    public void Release()
    {
        stateMachine.CurrentState = State.RELEASED;
    }

	// Update is called once per frame
	void FixedUpdate () {
        if( Input.GetMouseButton(0) )
        {
            Press();
        }
        else
        {
            Release();
        }

        stateMachine.Update();
    }
}

public class FlipperState : State
{
    protected Flipper flipper;
    protected float targetRotation = 0;

    public FlipperState( Flipper flipper, Flipper.State state ) : base( state )
    {
        this.flipper = flipper;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if( flipper.rb2d.rotation != targetRotation )
        {
            flipper.rb2d.MoveRotation( Mathf.Lerp( flipper.rb2d.rotation, targetRotation, Time.fixedDeltaTime * flipper.speed ) );
        }
    }
}

public class FlipperStatePressed : FlipperState
{
    public FlipperStatePressed( Flipper flipper ) : base( flipper, Flipper.State.PRESSED ){}

    public override void OnEnter()
    {
        base.OnEnter();
        targetRotation = flipper.initialRotation + ( ( flipper.orientation == Flipper.Orientation.LEFT ) ? Flipper.ANGLE_AMOUNT : -Flipper.ANGLE_AMOUNT );
    }
}

public class FlipperStateReleased : FlipperState
{
    public FlipperStateReleased( Flipper flipper ) : base( flipper, Flipper.State.RELEASED ){}

    public override void OnEnter()
    {
        base.OnEnter();
        targetRotation = flipper.initialRotation + ( ( flipper.orientation == Flipper.Orientation.LEFT ) ? -Flipper.ANGLE_AMOUNT : Flipper.ANGLE_AMOUNT );
    }
}
