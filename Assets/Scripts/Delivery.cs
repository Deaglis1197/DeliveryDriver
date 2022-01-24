using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private PackageAndCustomerController gameStatus;
    void Start(){
        gameStatus=FindObjectOfType<PackageAndCustomerController>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.collider.tag);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Package"){
            gameStatus.PackagePickUp(other.GetComponent<Package>().packagePathId);
        }
        if(other.tag=="Customer"){
            gameStatus.DeliveredToCustomer();
        }
    }
}
