using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    public float jumpVeloctiy;

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVeloctiy;

        }      
    }
}
