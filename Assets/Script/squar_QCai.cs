using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squar_QCai : MonoBehaviour
{
    Rigidbody2D rig;
    public float delay = 2f;

    void Start()
    {
        
        rig = GetComponent<Rigidbody2D>();

    }
    IEnumerator cair()
    {
        
        yield return new WaitForSeconds(0.5f);
        rig.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, delay);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           
            StartCoroutine("cair");
        }
    }
}

