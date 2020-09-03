using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;
public class creditos : MonoBehaviour
{
   
    public Transform pos;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(pos.position.y <600){
            pos.position += new Vector3(0, 0.8f, 0);
        }
       
        
    }
    public void nuevaPartida()
    {
        PlayerPrefs.SetInt("carpeta", 0);
        PlayerPrefs.SetInt("moneda", 0);
        PlayerPrefs.SetInt("llave", 0);
        PlayerPrefs.SetFloat("vida", 100);
        PlayerPrefs.SetFloat("vida2", 100);

        PlayerPrefs.SetInt("TotalCarpeta",0);
      
        PlayerPrefs.SetInt("TotalMoneda",0);
    
        PlayerPrefs.SetInt("TotalLLave",0);


        SceneManager.LoadScene("menuInicial");
    }
    public void SalirJuego()
    {

        Application.Quit();
        PlayerPrefs.SetInt("carpeta", 0);
        PlayerPrefs.SetInt("moneda", 0);
        PlayerPrefs.SetInt("llave", 0);
        PlayerPrefs.SetFloat("vida", 100);
        PlayerPrefs.SetFloat("vida2", 100);
        print("juego cerrado");
    }
}
