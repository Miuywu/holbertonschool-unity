using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// handle user input so the player can move left, right, forward, backward, diagonally and jump using the WASD and space keys.
/// </summary>
public class PlayerController : MonoBehaviour
{
     public float speed = 8.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Transform camera;

    private Vector3 movement = Vector3.zero;
    private Vector3 startPos;
    private CharacterController cc;
    private Transform t;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        t = GetComponent<Transform>();
        startPos = t.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (cc.isGrounded)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            movement = camera.right * movement.x + camera.forward * movement.z;
            movement *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                movement.y = jumpSpeed;
            }
        }
        else
        {
            float y = movement.y;
            movement = new Vector3(Input.GetAxis("Horizontal"), y, Input.GetAxis("Vertical"));
            movement = camera.right * movement.x + camera.forward * movement.z;
            movement.y = y;
            movement = transform.TransformDirection(movement);
            movement.x *= speed;
            movement.z *= speed;
        }
        
        movement.y -= gravity * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
        //respawn
        if (t.position.y < -15)
        {
            movement = new Vector3(0.0f, movement.y, 0.0f);
            cc.Move(movement * Time.deltaTime);
            t.position = new Vector3(startPos.x, startPos.y + 15, startPos.z);
        }
    }
}
