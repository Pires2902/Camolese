using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatB : MonoBehaviour
{
    public Transform posC, posD;
    public int speed;
    Vector2 posPlat;
    // Start is called before the first frame update
    void Start()
    {
        posPlat = posC.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posC.position) < 0.1f)
        {
            posPlat = posD.position;
        }
        if (Vector2.Distance(transform.position, posD.position) < 0.1f)
        {
            posPlat = posC.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, posPlat, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {

        if (colisao.gameObject.CompareTag("Player"))
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
    }
}
