using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private int _speed;

    // 1. get a reference and star an instance of our input actions
    private PlayerInputActions _input;

    private void Start()
    {
        // 2. enable input action map (dog)
        _input = new PlayerInputActions();
        _input.Dog.Enable();
        
        // 3. register perform functions
        _input.Dog.Bark.performed += Bark_performed;
        _input.Dog.Bark.canceled += Bark_canceled;
        _input.Dog.Walk.performed += Walk_performed;
        _input.Dog.Run.performed += Run_performed;
        _input.Dog.Run.canceled += Run_canceled;
        _input.Dog.Die.performed += Die_performed;
    }

    private void Update()
    {
        //poll or check input readings
        var move = _input.Dog.Walk.ReadValue<Vector2>();
        transform.Translate(new Vector3(move.x, 0, move.y) * Time.deltaTime * _speed);
    }

    private void Walk_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Walking..." + context);
        Debug.Log($"X: {context.ReadValue<Vector2>().x} Y: {context.ReadValue<Vector2>().y}");
    }
    
    private void Die_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Died..." + context);
    }

    private void Run_canceled(InputAction.CallbackContext context)
    {
        Debug.Log("Done running." + context);
    }

    private void Run_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Running..." + context);
    }

    private void Bark_canceled(InputAction.CallbackContext context)
    {
        Debug.Log("Done Barking..." + context);
    }

    private void Bark_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Barking..." + context);
    }
}


