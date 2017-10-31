using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
    private Vector2 velocity;
    public GameObject player;
    public float smoothTimeY;
    public float smoothTimeX;

    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX + 1.5f, posY + 0.5f, transform.position.z);
    }
}
