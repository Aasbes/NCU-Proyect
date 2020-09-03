using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
//control del personaje
public class ControlJugador : MonoBehaviour
{
    public int numeroJugador;
    //vida Jugador
    public Image salud;
    public float vida, vidaMax = 100f;
    //sonidos
    private AudioSource audioPlayer;
    public AudioClip muerte;
    public AudioClip SonidoDisparo;
    public AudioClip grito;
    public AudioClip jump;
    public AudioClip recoleccion;
    //controles
    public String saltar, izquierda, derecha, disparar;
    //movimiento personaje
    public Transform pos;
    public float speed = 0.5f;
    public Rigidbody2D rbd;
    public float salto = 2f;
    public bool puedeSaltar = false;
   
   
    //sprites animacion
    public SpriteRenderer sprit;
   // public SpriteRenderer sprit2;
    public Animator anim;

    //disparo
    public Transform DisparoDerecha;
    public Transform DisparoIzquierda;
    public GameObject balaPrefab;
    float tiempo = 10f;
   
    /*
    public String teclaModoDisparo;
    bool puedeDisparar=false;
    */
    //vida y daño
    public GameObject barraVidaPersonaje;
    /*
    public static ControlJugador instance;  
    
    void Awake()
    {
        
        
        if (instance == null  )
        {
            
            instance = this;
            //DontDestroyOnLoad(gameObject);
            

        }
        else if (instance != this)
        {
            Destroy(gameObject);
           
        }
        
        
    }
    */
    void Start()
    {
        
        anim.SetBool("saltar", true);

        audioPlayer = GetComponent<AudioSource>();

        //
        if (numeroJugador == 1)
        {
            vida = PlayerPrefs.GetFloat("vida");
            //vida = vidaMax;
            salud.transform.localScale = new Vector2(PlayerPrefs.GetFloat("vida") / vidaMax, 1);

        }
        else
        {
            vida = PlayerPrefs.GetFloat("vida2");
            //vida = vidaMax;
            salud.transform.localScale = new Vector2(PlayerPrefs.GetFloat("vida2") / vidaMax, 1);

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        




        if (numeroJugador == 1)
        {
            vida = PlayerPrefs.GetFloat("vida");
            salud.transform.localScale = new Vector2(vida / vidaMax, 1);
            //avance a la derecha
        }
        else
        {
            vida = PlayerPrefs.GetFloat("vida2");
            salud.transform.localScale = new Vector2(vida / vidaMax, 1);
            //avance a la derecha

        }

        if (Input.GetKey(derecha))
        {

            pos.position += new Vector3(1f, 0, 0) * speed * Time.deltaTime;
            sprit.flipX = false;
            anim.SetBool("velocidad", true);
            //sprit2.flipX = false;



        }
        else
        {   //avance a la izquierda
            if (Input.GetKey(izquierda))
            {

                pos.position += new Vector3(-1f, 0, 0) * speed * Time.deltaTime;
                sprit.flipX = true;
                anim.SetBool("velocidad", true);
                //sprit2.flipX= true;


            }

            else
            {
                anim.SetBool("velocidad", false);

            }
        }
        //salto
        
        

        
        
        if (Input.GetKeyDown(saltar) && puedeSaltar == true)
        {
            audioPlayer.clip = jump;
            audioPlayer.Play();
            rbd.AddForce(Vector2.up * salto, ForceMode2D.Impulse);

            puedeSaltar = false;
            anim.SetBool("saltar", true);


        }
        
        //verifica la direccion para disparar y dispara

        /*
        if (Input.GetKey(teclaModoDisparo))
        {
            puedeDisparar = !puedeDisparar;
            anim.SetBool("accionDisparo", puedeDisparar);

        }*/
        //tiempo en que se mostrara los sprites de disparo
        tiempo += Time.deltaTime;
        if (tiempo >= 1.5)
        {
            anim.SetBool("accionDisparo", false);
            tiempo = 0;
            

        }
        ladoDisparo(sprit);
    }
    
    //verifica lo que toca el jugador
    public void OnCollisionEnter2D(Collision2D tocando)
    {
        /*
        if(tocando.gameObject.tag=="jugador" || tocando.gameObject.tag == "jugador2")
        {
            rbd.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
        CollisionEnter2D
        */
        
        

        if (tocando.gameObject.tag == "suelo")
        {
            puedeSaltar = true;
            anim.SetBool("saltar", false);
            
           
        }
        
        
        if (tocando.gameObject.tag == "enemigo" )
        {

            Color color = new Color(255 / 255f, 106 / 255f, 0 / 255f);
            sprit.color = color;
            rbd.AddForce(Vector2.up * 2, ForceMode2D.Impulse);


            //barraVidaPersonaje.SendMessage("dañoRecibido", 15);
            dañoRecibido(10);
            ////////////////
            if (vida <= 0)
            {

                audioPlayer.clip = muerte;
                audioPlayer.Play();

                if (numeroJugador == 1)
                {
                    PlayerPrefs.SetFloat("vida", vida);
                    //salud.transform.localScale = new Vector2(vida / vidaMax, 1);
                    //avance a la derecha
                }
                else
                {
                    PlayerPrefs.SetFloat("vida2", vida);
                    //salud.transform.localScale = new Vector2(vida / vidaMax, 1);
                    //avance a la derecha

                }

            }
            else
            {
                audioPlayer.clip = grito;
                audioPlayer.Play();
            }
            

        }
        if (tocando.gameObject.tag == "eliminacion")
        {
            pos.position = new Vector3(0, 0, 0);
            //barraVidaPersonaje.SendMessage("dañoRecibido", 25);
            dañoRecibido(20);
            //barraVidaPersonaje.SendMessage("dañoRecibido", 15);
            if (vida <= 0)
            {

                audioPlayer.clip = muerte;
                audioPlayer.Play();
               
                if (numeroJugador == 1)
                {
                    PlayerPrefs.SetFloat("vida", vida);
                    //salud.transform.localScale = new Vector2(vida / vidaMax, 1);
                    //avance a la derecha
                }
                else
                {
                    PlayerPrefs.SetFloat("vida2", vida);
                    //salud.transform.localScale = new Vector2(vida / vidaMax, 1);
                    //avance a la derecha

                }
            }
        }

        if (tocando.gameObject.tag == "recolectable")
        {
            Destroy(tocando.gameObject);
            audioPlayer.clip = recoleccion;
            audioPlayer.Play();
        }
        if (tocando.gameObject.tag == "reinicioPosicion")
        {
            pos.position = new Vector3(0, 0, 0);
        }



    }
    

    
    
    public void OnCollisionExit2D(Collision2D tocando)
     {
        /*
        if (tocando.gameObject.tag == "suelo" )
        {
            
            
            puedeSaltar = false;
            anim.SetBool("saltar", true);
           
        }
        */

        if (tocando.gameObject.tag == "enemigo")
        {
            sprit.color = Color.white;
        }

    }



    //disparo
    public void PlayerShooting(Transform origen)
    {
        //if (Input.GetButtonDown("Fire1"))
        if    (Input.GetKeyDown(disparar) )
        {
           
            anim.SetBool("accionDisparo", true);
           
            audioPlayer.clip = SonidoDisparo;
            audioPlayer.Play();
            Instantiate(balaPrefab, origen.position,origen.rotation);

        }
        

    }
    //verifica la direccion para disparar
    public void ladoDisparo(SpriteRenderer sprit)
    {
        
        if (sprit.flipX == false)
        {
            PlayerShooting(DisparoDerecha);
        }
        else
        {
            PlayerShooting(DisparoIzquierda);
        }
    }

    public void dañoRecibido(float daño)
    {
        vida = Mathf.Clamp(vida - daño, 0f, vidaMax);
        /*
        if (vida > 100)
        {
            PlayerPrefs.SetFloat("vida2", vidaMax);
        }
        else
        {

            PlayerPrefs.SetFloat("vida2", vida);
        }
        //salud.transform.localScale = new Vector2(vida / vidaMax, 1);
        */
        if (numeroJugador == 1)
        {
            PlayerPrefs.SetFloat("vida",vida);
            //salud.transform.localScale = new Vector2(vida / vidaMax, 1);
            //avance a la derecha
        }
        else
        {
            PlayerPrefs.SetFloat("vida2",vida);
            //salud.transform.localScale = new Vector2(vida / vidaMax, 1);
            //avance a la derecha

        }
    }

   

}





