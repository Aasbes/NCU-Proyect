using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class permanente : MonoBehaviour
{

    public int count;
    public GameObject player;
    //bool activo = false;
    public static permanente instance;
    //public TextMeshProUGUI boton;
    bool jugador1=false , jugador2=false;

    int totalCarpetas, totalMonedas, totalLLaves;
    void Awake()
    {


        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);


        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = PlayerPrefs.GetInt("cooperativo");

        if (PlayerPrefs.GetInt("cooperativo")==1)
        {

            player = GameObject.FindGameObjectWithTag("jugador2");
            Destroy(player);
            
        }
        
        if (PlayerPrefs.GetFloat("vida2") <= 0)
        {
            PlayerPrefs.SetFloat("vida2", 100);
            //SceneManager.LoadScene("gameover");
            player = GameObject.FindGameObjectWithTag("jugador2");
            jugador2 = true;
            Destroy(player);
        }
        if (PlayerPrefs.GetFloat("vida") <= 0 && PlayerPrefs.GetInt("cooperativo") == 1)
        {
            PlayerPrefs.SetFloat("vida", 100);
            SceneManager.LoadScene("gameover");
            
        }
        else
        {
            if (PlayerPrefs.GetFloat("vida") <= 0)
                {
                PlayerPrefs.SetFloat("vida", 100);
                //SceneManager.LoadScene("gameover");
                player = GameObject.FindGameObjectWithTag("jugador");
                jugador1 = true;
                Destroy(player);
                }
            
        }
        if(jugador1 && jugador2)
        {
            SceneManager.LoadScene("gameover");
            jugador1 = false;
            jugador2 = false;
        }
        
        


        if (PlayerPrefs.GetFloat("vida2") <= 0)
        {
            PlayerPrefs.SetFloat("vida2", 100);
            //SceneManager.LoadScene("gameover");
            player = GameObject.FindGameObjectWithTag("jugador2");
            jugador2 = true;
            Destroy(player);
        }
        if (PlayerPrefs.GetFloat("vida") <= 0)
        {
            PlayerPrefs.SetFloat("vida", 100);
            //SceneManager.LoadScene("gameover");
            player = GameObject.FindGameObjectWithTag("jugador");
            jugador1 = true;
            Destroy(player);
        }
        if(jugador1 && jugador2)
        {
            SceneManager.LoadScene("gameover");

        }
        if (PlayerPrefs.GetInt("llave", 0)>=20)
        {
            SceneManager.LoadScene("pantallaJuegoCompletado");
           
        }
    }
        
       
       
        

    
    
}
