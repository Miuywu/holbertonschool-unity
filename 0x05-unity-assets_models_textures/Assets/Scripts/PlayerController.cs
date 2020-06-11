using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides player movement.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public Transform cam;
    private Transform playerTransform;
    private CharacterController controller;
    private Vector3 spawnPosition;
    private float speed = 10f;
    private float jumpHeight = 2f;
    private float gravity = -9.81f;
    private Vector3 vel;



    /// <summary>
    /// Initializes components and spawn position.
    /// </summary>
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerTransform = GetComponent<Transform>();
        spawnPosition = playerTransform.position;
        spawnPosition.y += 20;
    }

    /// <summary>
    /// Computes player movement every frame.
    /// </summary>
    void Update()
    {
        threeD_move();
        y_Check();
    }

    void threeD_move()
    {
        if (controller.isGrounded && vel.y < 0)
        {
            vel.y = -0.01f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0f, z).normalized;
        Vector3 f = Vector3.zero;

        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            f =  moveDir * speed * Time.deltaTime;
        }

        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            vel.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        vel.y += gravity * Time.deltaTime;
        controller.Move(vel * Time.deltaTime + f);
    }

    void y_Check()
    {
        if (playerTransform.position.y < -20)
        {
            playerTransform.position = spawnPosition;
        }
    }
}
