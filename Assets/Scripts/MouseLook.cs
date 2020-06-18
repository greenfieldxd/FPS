using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensivity = 50f;
    [SerializeField] Transform mainCamera;
    [Header("")]
    [SerializeField] float maxY = 90f;
    [SerializeField] float minY = -90f;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseVertical = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseHorizontal);
        //mainCamera.Rotate(Vector3.right, -mouseVertical);

        xRotation -= mouseVertical;
        xRotation = Mathf.Clamp(xRotation, minY, maxY);
        mainCamera.localRotation = Quaternion.Euler(xRotation, 0, 0); 
    }
}
