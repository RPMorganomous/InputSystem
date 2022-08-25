using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private PlayerOne _player;

    private PlayerManagerInputActions _input;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeInputs();
    }

    // Update is called once per frame
    void Update()
    {
        var move = _input.Player.Movement.ReadValue<Vector2>();
        _player.Move(move);
    }

    private void InitializeInputs()
    {
        _input = new PlayerManagerInputActions();
        _input.Player.Enable();
    }
}
