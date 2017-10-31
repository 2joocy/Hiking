using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour {

    [SerializeField]
    private GameObject playerObject;

    [SerializeField]
    private float maxDistance = 3;

    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float distance = 1;

    //variable for the position of the cursor

    private bool isCollision = false;
    
    

    // Use this for initialization
    void Start () {
        Vector3 cursorPos = Input.mousePosition;
       
        Cursor.visible = false;
        transform.position = Camera.main.ScreenToWorldPoint(cursorPos);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 cursorPos = Input.mousePosition;
        //float distance = Vector2.Distance(playerObject.transform.position, transform.position);
        Vector3 newPos = Camera.main.ScreenToWorldPoint(cursorPos);
        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
        //Debug.Log("Mouse Position: " + cursorPos.x + " : " + cursorPos.y);
        //Debug.Log("Current Distance is: " + distance);
        Vector3 lort = transform.position;
        lort.z = 10f;
        transform.position = lort;

        //lastPosition = transform.position;
        //Vector3 newPos = Camera.main.ScreenToWorldPoint(cursorPos);
        //If playerobject is within the maxDistance, allow the cursor object to move around the playerobject within a certain distance. 
        //if (distance < maxDistance)
        //{
        //    lastPosition = transform.position;
        //    Vector3 newPos = Camera.main.ScreenToWorldPoint(cursorPos);
        //    transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);

        //}


        //If distance between player and cursor becomes too great, teleport back to last known position within the max allowed range
        //if (maxDistance < distance) {
        //    transform.position = Vector3.Lerp(transform.position, teleportCursorObject(playerObject.transform.position, lastPosition), (speed * 2) * Time.deltaTime);
        //}
        //Vector3 lort = transform.position;
        //lort.z = 10f;
        //transform.position = lort;



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision at: " + collision.transform.position.x + " : " + collision.transform.position.y);
        isCollision = true;
        DistanceJoint2D dj = GetComponent<DistanceJoint2D>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollision = false;
        DistanceJoint2D dj = GetComponent<DistanceJoint2D>();
        dj.distance = distance;
    }









    //private Vector3 teleportCursorObject(Vector3 playerPos, Vector3 mousePos) {
    //    Vector3 teleport = new Vector3();
    //    Debug.Log("Player Position: X : " + playerPos.x + "  Y : " + playerPos.y);
    //    Debug.Log("Mouse Position: X : " + mousePos.x + "  Y : " + mousePos.y);

    //    if ((Mathf.Abs(playerPos.x) > Mathf.Abs(mousePos.x)) || Mathf.Abs(playerPos.y) > Mathf.Abs(mousePos.y))
    //    {
    //        teleport.x = (float) (mousePos.x - 0.1);
    //        teleport.y = (float) (mousePos.y - 0.1);
    //        Debug.Log("Out of range! Teleporting Mouse back!");
    //    }

    //    if ((Mathf.Abs(playerPos.x) < Mathf.Abs(mousePos.x)))
    //    {
    //        teleport.x = (float)(mousePos.x - 0.1);
    //        teleport.y = (float)(mousePos.y - 0.1);
    //    }

    //    return teleport;
    //}
}
