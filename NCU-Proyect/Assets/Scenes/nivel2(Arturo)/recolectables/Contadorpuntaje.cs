using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contadorpuntaje : MonoBehaviour
{
    public static Contadorpuntaje instance;
    public TextMeshProUGUI cantidadCarpetas;
    public TextMeshProUGUI cantidadmonedas;
    public TextMeshProUGUI cantidadLlaves;
    int cantidadC;
    int cantidadM;
    int cantidadL;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int recolectado, string nombre)
    {
        if (nombre == "carpeta")
        {
            cantidadC += recolectado;
            cantidadCarpetas.text = cantidadC.ToString();
        }
        else
        {
            if (nombre == "moneda")
            {
                cantidadM += recolectado;
                cantidadmonedas.text = cantidadM.ToString();
            }
            else
            {

                cantidadL += recolectado;
                cantidadLlaves.text = cantidadL.ToString()+" /4";

            }
            
        }
    }
}
