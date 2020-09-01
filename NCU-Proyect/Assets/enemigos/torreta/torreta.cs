using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class torreta : MonoBehaviour
{
   // public GameObject gameObject;
   
    public float intervaloDisparo;
    public GameObject balaPrefab;
    float tiempo = 10f;
    public static bool direccion;
    public SpriteRenderer sprit;
    public Transform derecha;
    public Transform izquierda;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       


        direccion = sprit.flipX;
        tiempo += Time.deltaTime;
        if (tiempo >= intervaloDisparo)
        {
            //Instantiate(balaPrefab, origen.position, origen.rotation);
            if (direccion)
            {
                Instantiate(balaPrefab, derecha.position, derecha.rotation);
            }
            else
            {
                Instantiate(balaPrefab, izquierda.position, izquierda.rotation);
            }
            tiempo = 0;


        }



       
    }
    

}

