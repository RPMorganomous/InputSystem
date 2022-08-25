using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    public void Move(Vector2 direction)
    {
        transform.Translate(direction*Time.deltaTime*_speed);
    }
}
