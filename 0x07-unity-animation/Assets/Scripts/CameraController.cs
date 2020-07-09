using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera follows behind player.
/// </summary>
public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    private Transform camTransform;
    float mouseX, mouseY;
    float distance;

    /// <summary>
    /// locks cursor.
    /// </summary>
    void Start()
    {
        camTransform = GetComponent<Transform>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        distance = Vector3.Distance(camTransform.position, playerTransform.position);
    }

    /// <summary>
    /// Camera rotation with mouse.
    /// </summary>
    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(-mouseY, mouseX, 0);
        camTransform.position = playerTransform.position + rotation * dir;
        
        transform.LookAt(playerTransform.position);
    }
}
