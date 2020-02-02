using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_State : MonoBehaviour
{
    private int state = 0;
    public Sprite seeded;
    public Sprite grown;
    public SpriteRenderer spr;
    public Animator anim;
    public AudioSource ads;
    public AudioClip water;
    public AudioClip growing;
    public AudioClip plant;

    private Sprite current;
    private float growTimer = 5.0f;
    private float sprTransitionTimer = 0.5f;


    public void Start()
    {
        spr.enabled = false;
    }

    public void changeTile(bool haveSeeds, bool haveCan)
    {
        if (this.state == 0 && haveSeeds) // && have seeds
        {
            this.state = 1;
            current = seeded;
            this.anim.SetBool("Change_Back", false);
            this.anim.SetBool("Change_State", true);
            sprTransitionTimer = 0.5f;
            ads.PlayOneShot(plant);
        }
        else if (this.state == 1 && haveCan)
        {
            this.state = 2;
            spr.enabled = true;
            this.growTimer = 5.0f;
            ads.PlayOneShot(water);
        }

    }

    public int GetState(){
        return this.state;
    }

    public void Update()
    {
        this.sprTransitionTimer -= Time.deltaTime;

        if (this.state == 2) {
            this.growTimer -= Time.deltaTime;
        }

        if (this.growTimer <= 0 && this.state == 2) {
            this.anim.SetBool("Change_Back", false);
            this.anim.SetBool("Change_State", true);
            current = grown;
            sprTransitionTimer = 0.5f;
            this.state = 3;
            ads.PlayOneShot(growing);
        }

        if (sprTransitionTimer <= 0) {
            spr.sprite = current;
            spr.enabled = true;

            this.anim.SetBool("Change_State", false);
            this.anim.SetBool("Change_Back", true);
        }

        if (sprTransitionTimer <= -0.5) {
            this.anim.SetBool("Change_Back", true);
        }



    }


}





