using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class barraVida : MonoBehaviour
{
    public Image salud;
    public float vida, vidaMax = 100f;
    

    // Start is called before the first frame update
    void Start()
    {
        //vida = PlayerPrefs.GetFloat("vida");
        vida = vidaMax;
        //salud.transform.localScale = new Vector2(PlayerPrefs.GetFloat("vida") / vidaMax, 1);

    }
    void Update()
    {
        
        if (vida <= 0)
        {
            PlayerPrefs.SetFloat("vida", vidaMax);
            SceneManager.LoadScene("gameover");
            
        }
        PlayerPrefs.SetFloat("vida", vida);

        salud.transform.localScale = new Vector2(vida / vidaMax, 1);

    }
    public void dañoRecibido(float daño)
    {
        vida = Mathf.Clamp(vida - daño,0f, vidaMax);
        
        
        //salud.transform.localScale = new Vector2(vida / vidaMax, 1);
       
    }
  


    
}
