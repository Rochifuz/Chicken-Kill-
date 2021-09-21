using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Camara
    public Transform cam;
    float vMouse;
    float hMouse;
    float yReal = 0.0f;
    public float horizontalSpeed;
    public float verticalSpeed;
    //Movimiento
    public CharacterController controller;
    public float speed = 10f;
    float x;
    float z;
    Vector3 move; 
    //Gravedad
    Vector3 velocity;
    public float gravity = -15f;
    bool isGrounded = false; 
    //Salto
    public float jumpForce = 1f;
    float jumpValue;


  


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        jumpValue = Mathf.Sqrt(jumpForce * -2 * gravity);
    }

    // Update is called once per frame
    void Update()
    {
        LookMouse();

        if(isGrounded ==true && velocity.y < 0)
        {
            velocity.y = gravity;
        }


        Movement();
        Jump();


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
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

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            velocity.y = jumpValue;
        }
    }

    //Cuando el personaje colisiona con algo

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("floor"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }
    }
}

