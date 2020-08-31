using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameOver : MonoBehaviour
{

    public string tipoPantalla;
    public TextMeshProUGUI cantidadCarpetas;
    public TextMeshProUGUI cantidadmonedas;
    public TextMeshProUGUI cantidadLlaves;
    //int suma;
    int cantidadC;
    int cantidadM;
    int cantidadL;
    bool activo;
    Canvas canvas;
   // public GameObject panel;
    //public string nombre;
    // Start is called before the first frame update
   
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = true;
        if (tipoPantalla.Equals("juegoCompletado"))
        {
            cantidadC = PlayerPrefs.GetInt("TotalCarpeta", 0);
            cantidadCarpetas.text = cantidadC.ToString() + "carpetas";

            cantidadM = PlayerPrefs.GetInt("TotalMoneda", 0);
            cantidadmonedas.text = cantidadM.ToString() + "monedas";

            cantidadL = PlayerPrefs.GetInt("TotalLLave", 0);
            cantidadLlaves.text = cantidadL.ToString() + "llaves";


            PlayerPrefs.SetInt("TotalCarpeta", 0);
            PlayerPrefs.SetInt("TotalMoneda", 0);
            PlayerPrefs.SetInt("TotalLLave", 0);


        }
       

        if (tipoPantalla.Equals("nivelTerminado"))
        {
            //suma = PlayerPrefs.GetInt("TotalCarpeta") + PlayerPrefs.GetInt("carpeta");
            PlayerPrefs.SetInt("TotalCarpeta", PlayerPrefs.GetInt("TotalCarpeta") + PlayerPrefs.GetInt("carpeta"));
            //suma = PlayerPrefs.GetInt("TotalMoneda") + PlayerPrefs.GetInt("moneda");
            PlayerPrefs.SetInt("TotalMoneda", PlayerPrefs.GetInt("TotalMoneda") + PlayerPrefs.GetInt("moneda"));
            //suma = PlayerPrefs.GetInt("TotalLLave") + PlayerPrefs.GetInt("llave");
            PlayerPrefs.SetInt("TotalLLave", PlayerPrefs.GetInt("TotalLLave") + PlayerPrefs.GetInt("llave"));

            cantidadC = PlayerPrefs.GetInt("carpeta", 0);
            cantidadCarpetas.text = cantidadC.ToString() + "carpetas";

            cantidadM = PlayerPrefs.GetInt("moneda", 0);
            cantidadmonedas.text = cantidadM.ToString() + "monedas";

            cantidadL = PlayerPrefs.GetInt("llave", 0);
            cantidadLlaves.text = cantidadL.ToString() + "llaves";

        }
        if (tipoPantalla.Equals("GameOver"))
        {
            cantidadC = PlayerPrefs.GetInt("carpeta", 0);
            cantidadCarpetas.text = cantidadC.ToString() + "carpetas";

            cantidadM = PlayerPrefs.GetInt("moneda", 0);
            cantidadmonedas.text = cantidadM.ToString() + "monedas";

            cantidadL = PlayerPrefs.GetInt("llave", 0);
            cantidadLlaves.text = cantidadL.ToString() + "llaves";
        }
        /*
        else if (tipoPantalla.Equals("juegoCompletado"))
        {
            

        }
        */



    }

    // Update is called once per frame
    void Update()
    {
        

       
    }




    public void IrMenu()
    {
        
        
        PlayerPrefs.SetInt("carpeta", 0);
        PlayerPrefs.SetInt("moneda", 0);
        PlayerPrefs.SetInt("llave", 0);
        PlayerPrefs.SetFloat("vida", 100);
        PlayerPrefs.SetFloat("vida2", 100);

        
        SceneManager.LoadScene("menuInicial");
        

    }

    
}
