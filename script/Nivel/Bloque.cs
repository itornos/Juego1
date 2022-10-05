using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bloque : MonoBehaviour 
{
    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
    }

    void Update()
    {
        transform.Rotate(0, (controls.Gameplay.L1.ReadValue<float>() * 100f * Time.deltaTime), 0);
        transform.Rotate(0,-(controls.Gameplay.R1.ReadValue<float>() * 100f * Time.deltaTime), 0);
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
