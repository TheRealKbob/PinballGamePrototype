using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent( typeof( Rigidbody2D ) ) ]
public class Bumper : MonoBehaviour {

    private Rigidbody2D rb2d;
    private PhysicsMaterial2D physicsMaterial;

    public float friction;
    public float bounciness;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        physicsMaterial = Instantiate( rb2d.sharedMaterial );
        friction = physicsMaterial.friction;
        bounciness = physicsMaterial.bounciness;
	}
}
