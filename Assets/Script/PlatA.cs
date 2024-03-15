using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatA : MonoBehaviour
{
    public Transform posA, posB;
    public int speed;
    Vector2 posPlat;
    // Start is called before the first frame update
    void Start()
    {
        posPlat = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.1f)
        {
            posPlat = posB.position;
        }
        if (Vector2.Distance(transform.position, posB.position) < 0.1f)
        {
            posPlat = posA.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, posPlat, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {

        if (colisao.gameObject.CompareTag("Player"))
        {
            colisao.transform.SetParent(this.transform);


        }
        if (colisao.gameObject.CompareTag("mola"))
        {
            colisao.transform.SetParent(this.transform);


        }
    }
    void OnCollisionExit2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Player"))
        {
            colisao.transform.SetParent(null);
        }
        if (colisao.gameObject.CompareTag("mola"))
        {
            colisao.transform.SetParent(null);
        }
    }




}
