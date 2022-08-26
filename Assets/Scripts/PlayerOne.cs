using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private GameObject _projectile;
    
    private float _canFire = -1f;
    [SerializeField]
    private float _fireDelay = 0.5f;
    public void Move(Vector2 direction)
    {
        transform.Translate(direction*Time.deltaTime*_speed);
    }

    public void Fire()
    {
        if(Time.time > _canFire)
        {
            _canFire = Time.time + _fireDelay;
            Instantiate(_projectile, transform.position, Quaternion.identity);
        }
    }
}
