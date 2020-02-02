using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_State : MonoBehaviour
{
    public GameObject DeadTree;
    public GameObject DeadTrunk;
    public GameObject Tree;
    public GameObject Trunk;
    public GameObject AppleTree;
    public GameObject AppleTrunk;
    public AudioSource ads;
    public AudioClip water;

    private int state = 0;
    private float timer = 5.0f;

    private void Start()
    {
        Tree.GetComponent<Renderer>().enabled = false;
        Trunk.GetComponent<Renderer>().enabled = false;
        AppleTree.GetComponent<Renderer>().enabled = false;
        AppleTrunk.GetComponent<Renderer>().enabled = false;
    }

    public void changeTree(bool haveCan)
    {
        if (this.state == 0 && haveCan) // && have seeds
        {
            this.state = 1;
            ads.PlayOneShot(water);
            timer = 60.0f;
        }
        else if (this.state == 2 && haveCan)
        {
            this.state = 3;
            ads.PlayOneShot(water);
            timer = 60.0f;
        }
    }

    public int GetState()
    {
        return this.state;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (this.timer <= 0.0f){
            if (this.state == 1) {
                DeadTree.GetComponent<Renderer>().enabled = false;
                DeadTrunk.GetComponent<Renderer>().enabled = false;
                Tree.GetComponent<Renderer>().enabled = true;
                Trunk.GetComponent<Renderer>().enabled = true;
                this.state = 2;
            }
            else if (this.state == 3)
            {
                Tree.GetComponent<Renderer>().enabled = false;
                Trunk.GetComponent<Renderer>().enabled = false;
                AppleTree.GetComponent<Renderer>().enabled = true;
                AppleTrunk.GetComponent<Renderer>().enabled = true;
                this.state = 4;
                GameObject[] canvas = GameObject.FindGameObjectsWithTag("Canvas");
                if (canvas.Length == 1) {
                    canvas[0].GetComponent<Progression>().apples();
                }
            }
        }
    }
}
