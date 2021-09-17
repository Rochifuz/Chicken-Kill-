using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;
    float vMouse;
    float hMouse;
    float yReal = 0.0f;
    public float horizontalSpeed;
    public float verticalSpeed;
    public CharacterController controller;
    public float speed = 10f;
    float x;
    float z;
    Vector3 move; 
  


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LookMouse();
        Movement();
    }

    void LookMouse()
    {
        hMouse = Input.GetAxis("Mouse X") * horizontalSpeed * Time.deltaTime;
        vMouse = Input.GetAxis("Mouse Y") * verticalSpeed * Time.deltaTime;

        yReal -= vMouse; 
        //Para que cuando subamos mouse vaya para arriba
        yReal = Mathf.Clamp(yReal, -90f, 90f); 
        //Limites de mouse
        transform.Rotate(0f, hMouse, 0f); 
        //Rote en eje y
        cam.localRotation = Quaternion.Euler(yReal, 0f, 0f); 
        //Controlador de rotacion
    }

    void Movement()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime); 
    }
}
