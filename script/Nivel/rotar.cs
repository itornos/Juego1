using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotar : MonoBehaviour
{

    Vector3 rotacion;
    // Start is called before the first frame update
    void Start()
    {
        rotacion.z = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotacion * Time.deltaTime);
    }
}
