using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool activo=false;
    public bool canvasActivo = false;
    Canvas canvas;
    public GameObject configuracion;
    
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = canvasActivo;
        configuracion.SetActive(activo);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown("escape"))
        {
            activo=!activo;
            canvas.enabled = activo;
            Time.timeScale = (activo) ? 0: 1f;

           
        }
        */
    }

    public void pausa()
    {
        Time.timeScale = 0;

        canvas.enabled = true;
       /*
        activo = !activo;
        canvas.enabled = activo;
        Time.timeScale = (activo) ? 0 : 1f;
       */

    }
    public void configuraciones() 
    {

        activo = !activo;
        configuracion.SetActive(activo);
        
    }

    public void Volver()
    {
        Time.timeScale = 1;
        
        canvas.enabled = false;
        
        
    }

    public void Irmenu()
    {
        
        
        SceneManager.LoadScene("menuInicial");
        
        PlayerPrefs.SetInt("carpeta", 0);
        PlayerPrefs.SetInt("moneda", 0);
        PlayerPrefs.SetInt("llave", 0);
        PlayerPrefs.SetFloat("vida", 100);
        //PlayerPrefs.SetFloat("vida", vidaMax);
        Time.timeScale = 1;

    }



   
   
   


}
