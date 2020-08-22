using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraVida : MonoBehaviour
{
    public Image salud;
    float vida, vidaMax = 100f;
    // Start is called before the first frame update
    void Start()
    {
        vida = vidaMax;
    }

    public void dañoRecibido(float daño)
    {
        vida = Mathf.Clamp(vida - daño,0f, vidaMax);
        salud.transform.localScale = new Vector2(vida / vidaMax, 1);
    }
}
