using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject car;
    private bool isMenuActive;
    void Start()
    {
        isMenuActive=false;
        menu.SetActive(false);
    }

    public void SetMenuActive(){
                car.GetComponent<Driver>().enabled=false;
                menu.SetActive(true);
                isMenuActive=true; 
    }
    public void SetMenuDisabled(){
                car.GetComponent<Driver>().enabled=true;
                menu.SetActive(false);
                isMenuActive=false; 
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isMenuActive){
                SetMenuDisabled();
            }else{
                SetMenuActive();
            }
        }
        
    }
}
