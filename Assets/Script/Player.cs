using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rig;
    [SerializeField] private int speed;
    public int jumpForce;
    bool PodePular = true;
    bool puloduplo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movi();
        Jump();

    }
    void Movi()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (PodePular)
            {
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                PodePular = false;
                puloduplo = true;
            }
            else if (!PodePular && puloduplo)
            {
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                PodePular = false;
                puloduplo = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            PodePular = true;
        }
        else
        {
            PodePular = false;
        }

        if (collision.gameObject.tag == "plataforma")
        {
            PodePular = true;
        }
        else
        {

        }


    }













}