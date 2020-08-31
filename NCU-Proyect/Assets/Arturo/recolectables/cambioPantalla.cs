using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioPantalla : MonoBehaviour
{
    public string escenaSiguiente;
    bool jugador1, jugador2;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("cooperativo") == 2)
        {
            if (jugador1 && jugador2)
            {
                SceneManager.LoadScene(escenaSiguiente);
                jugador1 = false;
                jugador2 = false;
            }

        }
        else if (PlayerPrefs.GetInt("cooperativo") == 1 && jugador1)
        {
            SceneManager.LoadScene(escenaSiguiente);
        }




    }

    public void OnCollisionEnter2D(Collision2D tocando)
    {
        if (tocando.gameObject.tag == "jugador")
        {
            //SceneManager.LoadScene(escenaSiguiente);
            jugador1 = true;
            player = GameObject.FindGameObjectWithTag("jugador");
            Destroy(player);
        }
        else if (tocando.gameObject.tag == "jugador2")
        {
            jugador2 = true;
            player = GameObject.FindGameObjectWithTag("jugador2");
            Destroy(player);
        }





    }
}
