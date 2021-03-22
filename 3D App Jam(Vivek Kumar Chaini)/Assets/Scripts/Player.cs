using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 800f;
    public float range = 15f;
    public float horizontal, vertical;

    public Color chainColor;
    public Color enemyColor;
    public GameObject enemy;
    public GameObject chain;


    Rigidbody rb;

    public static Player self;
    private void OnEnable()
    {
        self = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(horizontal, 0, vertical);
        rb.AddForce(move * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chain"))
        {
            chainColor = GetComponent<Renderer>().material.color;
            collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", chainColor);
            return;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyColor = enemy.GetComponent<Renderer>().material.color;
            collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
            GetComponent<Renderer>().material.SetColor("_Color", enemyColor);
            return;
        }
    }

    
}

