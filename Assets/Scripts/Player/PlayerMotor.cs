using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour //tum hareket kodlarini bir arada toplayan kod.
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    private float sprintMultiplier = 1f;
    public float sprintSpeed = 2f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public AudioSource soundSource;
    public AudioClip scarySound; 
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;               //Fareyi kilitler ve gizler
        controller = GetComponent<CharacterController>();
        soundSource.clip = scarySound;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        
        if(Input.GetKey(KeyCode.LeftShift) && isGrounded){      //Kosma
            sprintMultiplier = sprintSpeed;
        }
        else{
            sprintMultiplier = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jumpscarewall"))                //Duvar ile playerın çarpışmasını algılayan kod
        {
            other.transform.GetChild(0).GetComponent<Crawler>().move=true;
            soundSource.Play();
            Destroy(other.gameObject,1f);
               
        }
    }
    public void ProcessMove(Vector2 input){
        Vector3 moveDirection = Vector3.zero;               //InputManager ile hareket etme yapildi
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection)*speed*sprintMultiplier*Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void Jump(){
        if(isGrounded){
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f *gravity);
        }
    }
}
