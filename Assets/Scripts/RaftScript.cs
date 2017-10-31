using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftScript : MonoBehaviour {
    public GameObject p1;
    public GameObject p2;
    private bool phase = false;
    public float speed = 20;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (phase) {
            if (transform.position.x == p2.transform.position.x)
            {
                phase = false;
            }
        } else if (!phase)
        {
            if (transform.position.x == p1.transform.position.x)
            {
                phase = true;
            }
        }

        if (!phase) {
            transform.position = Vector3.Lerp(transform.position, p2.transform.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, p1.transform.position, Time.deltaTime * speed);
        }
        
    }
}
