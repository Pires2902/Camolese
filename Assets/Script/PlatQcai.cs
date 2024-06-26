﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlatformEffector2D))]
public class PlatQcai : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    Rigidbody2D rig;
    public float delay = 2f;

    void Start()
    {
        anim.SetBool("rodar", true);
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

    }
    IEnumerator cair()
    {
        anim.SetBool("rodar", false);
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