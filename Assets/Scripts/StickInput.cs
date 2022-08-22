using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StickInput : MonoBehaviour
{
    private StickInputActions _input;
    // Start is called before the first frame update
    void Start()
    {
        _input = new StickInputActions();
        _input.Player.Enable();

        //_input.Player.Movement.performed += Movement_performed;
    }

    // private void Movement_performed(InputAction.CallbackContext ctx)
    // {
    //     var move = _input.Player.ReadValue<Vector2>();
    // }

    // Update is called once per frame
    void Update()
    {
        var move = _input.Player.Movement.ReadValue<Vector2>();
        transform.Translate(new Vector3(move.x,0,0)*Time.deltaTime * 5);
    }
}
