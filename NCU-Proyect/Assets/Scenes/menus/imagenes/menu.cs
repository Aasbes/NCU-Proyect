using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject flecha, lista;
    int indice = 0;
    // Start is called before the first frame update
    void Start()
    {
        Dibujar();
    }

    // Update is called once per frame
    void Update()
    {
        bool up = Input.GetKeyDown("w");
        bool down = Input.GetKeyDown("s");

        if (up) indice--;
        if (down) indice++;

        if (indice > lista.transform.childCount - 1) indice = 0;
        else if (indice < 0) indice = lista.transform.childCount - 1;
        if (up || down) Dibujar();
    }

    void Dibujar()
    {

        Transform opcion = lista.transform.GetChild(indice);
        flecha.transform.position = opcion.position;
    }
}
