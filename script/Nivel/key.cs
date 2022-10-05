using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    [SerializeField] Vector3 rotacion;
    private GameObject pj;
    private float distanciaX;
    private float distanciay;
    private float distanciaz;
    public int recoger = -1;

    void Start()
    {
        rotacion.y = 30;
        pj = GameObject.Find("Moñeco");
    }
    void Update()
    {
        distanciaX = pj.transform.position.x - transform.position.x;
        distanciay = pj.transform.position.y - transform.position.y;
        distanciaz = pj.transform.position.z - transform.position.z;

        if (distanciaX < 0) distanciaX = -distanciaX;
        if (distanciaz < 0) distanciaz = -distanciaz;
        if (distanciay < 0) distanciay = -distanciay;

        if (distanciaX < 2.0f && distanciaz < 2.0f && distanciay < 2.0f) 
        {
            Destroy(gameObject, 0f);
            recoger = 0;
        }
            
        transform.Rotate(rotacion * Time.deltaTime);
    }
}
