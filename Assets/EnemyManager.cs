using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HumanInfo: BattleItemInfo
{
    public float moveSpeed;
    public string dropItem;
    public int dropAmount;
    public string intent;

}
public class EnemyManager : Singleton<EnemyManager>
{
    List<HumanInfo> enemyInfos = new List<HumanInfo>();
    Dictionary<string, HumanInfo> enemyInfoDict = new Dictionary<string, HumanInfo>();
    public List<Human> enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemyInfos = CsvUtil.LoadObjects<HumanInfo>("enemy");
        foreach(var enemy in enemyInfos)
        {
            enemyInfoDict[enemy.type] = enemy;
        }
    }

    public List<Human> findAround(Vector3 position, float radius)
    {
        return Utils.findAround(position, radius, enemies);
    }

    public void addEnemy(Human enemy)
    {
        enemies.Add(enemy);
    }
    public Human findClosestEnemy()
    {
        if (enemies.Count == 0)
        {
            return null;
        }
        return enemies[0];
    }

    public void removeEnemy(Human go)
    {
        enemies.Remove(go);
        if (enemies.Count == 0)
        {
            //GameLoopManager.Instance.battleEnd(true);
            //upgradeLevel();
        }
    }

    public void clear()
    {
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    public HumanInfo getEnemyInfo(string type)
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
