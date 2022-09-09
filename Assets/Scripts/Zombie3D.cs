using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie3D : MonoBehaviour
{
    private Animator anime;

    private void Start()
    {
        anime = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            Human human = collision.gameObject.GetComponent<Human>();
            if (human.humaneNature.ToString() == ZombieManager.instance.zombie2DEnvy)
            {
                HumanManager.instance.Destroyhuman(collision.gameObject, 2f);
                collision.gameObject.GetComponent<Animator>().SetTrigger("Death");
                anime.SetTrigger("touche");
                Destroy(gameObject, 2f);
            }
            else
            {
                GameManager.instance.health--;
                anime.SetTrigger("fail");
                Destroy(gameObject, 1f);
            }

            //attack
            //collision.gameObject.GetComponent<EnemyAi>().enabled = false;
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            GameManager.instance.health--;
            anime.SetTrigger("fail");
            Destroy(gameObject, 1f);
        }
        
    }
}