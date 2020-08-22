using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolectable : MonoBehaviour
{
    public int valor = 1;
    public string nombreObjeto;
    public void OnCollisionEnter2D(Collision2D tocando)
    {
        if (tocando.gameObject.tag == "jugador")
        {
            Contadorpuntaje.instance.ChangeScore(valor,nombreObjeto);
        }
    }
}
