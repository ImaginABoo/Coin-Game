using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //1- get the camera movement with the mouse
    [SerializeField] Transform playerCamera = null;

    //5-
    // regarding the rotational speed of the player => give inital value to the mouse sensitivity 
    [SerializeField] float mouseSensitivity = 3.5f; //can be adjusted in the editor based on your convenience 

    //7- regarding the camera pitch: cameraPitch => keeps track of the camera's current X rotation
    float cameraPitch = 0.0f; //means it begins looking directly forward 

    //11- 
    [SerializeField] bool lockCursor = true ;  //true by default in order to lock the cursor once the play mode is started
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -9.8f;
    public Transform GroundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public float jumpHeight = 5f;

    Vector3 velocity;
    bool isGrounded;
    
    


    // Start is called before the first frame update
    void Start()
    {
        //12- check if the lockCursor boolean is true
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked; //locks the cursor to the center of the screen
            Cursor.visible = false; //invisible cursor 
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    //2- 
    //regarding all the mouse look functionality
    void UpdateMouseLook()
    {
        //3-
        //retrieving the horizontal & vertical axes of the mouse 
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));     

        //4- 
        //connecting the mouse horizontal motion with the camera(player) movement 
        // up => (0,1,0)
        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity); //6- * by the mouse sensitivity value to adjust the rotation speed

        //8- we want the mouse delta to influence the camera pitch
        cameraPitch -= mouseDelta.y * mouseSensitivity; // subtract in order to have the inverse of the delta

        //9- clamping the value of cameraPitch between 90 & -90 only to prevent the upside down flipping
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        //10- setting the camera's euler angles to rotate around the x axis by cameraPitch value
        playerCamera.localEulerAngles = Vector3.right * cameraPitch; // right => (1,0,0)

    }

    /* Task: a- Movement of the player => walking around with [WASD] keys 
             b- Gravity Control => overcoming the floating issue
             c- Jumping functionality */
    

   void UpdateMovement()
     {
         isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
         if(isGrounded && velocity.y <0){
             velocity.y = -2f;
         }

         if(Input.GetButtonDown("Jump") && isGrounded){
             
             velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
         }
         float x = Input.GetAxis("Horizontal");
         float z = Input.GetAxis("Vertical");
         
         Vector3 playerMove = transform.right * x + transform.forward * z;
         controller.Move(playerMove * speed * Time.deltaTime);

         velocity.y += gravity * Time.deltaTime;

         controller.Move(velocity * Time.deltaTime);

     }
}
