using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null; 
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyPressed = false;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
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
        rigidBodyComponent.velocity = new Vector3(horizontalInput * 2, rigidBodyComponent.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0) {
            return;
        }
        if (jumpKeyPressed) {
             rigidBodyComponent.AddForce(Vector3.up * 6, ForceMode.VelocityChange);
             jumpKeyPressed = false;   
        }
       
    }
}
