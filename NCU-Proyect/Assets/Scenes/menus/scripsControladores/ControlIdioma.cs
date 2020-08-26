using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlIdioma : MonoBehaviour
{
    public int idioma = 0;
    public string[] textoIngles;
    public string[] textoEspañol;
    public Text[] Text;

    // Update is called once per frame
    void Update()
    {


        idioma = PlayerPrefs.GetInt("idioma", 0);
        if (idioma == 1)
        {
            idiomaIngles();

        }else if (idioma == 0)
        {
            idiomaEspañol();
        }
    }


    public void cambiarIdioma()
    {
        if (idioma == 1)
        {
            idioma = 0;
            PlayerPrefs.SetInt("idioma", 0);

        }
        else
        {
            idioma = 1;
            PlayerPrefs.SetInt("idioma", 1);
        }
        PlayerPrefs.Save();


    }

    void idiomaIngles(){

        for(int i = 0; i < Text.Length; i++)
        {
            Text[i].text = textoIngles[i];

        }


    }

    void idiomaEspañol()
    {

        for (int i = 0; i < Text.Length; i++)
        {
            Text[i].text = textoEspañol[i];

        }


    }


}
