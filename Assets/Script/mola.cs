using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mola : MonoBehaviour
{
    [SerializeField]
    float impulso;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Rigidbody2D>()
            .AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
        }

    }

}