using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie3D : MonoBehaviour
{
   
    private Animator anime;
    private GameObject _scream;
    private GameObject _splash;

    private void Start()
    {
        anime = GetComponent<Animator>();
        _scream=GameManager.instance.Scream;
        _splash=GameManager.instance.Splash;
    }

    public IEnumerator ZombieTouche()
    {
        _scream.SetActive(true);
        _splash.SetActive(true);
        yield return new WaitForSeconds(2);
        _scream.SetActive(false);
        _splash.SetActive(false);
    }

    public IEnumerator ZombieRate()
    {
        _splash.SetActive(true);
        yield return new WaitForSeconds(2);
        _splash.SetActive(false);
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
                GameManager.instance.MoreScore();
                Destroy(gameObject, 2f);
                StartCoroutine(ZombieTouche());
            }
            else
            {
                GameManager.instance.health--;
                anime.SetTrigger("fail");
                Destroy(gameObject, 1f);
                StartCoroutine(ZombieTouche());
            }

            //attack
            //collision.gameObject.GetComponent<EnemyAi>().enabled = false;
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            GameManager.instance.health--;
            anime.SetTrigger("fail");
            Destroy(gameObject, 1f);
            StartCoroutine(ZombieRate());
        }
        
    }
}