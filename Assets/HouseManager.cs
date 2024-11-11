using DG.Tweening;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : Singleton<HouseManager>
{
    HouseGroup[] houseGroup;

    public Transform currentHouse;

    // Start is called before the first frame update
    void Start()
    {
        houseGroup = GetComponentsInChildren<HouseGroup>();
        EventPool.OptIn("upgradeRound", upgradeRound);
        currentHouse = houseGroup[EnemyGeneratorManager.Instance.currentRound].transform;
    }

    public void upgradeRound()
    {
        var removeGroup = houseGroup[EnemyGeneratorManager.Instance.currentRound-1];
        currentHouse = houseGroup[EnemyGeneratorManager.Instance.currentRound].transform;
        removeGroup.transform.DOMoveY(10, 1);
        Destroy(removeGroup.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
