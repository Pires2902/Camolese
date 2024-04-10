using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogo : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    private bool podematar;
    int cont = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        while (cont < 1)
        {
            StartCoroutine(fire());
        }
    }

    // Update is called once per frame
  
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (podematar == true)
        {
            if (other.gameObject.tag == "Player")
            {
                Destroy(other.gameObject);
            }
        }
    }

    IEnumerator fire()
    {
        yield return new WaitForSeconds(1.0f);
        podematar = true;
        anim.SetBool("fogo", true);
        yield return null;
        podematar = false;
        anim.SetBool("fogo", false);

    }
}