using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using UnityEngine;
//control del personaje
public class ControlJugador : MonoBehaviour
{
    
    //movimiento personaje
    public Transform pos;
    public float speed = 0.5f;
    public Rigidbody2D rbd;
    public float salto = 2f;
    public bool puedeSaltar = false;

    //sprites animacion
    public SpriteRenderer sprit;
    //public SpriteRenderer sprit2;
    public Animator anim;

    //disparo
    public Transform DisparoDerecha;
    public Transform DisparoIzquierda;
    public GameObject balaPrefab;



    
    void Start()
    {
        anim.SetBool("saltar", true);
    }
    // Update is called once per frame
    void Update()
    {



        
        //avance a la derecha
        if (Input.GetKey(KeyCode.D))
        {
            
            pos.position += new Vector3(1f, 0, 0) * speed * Time.deltaTime;
            sprit.flipX = false;
            anim.SetBool("velocidad", true);
            //sprit2.flipY = false;

            

        }
        else
        {   //avance a la izquierda
            if (Input.GetKey(KeyCode.A))
            {
                
                pos.position += new Vector3(-1f, 0, 0) * speed * Time.deltaTime;
                sprit.flipX = true;
                anim.SetBool("velocidad", true);
                //sprit2.flipY= true;
                
                
            }

            else
            {
                anim.SetBool("velocidad", false);

            }
        }
        //salto
        if (Input.GetKeyDown(KeyCode.W) && puedeSaltar == true)
        {
            rbd.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            //puedeSaltar = false;
            //anim.SetBool("saltar", true);

            
        }
        //verifica la direccion para disparar
        ladoDisparo(sprit);



    }

    
    //verifica si toca el suelo
    public void OnCollisionEnter2D(Collision2D tocando)
    {
        if (tocando.gameObject.tag == "suelo")
        {
            puedeSaltar = true;
            anim.SetBool("saltar", false);
        }
       




    }
    

    
    
    public void OnCollisionExit2D(Collision2D tocando)
     {
        if (tocando.gameObject.tag == "suelo" )
        {
            puedeSaltar = false;
            anim.SetBool("saltar", true);
        }
    }



    //disparo
    public void PlayerShooting(Transform origen)
    {
        //if (Input.GetButtonDown("Fire1"))
        if    (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(balaPrefab, origen.position,origen.rotation);
            
        }



    }
    //verifica la direccion para disparar
    public void ladoDisparo(SpriteRenderer sprit)
    {
        if(sprit.flipX == false)
        {
            PlayerShooting(DisparoDerecha);
        }
        else
        {
            PlayerShooting(DisparoIzquierda);
        }
    }

}





