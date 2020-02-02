using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_State : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    private int state = 0;
    public Sprite seeded;
    public Sprite grown;
    public SpriteRenderer spr;


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
            spr.sprite = seeded;
        }
        else if (this.state == 1 && haveCan)
        {
            this.state = 2;
            spr.enabled = true;
            spr.sprite = grown;
        }
        else if (state == 0 && !haveSeeds)
        {
            //Trigger need Seeds text
            if (FloatingTextPrefab)
            {
                ShowFloatingText();
            }
        }
        else if (state == 1 && !haveCan)
        {
            //Trigger need Can text
            if (FloatingTextPrefab)
            {
                ShowFloatingText();
            }
        }

    }

    public void ShowFloatingText()
    {
        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);

    }

}





