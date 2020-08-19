using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo1 : MonoBehaviour
{
    public float velocidad;
    public float capa;
    private bool movinRight = true;
    private bool tocar=false;
    public Transform groundDetection;


    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, capa);

        if (tocar)
        {
            if (movinRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movinRight = false;
                tocar = false;
            }
            else
            {

                transform.eulerAngles = new Vector3(0, 0, 0);
                movinRight = true;
                tocar = false;
            }


        }
        else
        {
            if ( groundInfo.collider == false)
            {
                if (movinRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movinRight = false;
                }
                else
                {

                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movinRight = true;

                }
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D tocando)
    {
        if (tocando.gameObject.tag == "jugador" )
        {
            tocar = true;

        }

      



    }
}
