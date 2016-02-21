using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {

    Vector3 lookPos;
    Rigidbody rigidBody;

    public float Speed = 4;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        TurnPlayerWithMouse();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rigidBody.AddForce(movement * Speed / Time.deltaTime);

    }

    private void TurnPlayerWithMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        Vector3 lookDirection = lookPos - transform.position;
        lookDirection.y = 0;

        transform.LookAt(transform.position + lookDirection, Vector3.up);
    }

}
