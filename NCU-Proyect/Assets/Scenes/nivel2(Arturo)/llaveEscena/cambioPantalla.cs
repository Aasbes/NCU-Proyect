using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioPantalla : MonoBehaviour
{
    public string escenaSiguiente;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D tocando)
    {
        if (tocando.gameObject.tag == "jugador")
        {
            SceneManager.LoadScene(escenaSiguiente);
        }





    }
}
