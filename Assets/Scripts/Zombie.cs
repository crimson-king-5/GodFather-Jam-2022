using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public enum ZombieEnvy
    {
        Blue,
        Green,
        Red
    }

    private Transform zombiePos = null;
    private DragAndShoot _dragAndShoot = null;
    public ZombieEnvy _envy = ZombieEnvy.Blue;
    public SpriteRenderer envyRenderer;

    private void Start()
    {
        _dragAndShoot = GetComponent<DragAndShoot>();
        zombiePos = ZombieManager.instance.zombiePos;

        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                _envy = ZombieEnvy.Blue;
                envyRenderer.sprite = ZombieManager.instance.RandomSprite("blue");
                break;
            case 1:
                _envy = ZombieEnvy.Green;
                envyRenderer.sprite = ZombieManager.instance.RandomSprite("green");
                break;
            case 2:
                _envy = ZombieEnvy.Red;
                envyRenderer.sprite = ZombieManager.instance.RandomSprite("red");
                break;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_dragAndShoot._canShoot)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null && hit.collider.gameObject.transform.position == transform.position)
            {
                transform.position = zombiePos.position;
                StartCoroutine(SetCanShoot());
            }
        }
    }

    IEnumerator SetCanShoot()
    {
        yield return new WaitForSeconds(1f);
        _dragAndShoot._canShoot = true;
    }

}
