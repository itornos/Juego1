using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarX : MonoBehaviour
{
    Vector3 rotacion;

    // Start is called before the first frame update
    void Start()
    {
        rotacion.x = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotacion * Time.deltaTime);
    }
}
