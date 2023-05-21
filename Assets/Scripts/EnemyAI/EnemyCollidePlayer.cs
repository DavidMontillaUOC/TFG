using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollidePlayer : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player took dmg");
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<CharacterStats>().TakeDamage(25);
        }
    
    }


}
