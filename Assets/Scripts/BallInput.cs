using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallInput : MonoBehaviour
{
    private bool jumped = false;
    
 // 1. get a reference and start an instance of our input actions
 private BallInputActions _input;
    
    // Start is called before the first frame update
    void Start()
    {
        // 2. enable input action map (ball)
        _input = new BallInputActions();
        _input.Ball.Enable();
        
        // 3. register perform functions
        _input.Ball.Jump.performed += Jump_performed;
        _input.Ball.Jump.canceled += Jump_canceled;
    }

    private void Jump_canceled(InputAction.CallbackContext ctx)
    {
        var forceEffect = ctx.duration;
        GetComponent<Rigidbody>().AddForce(Vector3.up * (10 * (float)forceEffect), ForceMode.Impulse);
    }

    private void Jump_performed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Full Jump");
        jumped = true;
        GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
