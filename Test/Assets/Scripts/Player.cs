using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyPressed = false;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true) {
            jumpKeyPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }
    
    // Fixed Update is called once every physics update
    void FixedUpdate() {
        if (jumpKeyPressed) {
             GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.VelocityChange);
             jumpKeyPressed = false;   
        }
        GetComponent<Rigidbody>().velocity = new Vector3(horizontalInput, GetComponent<Rigidbody>().velocity.y, 0);
    }
}
