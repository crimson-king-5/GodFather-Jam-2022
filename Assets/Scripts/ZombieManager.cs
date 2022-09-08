using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [Header("Zombie Parameters")]
    [SerializeField] private GameObject zombie2DPrefab = null;
    [SerializeField] private GameObject zombie3DPrefab = null;
    [SerializeField] private List<Transform> listSpawnTransform = new List<Transform>();
    private List<GameObject> zombieList = new List<GameObject>();

    public static ZombieManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Update()
    {
        if (zombieList.Count < 3)
        {
            GameObject zombie = null;
            switch (zombieList.Count)
            {
                case 0:
                    zombie = Instantiate(zombie2DPrefab, listSpawnTransform[0].position, listSpawnTransform[0].rotation);
                    break;
                case 1:
                    zombie = Instantiate(zombie2DPrefab, listSpawnTransform[1].position, listSpawnTransform[1].rotation);
                    break ;
                case 2:
                    zombie = Instantiate(zombie2DPrefab, listSpawnTransform[2].position, listSpawnTransform[2].rotation);
                    break;
            }
            zombieList.Add(zombie);
        }
    }

    public void DestroyZombie(GameObject zombie, float timeAfterKillAnim)
    {
        zombieList.Remove(zombie);
        Destroy(zombie, timeAfterKillAnim);
    }

    public void SpawnZombie3D(Transform transformZombie)
    {
        Instantiate(zombie3DPrefab, transformZombie.position, transformZombie.rotation);
    }

}
