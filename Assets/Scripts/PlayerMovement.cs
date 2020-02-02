using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public GameObject TextBoxController;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject curColliding;
    public bool haveSeeds = false;
    public bool haveCan = false;

    private bool canAction = false;

    Vector2 movement;
    Vector2 pastMovement;
    Vector2 position;

    float timer = 0.5f;

    private void Start()
    {
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pastMovement.x = movement.x;
        pastMovement.y = movement.y;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        timer -= Time.deltaTime;

        if ((pastMovement.x <= 0 || timer < 0.0f) && movement.x > 0)
        {
            position.x += 1;
            timer = 0.5f;
        }
        else if ((pastMovement.x >= 0 || timer < 0.0f) && movement.x < 0)
        {
            position.x -= 1;
            timer = 0.5f;
        }
        else if ((pastMovement.y <= 0 || timer < 0.0f) && movement.y > 0)
        {
            position.y += 1;
            timer = 0.5f;
        }
        else if ((pastMovement.y >= 0 || timer < 0.0f) && movement.y < 0)
        {
            position.y -= 1;
            timer = 0.5f;
        }

        this.transform.position = Vector2.Lerp(this.transform.position, position, 0.5f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown("space") && canAction)
        {
            if (curColliding.gameObject.tag == "Shed" && !haveSeeds)
            {
                haveSeeds = true;
                haveCan = false;
                TextBoxController.GetComponent<TextBoxController>().DisableBox();
                Debug.Log("You got Seeds");
            }
            else if (curColliding.gameObject.tag == "Shed" && !haveCan)
            {
                haveCan = true;
                haveSeeds = false;
                Debug.Log("You got a Can");
            }
            else if (haveCan || haveSeeds)
            {
                curColliding.gameObject.GetComponent<Tile_State>().changeTile(haveSeeds, haveCan);
                Debug.Log("button pressed");
            }

            if (curColliding.gameObject.tag == "Tile")
            {
                int curState = curColliding.GetComponent<Tile_State>().GetState();
                if (curState == 0 && !haveSeeds)
                {
                    TextBoxController.GetComponent<TextBoxController>().EnableBox();
                }
                if (curState == 1 && !haveCan)
                {
                    TextBoxController.GetComponent<TextBoxController>().EnableBox();
                }

            }
        }
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
        canAction = false;
        Debug.Log("box");

    }
}
