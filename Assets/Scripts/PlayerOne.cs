using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOne : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private int _ammoCount = 15;
    [SerializeField] private TextMeshProUGUI _ammoText;
    
    private float _canFire = -1f;
    [SerializeField]
    private float _fireDelay = 0.5f;

    private void Start()
    {
        _ammoText.text = "AMMO: " + _ammoCount.ToString();
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction*Time.deltaTime*_speed);
    }

    public void Fire()
    {
        if(Time.time > _canFire && _ammoCount > 0)
        {
            _canFire = Time.time + _fireDelay;
            Instantiate(_projectile, transform.position, Quaternion.identity);
            _ammoCount--;
            _ammoText.text = "AMMO: " + _ammoCount.ToString();
        }
    }
}
