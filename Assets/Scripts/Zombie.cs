using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public enum ZombieEnvy
    {
        OldHuman,
        Adult,
        Baby
    }

    public Transform zombiePos;
    private ZombieEnvy _envy;

    private void Start()
    {
        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                _envy = ZombieEnvy.OldHuman;
                break;
            case 1:
                _envy = ZombieEnvy.Adult;
                break;
            case 2:
                _envy = ZombieEnvy.Baby;
                break;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = zombiePos.position;
        }
    }

}
