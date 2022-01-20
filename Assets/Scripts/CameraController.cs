using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform carTransform;
    void Start()
    {   
        
        transform.position=new Vector3(carTransform.position.x,carTransform.position.y,transform.position.z);
    }

   
    void LateUpdate()
    {
        
        transform.position=new Vector3(carTransform.position.x,carTransform.position.y,transform.position.z);
        
    }
}
