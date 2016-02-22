using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {

    Vector3 lookPos;
    Rigidbody rigidBody;

    public float Speed = 6;

    public Transform camPos;

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
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += camPos.transform.forward * Time.deltaTime * Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= camPos.transform.forward * Time.deltaTime * Speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= camPos.transform.right * Time.deltaTime * Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += camPos.transform.right * Time.deltaTime * Speed;
        }

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
