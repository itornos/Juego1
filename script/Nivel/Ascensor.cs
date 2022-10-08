using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{
    public PlayerControls controls;
    private Animator putoAscensor;
    public GameObject pj;
    public GameObject boton;
    public AudioSource sonidoAscensor;
    private float alturaBoton;
    private int dondeEstoy;
    private bool colision;

    void Start()
    {
        alturaBoton = 7f;
        dondeEstoy = 0;
        colision = false;
        putoAscensor = GetComponent<Animator>();
    }

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.X.started += ctx => ascensor();
    }

    void Update()
    {
        if (colision) boton.transform.position = new Vector3(transform.position.x, transform.position.y + alturaBoton, transform.position.z);
    }

    void ascensor()
    {
        if (colision)
        {
            if (dondeEstoy == 0)
            {
                putoAscensor.SetInteger("estado", dondeEstoy);
                dondeEstoy = 1;
            }
            else if (dondeEstoy == 1)
            {
                putoAscensor.SetInteger("estado", dondeEstoy);
                dondeEstoy = 0;   
            }
            sonidoAscensor.Play();
        }  
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == pj.name)
        {
            colision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == pj.name) {
            boton.transform.position = new Vector3(transform.position.x, transform.position.y - 70f, transform.position.z);
            colision = false;
        }
    }

    //hola

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
