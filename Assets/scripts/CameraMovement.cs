using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speed;

    [HideInInspector] public bool canMove = false;
	
	// Update is called once per frame
	void LateUpdate () {
        if(canMove)
            transform.position += Vector3.up * speed * Time.deltaTime;
	}
}
