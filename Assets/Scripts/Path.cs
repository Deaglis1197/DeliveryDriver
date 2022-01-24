using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<GameObject> paths;
    void Start()
    {
        paths=new List<GameObject>();
        foreach(Transform child in transform){
                paths.Add(child.gameObject);
          
            
        }
    }
    public List<GameObject> GetPaths(){
        return paths;
    }

}
