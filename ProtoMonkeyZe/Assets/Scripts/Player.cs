using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    public bool running = false;
    public float moveSpeed = 10f;
    public float jumpVelocity = 35f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && running == false)
        {
            running = true;
        }

        if (running == true)
        {
            rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycasthit2d =  Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, layerMask);
        return raycasthit2d.collider != null;
    }
}
