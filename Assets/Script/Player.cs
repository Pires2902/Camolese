using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    Animator anim;
    [SerializeField] Rigidbody2D rig;
    [SerializeField] private int speed;
    public int jumpForce;
    bool PodePular = true;
    bool puloduplo;
    public int jumpForceDouble;
    bool cair = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movi();
        Jump();
        if (cair == true)
        {
            anim.SetBool("fall", true);

        }
        else if (cair == false)
        {
            anim.SetBool("fall", false);
        }

    }
    void Movi()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);

        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("Walk", false);
        }



    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (PodePular)
            {
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
                PodePular = false;
                puloduplo = true;
                StartCoroutine(Cair());

               
               
            }
            else if (!PodePular && puloduplo)
            {
                anim.SetBool("doubleJump", true);
                rig.AddForce(Vector2.up * jumpForceDouble, ForceMode2D.Impulse);
                PodePular = false;
                puloduplo = false;
                StartCoroutine(Cair());

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            cair = false;
            PodePular = true;
            anim.SetBool("Jump", false);
            anim.SetBool("doubleJump", false);
            
        }
        else
        {
            PodePular = false;

        }
    }

    IEnumerator Cair()
    {
        yield return new WaitForSeconds(1.0f);
        cair = true;
        yield return null;
    }













}