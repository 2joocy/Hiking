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

    // Use this for initialization
    void Start () {
        Vector3 cursorPos = Input.mousePosition;
        rgdbody = GetComponent<Rigidbody2D>();
        Cursor.visible = true;
        transform.position = Camera.main.ScreenToWorldPoint(cursorPos);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 cursorPos = Input.mousePosition;
        //float distance = Vector2.Distance(playerObject.transform.position, transform.position);
        Vector3 newPos = Camera.main.ScreenToWorldPoint(cursorPos);
        rgdbody.AddForce((newPos - transform.position) * speed, ForceMode2D.Impulse); //Relativ position
        //transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
        Vector3 lort = transform.position;
        lort.z = 10f;
        transform.position = lort;
    }

    void FixedUpdate(){
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Slangens colliders position
        Debug.Log("Skyyyt det er collision");
        Rigidbody2D playerRgdBody = playerObject.GetComponent<Rigidbody2D>();
        Vector2 deltaVector = playerRgdBody.transform.position - transform.position;
        playerRgdBody.AddForce((deltaVector) * 15000, ForceMode2D.Impulse);
        //Debug.Log("Collision at: " + collision.transform.position.x + " : " + collision.transform.position.y);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}
