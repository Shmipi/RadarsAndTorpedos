using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed = 8f;

    [SerializeField] private Rigidbody2D body;

    private Vector2 moveDirection;

    private float moveX;
    private float moveY;

    public bool inTask;
    public bool interacting;


    // Start is called before the first frame update
    void Start()
    {
        inTask = false;
        interacting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inTask == false)
        {
            Inputs();
        }

        if (Input.GetKeyDown("e"))
        {
            interacting = true;
        }

        if (Input.GetKeyUp("e"))
        {
            interacting = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Inputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        body.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
