using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [Header("Zombie Parameters")]
    [SerializeField] private GameObject zombie2DPrefab = null;
    [SerializeField] private GameObject zombie3DPrefab = null;
    [SerializeField] private Transform parent2DPrefab = null;
    [SerializeField] private List<Transform> listSpawnTransform = new List<Transform>();
    public GameObject target = null;
    public Transform zombiePos = null;
    public List<Sprite> zombiesEnvySprites = null;
    public string zombie2DEnvy = null;

    private List<GameObject> zombieList = new List<GameObject>();
    private List<bool> isFull = new List<bool>();

    public static ZombieManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        isFull.Add(false);
        isFull.Add(false);
        isFull.Add(false);
    }

    private void Update()
    {
        if (zombieList.Count < 3)
        {
            GameObject zombie = null;

            if (!isFull[0])
            {
                zombie = Instantiate(zombie2DPrefab, listSpawnTransform[0].position, listSpawnTransform[0].rotation, parent2DPrefab);
                isFull[0] = true;
            }
            else if (!isFull[1])
            {
                zombie = Instantiate(zombie2DPrefab, listSpawnTransform[1].position, listSpawnTransform[1].rotation, parent2DPrefab);
                isFull[1] = true;
            }
            else if (!isFull[2])
            {
                zombie = Instantiate(zombie2DPrefab, listSpawnTransform[2].position, listSpawnTransform[2].rotation, parent2DPrefab);
                isFull[2] = true;
            }
            zombieList.Add(zombie);
        }
    }

    public void DestroyZombie(GameObject zombie, float timeAfterKillAnim)
    {
        isFull[zombieList.IndexOf(zombie)] = false;
        Debug.Log(zombieList.IndexOf(zombie));
        zombieList.Remove(zombie);
        Destroy(zombie, timeAfterKillAnim);
    }

    public Sprite RandomSprite(string color)
    {
        Sprite sprite = null;

        switch (color)
        {
            case "blue" :
                sprite = zombiesEnvySprites[Random.Range(0, 1)];
                break;
            case "green":
                sprite = zombiesEnvySprites[Random.Range(2, 3)];
                break;
            case "red":
                sprite = zombiesEnvySprites[Random.Range(4, 5)];
                break;
        }

        return sprite;
    }

    public void SpawnZombie3D(Vector3 zombiePos)
    {
        StartCoroutine(SpawnZombie(zombiePos));
    }

    IEnumerator SpawnZombie(Vector3 zombiePos)
    {
        Instantiate(zombie3DPrefab, zombiePos, Quaternion.identity);
        yield return new WaitForSeconds(1f);
    }

}
