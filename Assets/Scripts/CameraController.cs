using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target
    public float distance = 10.0f;
    // the height we want the camera to be above the target
    public float height = 5.0f;
    // How much we 
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    private int camPos = 0;
    private Quaternion currentRotation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (camPos == 3)
                camPos = 0;
            else
                camPos++;
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            if (camPos == 0)
                camPos = 3;
            else
                camPos--;
        }

        turnCamera();
    }

    // Place the script in the Camera-Control group in the component menu
    //[AddComponentMenu("Camera-Control/Smooth Follow")]

    void LateUpdate()
    {
        // Early out if we don't have a target
        if (!target) return;

        // Calculate the current rotation angles
        float wantedHeight = target.position.y + height;
        
        float currentHeight = transform.position.y;
        

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Always look at the target
        transform.LookAt(target);
    }

    void turnCamera()
    {
        float wantedRotationAngle = camPos * 90;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, 3 * Time.deltaTime);

        currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Always look at the target
        transform.LookAt(target);
    }
}