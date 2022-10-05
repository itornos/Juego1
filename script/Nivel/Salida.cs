using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour
{
    float distanciaX;
    float distanciay;
    float distanciaz;
    private GameObject pj;
    public key key;
    private Animator salidaA;

    // Start is called before the first frame update
    void Start()
    {
        key = FindObjectOfType<key>();
        pj = GameObject.Find("Moñeco");
        salidaA = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (key.recoger == 0) 
        {
            salidaA.SetInteger("Recogida", 0);
            distanciaX = pj.transform.position.x - transform.position.x;
            distanciay = pj.transform.position.y - transform.position.y;
            distanciaz = pj.transform.position.z - transform.position.z;

            if (distanciaX < 0) distanciaX = -distanciaX;
            if (distanciaz < 0) distanciaz = -distanciaz;
            if (distanciay < 0) distanciay = -distanciay;

            if (distanciaX < 1.0f && distanciaz < 1.0f && distanciay < 1.0f)
            {
                SceneManager.LoadScene("Nivel2");
            }
        }
    }
}
