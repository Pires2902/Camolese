using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatAVErt  : MonoBehaviour
{
    public Transform posE, posF;
    public int speed;
    Vector2 posPlat;
    // Start is called before the first frame update
    void Start()
    {
        posPlat = posE.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posE.position) < 0.1f)
        {
            posPlat = posF.position;
        }
        if (Vector2.Distance(transform.position, posF.position) < 0.1f)
        {
            posPlat = posE.position;
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
