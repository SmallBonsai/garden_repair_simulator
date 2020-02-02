using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject curColliding;
    public bool haveSeeds = false;
    public bool haveCan = false;

    private bool canAction = false;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown("space") && canAction)
        {
            if (curColliding.gameObject.tag == "Shed" && !haveSeeds)
            {
                haveSeeds = true;
                haveCan = false;
                Debug.Log("You got Seeds");
            }
            else if (curColliding.gameObject.tag == "Shed" && !haveCan)
            {
                haveCan = true;
                haveSeeds = false;
                Debug.Log("You got a Can");
            }
            else if (haveCan || haveSeeds){
                curColliding.gameObject.GetComponent<Tile_State>().changeTile(haveSeeds, haveCan);
                Debug.Log("button pressed");
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("you can press a button!");
        canAction = true;
        curColliding = other.gameObject;

        Debug.Log("collision occurred");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Left box");
        curColliding = other.gameObject;
        canAction = false;
    }
}
