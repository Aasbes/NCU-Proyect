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
    float vida;
    
    void Awake()
    {
        /*
        
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);


        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }
        */

    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;

        }
        /*
        cantidadC = PlayerPrefs.GetInt("carpeta", 0);
        cantidadM = PlayerPrefs.GetInt("moneda", 0);
        cantidadL = PlayerPrefs.GetInt("llave", 0);
        */

        

        cantidadCarpetas.text = PlayerPrefs.GetInt("carpeta", 0).ToString();
        cantidadmonedas.text = PlayerPrefs.GetInt("moneda", 0).ToString();
        cantidadLlaves.text = PlayerPrefs.GetInt("llave", 0).ToString() + " /4";
    }

    public void ChangeScore(int recolectado, string nombre,string jugador)
    {
        if (nombre == "carpeta")
        {
            cantidadC = PlayerPrefs.GetInt("carpeta", 0)+ recolectado;
            PlayerPrefs.SetInt("carpeta", cantidadC);
            cantidadCarpetas.text = PlayerPrefs.GetInt("carpeta", 0).ToString();
        }
        else
        {
            if (nombre == "moneda")
            {
                cantidadM = PlayerPrefs.GetInt("moneda", 0)+ recolectado;
                PlayerPrefs.SetInt("moneda", cantidadM);
                cantidadmonedas.text = cantidadM.ToString();

            }
            else
            {
                if (nombre == "MasVida")
                {
                    if (jugador.Equals("jugador1"))
                    {
                        vida = PlayerPrefs.GetFloat("vida") + 20;
                        //barraVidaPersonaje.SendMessage("dañoRecibido",-10);
                        //float nuevaVida = PlayerPrefs.GetFloat("vida")+10;
                        if (vida > 100)
                        {
                            PlayerPrefs.SetFloat("vida", 100);
                        }
                        else
                        {
                            PlayerPrefs.SetFloat("vida", vida);
                        }


                        //salud.transform.localScale = new Vector2(vida / vidaMax, 1);

                    }
                    else if (jugador.Equals("jugador2"))
                    {
                        vida = PlayerPrefs.GetFloat("vida2") + 20;
                        //barraVidaPersonaje.SendMessage("dañoRecibido",-10);
                        //float nuevaVida = PlayerPrefs.GetFloat("vida")+10;
                        if (vida > 100)
                        {
                            PlayerPrefs.SetFloat("vida2", 100);
                        }
                        else
                        {
                            PlayerPrefs.SetFloat("vida2", vida);
                        }
                    }

                }
                else if (nombre == "llave") 
                {

                    cantidadL = PlayerPrefs.GetInt("llave", 0) + recolectado;
                    PlayerPrefs.SetInt("llave", cantidadL);
                    cantidadLlaves.text = cantidadL.ToString() + " /4";
                }
            }
            
        }
    }
}
