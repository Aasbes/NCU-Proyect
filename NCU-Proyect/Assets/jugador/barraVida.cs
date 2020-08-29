using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class barraVida : MonoBehaviour
{
    public Image salud;
    public float vida, vidaMax = 100f;
    //public TextMeshProUGUI vidaPersonaje;

    // Start is called before the first frame update
    void Start()
    {
        vida = PlayerPrefs.GetFloat("vida");
        //vida = vidaMax;
        salud.transform.localScale = new Vector2(PlayerPrefs.GetFloat("vida") / vidaMax, 1);

    }
    void Update()
    {
        
        if (vida <= 0 && PlayerPrefs.GetInt("cooperativo") == 1)
        {
            PlayerPrefs.SetFloat("vida", vidaMax);
            SceneManager.LoadScene("gameover");

        }
        /*
        if(vida>100)
        {
            PlayerPrefs.SetFloat("vida", vidaMax);
        }
        else
        {
            vida=PlayerPrefs.GetFloat("vida");
            salud.transform.localScale = new Vector2(vida / vidaMax, 1);


        }
       */
        vida = PlayerPrefs.GetFloat("vida");
        salud.transform.localScale = new Vector2(vida / vidaMax, 1);

        //vidaPersonaje.text = PlayerPrefs.GetFloat("vida", 0).ToString();
    }
    public void dañoRecibido(float daño)
    {
        vida = Mathf.Clamp(vida - daño,0f, vidaMax);
        if (vida > 100)
        {
            PlayerPrefs.SetFloat("vida", vidaMax);
        }
        else
        {

            PlayerPrefs.SetFloat("vida", vida);
        }
        //salud.transform.localScale = new Vector2(vida / vidaMax, 1);
        
    }
  


    
}
