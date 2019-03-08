using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float CameraDistance{ get; set; }

    public Transform cameraTarget;
    public float zoomSpeed = 5f;

    private Camera playerCamera;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        CameraDistance = 20f;
        playerCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTarget != null)
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
            {
                float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
                playerCamera.fieldOfView -= scroll * zoomSpeed;
            }

            transform.position = new Vector3(cameraTarget.position.x,
                cameraTarget.position.y + CameraDistance, cameraTarget.position.z - CameraDistance + 10);
        }
    }
}
