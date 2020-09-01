using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Menu : MonoBehaviour
{
    bool activo = false;
    bool coop;
    public bool canvasActivo = false;
    Canvas canvas;
    public GameObject configuracion;
    //public GameObject cooperativo;
    //public TextMeshProUGUI cantJugadores;

    // Start is called before the first frame update
    void Start()
    {
        
        //activo = false;
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
    public void Jugar1Jugador()
    {
        SceneManager.LoadScene("selecionarNivel");
        PlayerPrefs.SetInt("cooperativo", 1);
        print("1 Jugador");
    }
    public void Jugar2Jugadores()
    {
        PlayerPrefs.SetInt("cooperativo", 2);

        print("2Jugadores");
        SceneManager.LoadScene("selecionarNivel");
    }

    public void pausa()
    {
        Time.timeScale = 0;
        activo = false;
        configuracion.SetActive(activo);
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
        PlayerPrefs.SetFloat("vida2", 100);
        //PlayerPrefs.SetFloat("vida", vidaMax);
        Time.timeScale = 1;

    }

    public void SalirJuego()
    {

        Application.Quit();
        print("juego cerrado");
    }
   









}
