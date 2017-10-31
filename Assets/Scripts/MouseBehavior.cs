using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour {

    [SerializeField]
    private GameObject playerObject;

    [SerializeField]
    private float speed = 30;

    //variable for the position of the cursor
    private Rigidbody2D rgdbody;
    private Vector2 cursorPos;
    private bool isCollision = false;
    private Vector3 newPos;
    private Vector3 lastVelocity;

    // Use this for initialization
    void Start () {
        rgdbody = GetComponent<Rigidbody2D>();
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
        
        
    }

    void FixedUpdate(){
        //Problem: Fuglen sendes alt for højt oppe i luften ved hurtige stød
        //TODO: Lav flere levels, finpuds dem så de ikke er pixileret. Kamera følger spiller mens han bevæger sig. Fix physics
        cursorPos = Input.mousePosition;
        Vector3 snakePos = transform.position;
        newPos = Camera.main.ScreenToWorldPoint(cursorPos);
        newPos.x -= 0.08f;
        newPos.y -= 0.175f;
        rgdbody.AddForce((newPos - snakePos) * speed, ForceMode2D.Impulse); //Relativ position
        Vector3 constantVisibility = transform.position;
        constantVisibility.z = 10f;
        transform.position = constantVisibility;
        lastVelocity = rgdbody.velocity;
        if (isCollision)
        {
            //TODO: Tilpas force så den hverken er for meget eller for lidt
            //Små slag = stor bevægelse && konstante lange bevægelser = små bevægelser
            playerObject.GetComponent<Rigidbody2D>().AddForce((((newPos - snakePos)*-1) * 10000) * lastVelocity.magnitude, ForceMode2D.Force); //Relativ position
             
        }
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {

        }
        else {
            isCollision = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollision = false;
    }

}
