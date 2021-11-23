using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string Name;
    //inventory
    //wallet

    private Rigidbody2D body;

    private float moveX;
    private float moveY;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(moveX * speed, moveY * speed);
    }


}
