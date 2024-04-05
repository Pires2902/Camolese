using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolaH : MonoBehaviour
{
    [SerializeField]
    private float impulso;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Rigidbody2D>()
            .AddForce(Vector2.right * impulso, ForceMode2D.Impulse);
        }

    }

}