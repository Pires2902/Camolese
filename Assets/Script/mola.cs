using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mola : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    [SerializeField]
    float impulso;
    
    void Start()
    {
        anim.SetBool("impul", false);
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
             anim.SetBool("impul", true);
             StartCoroutine("parar");
            col.gameObject.GetComponent<Rigidbody2D>()
            .AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
        }

    }
    IEnumerator parar()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("impul", false);
    }

}