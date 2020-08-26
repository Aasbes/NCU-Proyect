using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class controlador : MonoBehaviour
{
    /*
    bool activo = false;
    public GameObject configuracion;
    */
    void Start()
    {
        



        //configuracion.SetActive(activo);
    }
    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);

    }
    /*
    public void configuraciones()
    {

        activo = !activo;
        configuracion.SetActive(activo);

    }
    */
}
