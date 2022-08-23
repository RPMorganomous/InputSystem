using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class SliderInput : MonoBehaviour
{
    private SliderInputActions _input;
    [SerializeField]
    private Slider _slider;

    private bool _isCharging = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _input = new SliderInputActions();
        _input.Enable();

        _input.ProgressBar.Charge.started += Charging_started;
        _input.ProgressBar.Charge.canceled += Charging_canceled;
    }

    private void Charging_canceled(InputAction.CallbackContext obj)
    {
        _isCharging = false;
    }

    private void Charging_started(InputAction.CallbackContext obj)
    {
        //start charging
        _isCharging = true;
        StartCoroutine(ChargeBarRoutine());
    }

    IEnumerator ChargeBarRoutine()
    {
        while (_isCharging == true)
        {
            _slider.value += (1.0f * Time.deltaTime) /3f;
            yield return null;
        }

        while (_isCharging == false & _slider.value > 0)
        {
            _slider.value -= (1.0f * Time.deltaTime) /5f;
            yield return null;
        }
    }
}
