using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaAscensor : MonoBehaviour
{

    public GameObject pj;
    private Animator puertaAscensor;
    public AudioSource sonidoAscensor;

    // Start is called before the first frame update
    void Start()
    {
        puertaAscensor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(pj)) 
        {
            puertaAscensor.SetBool("Abrir", true);
            sonidoAscensor.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(pj))
        {
            puertaAscensor.SetBool("Abrir", false);
            sonidoAscensor.Play();
        }
    }
}
