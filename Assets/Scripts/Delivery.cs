using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] GameObject gameStatus;
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.collider.tag);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Package"){
           gameStatus.GetComponent<GameStatus>().packagePickUp();
        }
        if(other.tag=="Customer"){
            gameStatus.GetComponent<GameStatus>().customerDelivery();
        }
    }
}
