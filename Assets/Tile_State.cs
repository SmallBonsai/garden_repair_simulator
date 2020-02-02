using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_State : MonoBehaviour
{

    private int state = 0;
    public Sprite seeded;
    public Sprite grown;
    public SpriteRenderer spr;


    public void seed() {
        if (state == 0)
        {
            this.state = 1;
            spr.sprite = seeded;
        }
    }

    public void grow() {
        if (state == 1)
        {
            this.state = 2;
            spr.sprite = grown;
        }
    }
}
