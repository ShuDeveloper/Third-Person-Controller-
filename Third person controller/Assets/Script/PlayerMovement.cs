using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;

    Vector3 directions;
    Vector3 vilocity;

    CharacterController controller;
    Animator animator;

    [SerializeField] bool isGrounded;
    [SerializeField] float distaceGround;
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] float Gravity;
    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();    

    }

    // Update is called once per frame
    void Update()
    {
        
        move();
    }
   void move()
    {
        isGrounded = Physics.CheckSphere(transform.position, distaceGround, GroundLayer);
        if (isGrounded)
        {
            vilocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        directions = new Vector3(0, 0, moveZ);

        if (directions != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            //Walk Animation playe 
            animator.SetFloat("Move", 0.5f);
            moveSpeed = walkSpeed;
        }
        else if (directions != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            //Run Animation playe 
            animator.SetFloat("Move", 1f);
            moveSpeed = runSpeed;
        }
        else if (directions == Vector3.zero)
        {
            //idle Animation playe 
            animator.SetFloat("Move", 0.0f);
        }
        directions *= moveSpeed * Time.deltaTime;
        directions = transform.TransformDirection(directions);
        controller.Move(directions);

        vilocity.y += Gravity * Time.deltaTime;
        controller.Move(vilocity);
    }
    
}  
