using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    public UI_Inventory UIinventory;

    private string Name;
    //inventory
    //wallet

    private Rigidbody2D body;

    private Vector2 movement;

    public float speed;

    private void Awake()
    {
        inventory = new Inventory();
        UIinventory.SetInventory(inventory);
    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(movement * speed * Time.deltaTime);
    }


}
