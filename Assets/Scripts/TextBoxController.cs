using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxController : MonoBehaviour
{
    public GameObject textbox;
    public bool isActive;

    public void Start()
    {
        if(isActive){
            EnableBox();
        } else {
            DisableBox();
        }

    }


    public void Update()
    {
        if(!isActive){
            return;
        }
    }

    public void EnableBox(){
        textbox.SetActive(true);
    }

    public void DisableBox(){
        textbox.SetActive(false);
    }
}
