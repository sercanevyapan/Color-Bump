using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastMousePos;
    public float sensitivity = .16f, clampDelta = 42f;

    public float bounds = 5;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }


    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            lastMousePos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            Vector3 vector = lastMousePos - Input.mousePosition;
            lastMousePos = Input.mousePosition;
            vector = new Vector3(vector.x, 0, vector.y);

            Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);
            rb.AddForce(/*Vector3.forward *2 +*/ (-moveForce * sensitivity - rb.velocity/5), ForceMode.VelocityChange);
        }
    }
}