using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class Player : MonoBehaviour {
    private Rigidbody2D rgdbody;

    [SerializeField]
    private float movementSpeed;
    
    // Use this for initialization
	void Start () {
        rgdbody = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = CnInputManager.GetAxis("Horizontal");
        movement(horizontal);
        Debug.Log("git gud: " + CnInputManager.GetAxis("Horizontal"));
    }

    private void movement(float horizontal) {
        
        rgdbody.velocity = new Vector2(horizontal * movementSpeed, rgdbody.velocity.y);
    }
}
