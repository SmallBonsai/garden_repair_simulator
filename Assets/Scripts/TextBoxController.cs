using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour
{
    public GameObject textbox;
    public GameObject text;
    public bool isActive;
    public Vector2 position = new Vector2(0, -338);

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
        textbox.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(textbox.GetComponent<RectTransform>().anchoredPosition, position, 0.25f);
    }

    public void EnableBox(){
        position.y = -338;
    }

    public void DisableBox(){
        position.y = -650;
    }

    public void setText(string str){
        text.GetComponent<Text>().text = str;
    }
}
