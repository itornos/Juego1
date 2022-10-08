using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject pj;
    public int recoger = -1;
    public AudioSource sonidoLlaveRecogida;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == pj.name)
        {
            recoger = 0;
            sonidoLlaveRecogida.Play();
            Destroy(gameObject, 2f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 4, transform.position.z);
        }
    }
}
