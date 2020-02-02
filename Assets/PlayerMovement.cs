using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public List<GameObject> tiles;

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
            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].gameObject.GetComponent<Tile_State>().changeTile();
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
        tiles.Add(other.gameObject);

        Debug.Log("collision occurred");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Left box");
        tiles.Remove(other.gameObject);
        canAction = false;
    }
}
