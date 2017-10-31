using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        transform.position = new Vector3(rgdbody.position.x, rgdbody.position.y);
        movement(horizontal);
        if (Input.GetKeyDown("space")) {
            rgdbody.AddForce(new Vector2(0, 1) * 10000, ForceMode2D.Impulse);
        }
    }

    private void movement(float horizontal) {
        
        rgdbody.velocity = new Vector2(horizontal * movementSpeed, rgdbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Finish")
        {
            nextLevel();
        }

        if (collision.collider.tag == "Water")
        {
            restartLevel();
        }
    }

    private void restartLevel() {
        SceneManager.LoadScene(Application.loadedLevel);

    }

    private void nextLevel() {
        int i = Application.loadedLevel;
        SceneManager.LoadScene(i + 1);

    }

}
