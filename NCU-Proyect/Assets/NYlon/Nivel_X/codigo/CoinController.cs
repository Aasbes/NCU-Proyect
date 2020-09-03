using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D col) {
        
        if (col.gameObject.tag  == "Player"){
            ScoreManager.scoreManager.RaiseScore(1);
            Destroy(gameObject);
            
            
        }
        
    }
    

}
