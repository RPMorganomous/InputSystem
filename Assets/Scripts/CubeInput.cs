using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class CubeInput : MonoBehaviour
{
    // 1) get a reference and start an instance of the input actions
    private CubeInputActions _input;

    private MeshRenderer _render;
    private float _speed = 5;

    private void Start()
    {
        // 2) enable input action map (cube)
        _input = new CubeInputActions();
        _input.Cube.Enable();
        
        // 3) register perform functions
        _input.Cube.ChangeColor.performed += ChangeColor_performed;
        _input.Cube.DrivingState.performed += DrivingStateOnperformed;
        _input.Driving.DrivingState.performed += DrivingStateOnperformed;

        //get handle on the mesh renderer so I can change the colors
        _render = GetComponent<MeshRenderer>();
    }

    private void DrivingStateOnperformed(InputAction.CallbackContext obj)
    {
        if (_input.Cube.enabled)
        {
            _input.Cube.Disable();
            _input.Driving.Enable();
        }
        else
        {
            _input.Driving.Disable();
            _input.Cube.Enable();
        }
    }

    private void Update()
    {
        Debug.Log("Axis Value: " + _input.Cube.Rotate.ReadValue<float>());
        var rotateDirection = _input.Cube.Rotate.ReadValue<float>();
        transform.Rotate(Vector3.up * Time.deltaTime * 30f * rotateDirection);
        
        var move = _input.Driving.DriveWASD.ReadValue<Vector2>();
        transform.Translate(new Vector3(move.x, 0, move.y)* Time.deltaTime * _speed);
    }
    
    private void ChangeColor_performed(InputAction.CallbackContext context)
    {
        // change the color randomly
        _render.material.color = Random.ColorHSV();
    }
}
