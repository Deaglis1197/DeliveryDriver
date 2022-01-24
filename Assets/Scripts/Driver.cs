using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] float steerSpeed = 0.2f;
    void Start()
    {
        transform.Rotate(0,0,0);
        transform.Translate(0,0,0);// for spawner settings 
    
    }
    void Update()
    {   
        float steerAmount=Input.GetAxis("Horizontal")*steerSpeed*Time.deltaTime;
        float speedAmount=Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        if(speedAmount!=0){
           
            transform.Rotate(0,0,speedAmount<=0?steerAmount:-steerAmount);
        }
        transform.Translate(0,speedAmount,0);
        
    }
   
}
