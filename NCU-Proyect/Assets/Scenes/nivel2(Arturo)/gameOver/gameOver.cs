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

            cantidadC = PlayerPrefs.GetInt("carpeta", 0);
            cantidadCarpetas.text = cantidadC.ToString() + "carpetas";

            cantidadM = PlayerPrefs.GetInt("moneda", 0);
            cantidadmonedas.text = cantidadM.ToString() + "monedas";

            cantidadL = PlayerPrefs.GetInt("llave", 0);
            cantidadLlaves.text = cantidadL.ToString() + "llaves";


        




    }

    // Update is called once per frame
    void Update()
    {
        

       
    }




    public void IrMenu()
    {
        SceneManager.LoadScene("menuInicial");
        int suma = 0;
        if (tipoPantalla.Equals("nivelTerminado"))
        {
            suma = PlayerPrefs.GetInt("TotalCarpeta") + PlayerPrefs.GetInt("carpeta");
            PlayerPrefs.SetInt("TotalCarpeta", suma);
            suma = PlayerPrefs.GetInt("TotalMoneda") + PlayerPrefs.GetInt("moneda");
            PlayerPrefs.SetInt("TotalMoneda", suma);
            suma = PlayerPrefs.GetInt("TotalLLave") + PlayerPrefs.GetInt("llave");
            PlayerPrefs.SetInt("TotalLLave", suma);

        }
        PlayerPrefs.SetInt("carpeta", 0);
        PlayerPrefs.SetInt("moneda", 0);
        PlayerPrefs.SetInt("llave", 0);
        PlayerPrefs.SetFloat("vida", 100);
        PlayerPrefs.SetFloat("vida2", 100);


    }

}
