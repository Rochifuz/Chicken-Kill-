using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script que se encuentra en el player
public class PlayerMovement : MonoBehaviour
{
    //Camara
    public Transform cam;//Posicion de camara
    float vMouse;//Variable del eje vertical
    float hMouse;//Variable del eje horizontal
    float yReal = 0.0f;//Variable del eje y
    public float horizontalSpeed;//Variable del la velocidad del eje h
    public float verticalSpeed;//Variable del la velocidad del eje v
    //Movimiento
    public CharacterController controller;//Control del personaje mediante la funcion Move
    public float speed = 10f;
    float x;//Variable del movimiento horizontal
    float z;//Variable del movimiento vertical
    Vector3 move; //Variable que te trasforma constantemente la direccion
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
        Cursor.lockState = CursorLockMode.Locked;//bloquea el cursor para cuando se mueva la camara del player
        jumpValue = Mathf.Sqrt(jumpForce * -2 * gravity);//fuerza del salto
    }

    // Update is called once per frame
    void Update()
    {
        LookMouse();//actualiza la camara adonde se vea el mouse

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

    void Movement()//funcion de movimiento
    {
        x = Input.GetAxis("Horizontal");//Es a y d
        z = Input.GetAxis("Vertical");//Es w y s

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime); 
    }

    void Jump()//funcion de salto
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            velocity.y = jumpValue;
        }
    }

    //Cuando el personaje colisiona con el piso y el Grounded vuelva a true

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

