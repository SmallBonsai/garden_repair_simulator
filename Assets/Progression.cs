using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour
{

    public GameObject apple;
    public GameObject button;

    private Vector2 applePosition;
    private Vector2 btnPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.applePosition = new Vector2(0.0f, 1080.0f);
        this.btnPosition = new Vector2(600.0f, -800.0f);
    }

    // Update is called once per frame
    void Update()
    {
        apple.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(apple.GetComponent<RectTransform>().anchoredPosition, this.applePosition, 0.25f);
        button.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(button.GetComponent<RectTransform>().anchoredPosition, this.btnPosition, 0.25f);
        if (Input.GetKeyDown("space"))
        {
            this.hide();
        }
    }

    public void hide() {
        this.applePosition.y = 1080;
        this.btnPosition.y = -800;
    }

    public void apples() {
        Debug.Log("Stuff");
        this.applePosition.y = 0;
        this.btnPosition.y = -450;
    }
}
