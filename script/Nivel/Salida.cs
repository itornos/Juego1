using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour
{
    public GameObject pj;
    public key key;

    public AudioSource sonidoPuerta;
    private Animator salidaA;
    private bool repetir = true;

    // Start is called before the first frame update
    void Start()
    {
        key = FindObjectOfType<key>();
        pj = GameObject.Find("Moñeco");
        salidaA = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(pj) && repetir && key.recoger == 0) 
        {
            salidaA.SetInteger("Recogida", 0);
            sonidoPuerta.Play();
            StartCoroutine(LoadLevelAfterDelay());
            repetir = false;
        }
    }

    IEnumerator LoadLevelAfterDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Nivel2");
    }
}
