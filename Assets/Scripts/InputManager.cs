using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour //Girdi kontrollerini denetleyen kod
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    private Vector2 movementInput;
    private PlayerMotor motor;
    private PlayerLook look;
    public DialogueManager dialogueManagersc;

    void Awake() {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        onFoot.Jump.canceled += ctx => motor.Jump();
    }

    void FixedUpdate()
    {
         if (dialogueManagersc.dialagueIsPlaying)
        {
            return;
        }
        //playermotor a yurume komutu gonder
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        
    }
    private void LateUpdate() {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        
    }

    private void OnEnable() {
        onFoot.Enable();
    }

    private void OnDisable() {
        onFoot.Disable();
    }
}
