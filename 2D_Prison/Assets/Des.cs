using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
           // Destroy(collision.gameObject);
             Player.score +=1;
           // Player.Score();
        }
    }
}
