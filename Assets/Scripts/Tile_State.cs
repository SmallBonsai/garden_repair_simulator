using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_State : MonoBehaviour
{
    public GameObject TextBoxController;
    private int state = 0;
    public Sprite seeded;
    public Sprite grown;
    public SpriteRenderer spr;
    public Animator anim;

    private float timer = 0.5f;
    private bool changeStateOut;
    private bool changeStateIn;


    public void Start()
    {
        spr.enabled = false;
    }

    public void changeTile(bool haveSeeds, bool haveCan)
    {
        if (this.state == 0 && haveSeeds) // && have seeds
        {
            this.state = 1;
            spr.enabled = true;
            this.changeStateOut = true;
            spr.sprite = seeded;
        }
        else if (this.state == 1 && haveCan)
        {
            this.state = 2;
            spr.enabled = true;
            spr.sprite = grown;
        }

    }

    public int GetState(){
        return this.state;
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if (this.changeStateOut) {
            this.anim.SetBool
        }
    }


}





