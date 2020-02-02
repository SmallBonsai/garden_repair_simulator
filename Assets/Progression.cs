using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour
{

    public GameObject apple;
    public GameObject button;
    public GameObject sorbet;
    public GameObject drink;
    public GameObject jam;
    public GameObject cake;
    public GameObject bread;
    public GameObject stuffed;

    private Vector2 applePosition;
    private Vector2 btnPosition;
    private Vector2 sorbetPosition;
    private Vector2 drinkPosition;
    private Vector2 jamPosition;
    private Vector2 cakePosition;
    private Vector2 breadPosition;
    private Vector2 stuffedPosition;
    private int peppers;
    private int carrots;
    private int strawberries;
    private int blueberries;
    private int pumpkins;
    private int watermelons;
    // Start is called before the first frame update
    void Start()
    {
        this.applePosition = new Vector2(0.0f, 1080.0f);
        this.stuffedPosition = new Vector2(0.0f, 1080.0f);
        this.sorbetPosition = new Vector2(0.0f, 1080.0f);
        this.drinkPosition = new Vector2(0.0f, 1080.0f);
        this.jamPosition = new Vector2(0.0f, 1080.0f);
        this.cakePosition = new Vector2(0.0f, 1080.0f);
        this.breadPosition = new Vector2(0.0f, 1080.0f);
        this.btnPosition = new Vector2(600.0f, -800.0f);
    }

    // Update is called once per frame
    void Update()
    {
        apple.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(apple.GetComponent<RectTransform>().anchoredPosition, this.applePosition, 0.25f);
        button.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(button.GetComponent<RectTransform>().anchoredPosition, this.btnPosition, 0.25f);
        stuffed.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(stuffed.GetComponent<RectTransform>().anchoredPosition, this.stuffedPosition, 0.25f);
        sorbet.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(sorbet.GetComponent<RectTransform>().anchoredPosition, this.sorbetPosition, 0.25f);
        cake.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(cake.GetComponent<RectTransform>().anchoredPosition, this.cakePosition, 0.25f);
        bread.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(bread.GetComponent<RectTransform>().anchoredPosition, this.breadPosition, 0.25f);
        jam.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(jam.GetComponent<RectTransform>().anchoredPosition, this.jamPosition, 0.25f);
        drink.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(drink.GetComponent<RectTransform>().anchoredPosition, this.drinkPosition, 0.25f);
        if (Input.GetKeyDown("space"))
        {
            this.hide();
        }
    }

    public void hide() {
        this.applePosition.y = 1080;
        this.stuffedPosition.y = 1080;
        this.cakePosition.y = 1080;
        this.breadPosition.y = 1080;
        this.sorbetPosition.y = 1080;
        this.drinkPosition.y = 1080;
        this.jamPosition.y = 1080;
        this.btnPosition.y = -800;
    }

    public void apples() {
        Debug.Log("Stuff");
        this.applePosition.y = 0;
        this.btnPosition.y = -450;
    }

    public void peppersInc() {
        this.peppers += 1;
        if (this.peppers >= 6) {
            this.stuffedPosition.y = 0;
        }
    }

    public void carrotsInc()
    {
        this.carrots += 1;
        if (this.carrots >= 6) {
            this.cakePosition.y = 0;
        }
    }

    public void strawberriesInc()
    {
        this.strawberries += 1;
        if (this.strawberries >= 6) {
            this.drinkPosition.y = 0;
        }
    }

    public void blueberriesInc()
    {
        this.blueberries += 1;
        if (this.blueberries >= 6) {
            this.jamPosition.y = 0;
        }
    }

    public void watermelonsInc()
    {
        this.watermelons += 1;
        if (this.watermelons >= 6) {
            this.sorbetPosition.y = 0;
        }
    }

    public void pumpkinsInc()
    {
        this.pumpkins += 1;
        if (this.pumpkins >= 9) {
            this.breadPosition.y = 0;
        }
    }
}
