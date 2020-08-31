using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{

    public float moveSpeed;
    public GameObject[] wayPoints;
    float Vida;
    int nextWaypoint = 0;
    float distToPoint;
    public SpriteRenderer sprit;

    void Update()

    {
        Move();
        

    }
    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, wayPoints[nextWaypoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextWaypoint].transform.position, moveSpeed * Time.deltaTime);

        if (distToPoint < 0.2f)
        {
            TakeTurn();


        }

    }
    void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += wayPoints[nextWaypoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;
        ChooseNextWaypoint();



    }

    void ChooseNextWaypoint()
    {
        nextWaypoint++;

        //sprit.flipX = false;
        if (nextWaypoint % 2 == 0)
        {
            sprit.flipX = true;
        }
        else
        {
            sprit.flipX = false;
        }




        if (nextWaypoint == wayPoints.Length)
        {
            nextWaypoint = 0;


        }
    }
    /*
    public void OnCollisionEnter2D(Collision2D tocando)
    {
        
        if(tocando.gameObject.tag=="disparoJugador" )
        {
            Vida = Vida - 45;
        }
        
    }
    */
}
