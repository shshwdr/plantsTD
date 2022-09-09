using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;

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

    public int isLocked;

}
public class PlantManager : Singleton<PlantManager>
{
    public MainTree mainTree;
    public List<PlantInfo> plantInfos = new List<PlantInfo>();
    Dictionary<string, PlantInfo> enemyInfoDict = new Dictionary<string, PlantInfo>();
    public List<BattlePlant> plants;
    // Start is called before the first frame update
    void Start()
    {
        mainTree = GameObject.FindObjectOfType<MainTree>();
        plantInfos = CsvUtil.LoadObjects<PlantInfo>("plant");
        foreach (var enemy in plantInfos)
        {
            enemyInfoDict[enemy.type] = enemy;
        }
    }

    public Harvestable getClosestPlant(Transform transform)
    {
        Harvestable plant = Utils.findClosestItem(transform.position, plants);
        if(plant == null)
        {
            plant = mainTree;
        }
        return plant;
    }

    public void addPlant(BattlePlant p)
    {
        plants.Add(p);

        EventPool.Trigger("plantUpdate");
    }
    public void removePlant(BattlePlant p)
    {
        plants.Remove(p);
        EventPool.Trigger("plantUpdate");
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
