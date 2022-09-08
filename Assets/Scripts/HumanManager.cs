using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    [Header("Human Parameters")]
    [SerializeField] private GameObject humanPrefab = null;
    [SerializeField] private List<Transform> listSpawnTrasform = new List<Transform>();
    private List<GameObject> humanList = new List<GameObject>();

    public static HumanManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (humanList.Count < 4) { 
            GameObject human = null;
            switch (humanList.Count)
        {
            case 0:
                human = Instantiate(humanPrefab, listSpawnTrasform[0].position, listSpawnTrasform[0].rotation);

            case 1: 
                human = Instantiate(humanPrefab, listSpawnTrasform[1].position, listSpawnTrasform[1].rotation);
            }
            humanList.Add(human);
     }
  }
    public void Destroyhuman(GameObject human, float timeAfterKillAnim)
    {
        humanList.Remove(human);
        Destroy(human, timeAfterKillAnim);
    }
}
