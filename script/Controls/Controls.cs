using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    public PlayerControls controls;
    GameObject x;
    GameObject a;
    GameObject b;
    GameObject y;
    //Holaaaaaaa
    GameObject FUp;
    GameObject FDown;
    GameObject FLeft;
    GameObject FDer;

    GameObject JLeft;
    Vector2 moveLeft;
    float JLeftposX;
    float JLeftposY;

    GameObject JRight;
    Vector2 moveRight;
    float JRightposX;
    float JRightposY;

    GameObject L1;
    GameObject R1;

    GameObject L2;
    float L2Value;
    float L2Y;

    GameObject R2;
    float R2Value;
    float R2Y;

    void Start()
    {
        x = GameObject.Find("X");
        a = GameObject.Find("A");
        b = GameObject.Find("B");
        y = GameObject.Find("Y");
        
        FUp = GameObject.Find("FUp");
        FDown = GameObject.Find("FDown");
        FLeft = GameObject.Find("FLeft");
        FDer = GameObject.Find("FDer");
        
        JLeft = GameObject.Find("Joystick");
        JLeftposX = JLeft.transform.position.x;
        JLeftposY = JLeft.transform.position.y;

        JRight = GameObject.Find("Joystick2");
        JRightposX = JRight.transform.position.x;
        JRightposY = JRight.transform.position.y;

        L1 = GameObject.Find("L1");
        R1 = GameObject.Find("R1");

        L2 = GameObject.Find("L2");
        L2Y = L2.transform.position.y;

        R2 = GameObject.Find("R2");
        R2Y = R2.transform.position.y;
    }

    void Awake() {
        controls = new PlayerControls();

        controls.Gameplay.A.started += ctx => Grow(a);
        controls.Gameplay.A.canceled += ctx => Decrease(a);

        controls.Gameplay.B.started += ctx => Grow(b);
        controls.Gameplay.B.canceled += ctx => Decrease(b);

        controls.Gameplay.X.started += ctx => Grow(x);
        controls.Gameplay.X.canceled += ctx => Decrease(x);

        controls.Gameplay.Y.started += ctx => Grow(y);
        controls.Gameplay.Y.canceled += ctx => Decrease(y);

        controls.Gameplay.FlechaIzq.started += ctx => Grow(FLeft);
        controls.Gameplay.FlechaIzq.canceled += ctx => Decrease(FLeft);

        controls.Gameplay.FlechasDer.started += ctx => Grow(FDer);
        controls.Gameplay.FlechasDer.canceled += ctx => Decrease(FDer);

        controls.Gameplay.FlechaUp.started += ctx => Grow(FUp);
        controls.Gameplay.FlechaUp.canceled += ctx => Decrease(FUp);

        controls.Gameplay.FlechasDown.started += ctx => Grow(FDown);
        controls.Gameplay.FlechasDown.canceled += ctx => Decrease(FDown);

        controls.Gameplay.JLeft.performed += ctx => moveLeft= ctx.ReadValue<Vector2>();
        controls.Gameplay.JLeft.canceled += ctx => moveLeft = Vector2.zero;

        controls.Gameplay.JRight.performed += ctx => moveRight = ctx.ReadValue<Vector2>();
        controls.Gameplay.JRight.canceled += ctx => moveRight = Vector2.zero;

        controls.Gameplay.L1.started += ctx => Grow(L1);
        controls.Gameplay.L1.canceled += ctx => Decrease(L1);

        controls.Gameplay.R1.started += ctx => Grow(R1);
        controls.Gameplay.R1.canceled += ctx => Decrease(R1);
    }

    void Update()
    {
        JLeft.transform.position = new Vector3(-moveLeft.x + JLeftposX, moveLeft.y + JLeftposY, JLeft.transform.position.z);

        JRight.transform.position = new Vector3(-moveRight.x + JRightposX, moveRight.y + JRightposY, JRight.transform.position.z);

        L2.transform.position = new Vector3(L2.transform.position.x, controls.Gameplay.L2.ReadValue<float>()*10 + L2Y, L2.transform.position.z); ;

        R2.transform.position = new Vector3(R2.transform.position.x, controls.Gameplay.R2.ReadValue<float>()*10 + R2Y, R2.transform.position.z);

        Debug.Log(R2Value);
        Debug.Log(L2Value);
    }

    void Grow(GameObject objeto){
        objeto.transform.localScale *= 1.05f;
    }

    void Decrease(GameObject objeto)
    {
        objeto.transform.localScale /= 1.05f;
    }

    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Disable();
    }
}
