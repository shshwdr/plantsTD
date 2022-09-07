using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleItemInfo {
    public string type;
    public float hp;
    public float attack;
    public float attackSpeed;
    public float attackRange;
}


public class PlantInfo: BattleItemInfo
{

    public int cost;
    public int generation;
    public int upgradeTile;
    public int minTileLevel;
    public float growTime;

}
public class PlantManager : Singleton<PlantManager>
{
    public List<PlantInfo> plantInfos = new List<PlantInfo>();
    Dictionary<string, PlantInfo> enemyInfoDict = new Dictionary<string, PlantInfo>();
    // Start is called before the first frame update
    void Start()
    {
        plantInfos = CsvUtil.LoadObjects<PlantInfo>("plant");
        foreach (var enemy in plantInfos)
        {
            enemyInfoDict[enemy.type] = enemy;
        }
    }

    public PlantInfo getPlantInfo(string type)
    {
        if (!enemyInfoDict.ContainsKey(type))
        {
            Debug.LogError("not type " + type);
        }
        return enemyInfoDict[type];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
