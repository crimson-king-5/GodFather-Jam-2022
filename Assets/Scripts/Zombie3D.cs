using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie3D : MonoBehaviour
{
    private Animator Anime;

    private void Start()
    {
        Anime = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            //attack
            Anime.SetTrigger("touche");
            collision.gameObject.GetComponent<EnemyAi>().enabled = false;
            collision.gameObject.GetComponent<Animator>().SetTrigger("Death");


        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            //lose pv
            Anime.SetTrigger("fail");
        }
    }
}