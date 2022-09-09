using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    [Header("Human Parameters")]
    [SerializeField] private List<GameObject> listHumanPrefab = null;
    [SerializeField] private List<Transform> listSpawnTrasform = new List<Transform>();
    private List<GameObject> humanList = new List<GameObject>();
    public List<Transform> waypointsCtoD;
    public List<Transform> waypointsAtoB;
    public int counter = 0;
    float timeoutDuration = 2;
    float timeout = 2;
    public List<Color> humanColorList = new List<Color>();
    public static HumanManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    void Update()
    {
        if (timeout > 0)
        {
            timeout -= Time.deltaTime;
            return;
        }
        if (humanList.Count < 4) 
        {
            GameObject human = null;
            int random = Random.Range(0, listHumanPrefab.Count);
            switch (humanList.Count)
            {
                case 0:
                    human = Instantiate(listHumanPrefab[random], listSpawnTrasform[0].position, listSpawnTrasform[0].rotation);
                    human.GetComponentInChildren<EnemyAi>().ChoicePoint(0);
                    break;

                case 1:
                    human = Instantiate(listHumanPrefab[random], listSpawnTrasform[1].position, listSpawnTrasform[1].rotation);
                    human.GetComponentInChildren<EnemyAi>().ChoicePoint(1);
                    timeout = timeoutDuration;
                    break;

                case 2:
                    human = Instantiate(listHumanPrefab[random], listSpawnTrasform[0].position, listSpawnTrasform[0].rotation);
                    human.GetComponentInChildren<EnemyAi>().ChoicePoint(0);
                    timeout = timeoutDuration;
                    break;

                case 3:
                    human = Instantiate(listHumanPrefab[random], listSpawnTrasform[1].position, listSpawnTrasform[1].rotation);
                    human.GetComponentInChildren<EnemyAi>().ChoicePoint(1);
                    break;
            }
            humanList.Add(human);
        }
  }
    public void Destroyhuman(GameObject human, float timeAfterKillAnim)
    {
        humanList.Remove(human);
        Destroy(human, timeAfterKillAnim);
    }

    public Color RandomColor(int index)
    {
        Color color = humanColorList[index];
        return color;
    }
}
