using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPositionManager : MonoBehaviour
{
    PlantPositionGroup[] plantPositionGroup;

    // Start is called before the first frame update
    void Start()
    {
        plantPositionGroup = GetComponentsInChildren<PlantPositionGroup>();
        for(int i = 1; i < plantPositionGroup.Length; i++)
        {
            plantPositionGroup[i].gameObject.SetActive(false);
        }
        EventPool.OptIn("upgradeRound", upgradeRound);
    }

    public void upgradeRound()
    {
        var removeGroup = plantPositionGroup[EnemyGeneratorManager.Instance.currentRound];
        removeGroup.gameObject.SetActive(true);
    }
}
