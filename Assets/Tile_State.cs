using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_State : MonoBehaviour
{
    GameObject player;

    private int state = 0;
    public Sprite seeded;
    public Sprite grown;
    public SpriteRenderer spr;


    public void Start()
    {
        spr.enabled = false;
    }

    public void changeTile()
    {
        if (this.state == 0)
        {
            this.state = 1;
            spr.enabled = true;
            spr.sprite = seeded;
        }
        else if (this.state == 1)
        {
            this.state = 2;
            spr.enabled = true;
            spr.sprite = grown;
        }
        else if (this.state == 2)
        {
            this.state = 0;
            spr.enabled = false;
        }
    }

}


