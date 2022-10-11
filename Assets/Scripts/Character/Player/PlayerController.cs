using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    #region Declare Variable
    private CharacterController controller;
    private Animator anim;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    private Vector3 moveDirection = Vector3.zero;
    
    [SerializeField] private float gravity;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isChaGrounded = false;
    private Vector3 jumpVelocity = Vector3.zero;
    #endregion

    void Start(){
        GetReferences();
        InitVariables();
    }

    void Update(){
        HandleIsGrounded(); 
        HandleRunning();
        HandleJumping();
        HandleGravity();

        HandleMovement();
        HandleAnimations();
    }

    private void GetReferences(){
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    private void InitVariables(){
        moveSpeed = walkSpeed;
    }

    private void HandleMovement(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = moveDirection.normalized;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime * moveSpeed);
    }
    private void HandleRunning(){
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            moveSpeed = runSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            moveSpeed = walkSpeed;
        }
    }
    private void HandleJumping(){
        if(Input.GetKeyDown(KeyCode.Space) && isChaGrounded){
            jumpVelocity.y += Mathf.Sqrt(jumpForce * gravity * -2.0f);
        }
    }
    private void HandleIsGrounded(){
        isChaGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
    }
    private void HandleGravity(){
        if(isChaGrounded && jumpVelocity.y < 0){
            jumpVelocity.y = -1.0f;
        }
        jumpVelocity.y += gravity * Time.deltaTime;
        controller.Move(jumpVelocity * Time.deltaTime);
    }
    private void HandleAnimations(){
        if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){
            anim.SetFloat("Speed", 1.0f, 0.1f, Time.deltaTime);
        }
        else{
            anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        }
    }
}