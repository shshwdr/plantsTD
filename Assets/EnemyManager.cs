using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyInfo: BattleItemInfo
{
    public float moveSpeed;
    public string dropItem;
    public int dropAmount;

}
public class EnemyManager : Singleton<EnemyManager>
{
    List<EnemyInfo> enemyInfos = new List<EnemyInfo>();
    Dictionary<string, EnemyInfo> enemyInfoDict = new Dictionary<string, EnemyInfo>();
    public List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemyInfos = CsvUtil.LoadObjects<EnemyInfo>("enemy");
        foreach(var enemy in enemyInfos)
        {
            enemyInfoDict[enemy.type] = enemy;
        }
    }

    public void addEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }
    public GameObject findClosestEnemy()
    {
        if (enemies.Count == 0)
        {
            return null;
        }
        return enemies[0];
    }

    public void removeEnemy(GameObject go)
    {
        enemies.Remove(go);
        if (enemies.Count == 0)
        {
            GameLoopManager.Instance.battleEnd(true);
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

    public EnemyInfo getEnemyInfo(string type)
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
