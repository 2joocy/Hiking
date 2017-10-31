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
        if (Input.GetKeyDown("space")) {
            Debug.Log("YEEET");
            rgdbody.AddForce(new Vector2(0, 1) * 10000, ForceMode2D.Impulse);
        }
    }

    private void movement(float horizontal) {
        
        rgdbody.velocity = new Vector2(horizontal * movementSpeed, rgdbody.velocity.y);
    }
}
