using Pool;
using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorManager : Singleton<EnemyGeneratorManager>
{
    public GameObject enemyPrefab;

    public float generateDistance = 5;
    public int currentRound = 0;
    public int currentWave = 0;

    List<List<Dictionary<string, int>>> enemyGeneratorInfos;



    // Start is called before the first frame update
    void Start()
    {
        enemyGeneratorInfos = CsvUtil.LoadDictionaryList("enemyGenerate", false);
        generate();
    }

    public void generate()
    {
        StartCoroutine(generateYield());
    }

    void addEnemy(string type)
    {
        var go = Instantiate(Resources.Load<GameObject>("human/"+type), transform.position + new Vector3(HouseManager.Instance.currentHouse.position.x+ -generateDistance /*+ Random.Range(-2f, 2f)*/, Random.Range(-0.1f, 0.1f), 0), Quaternion.identity);
        //generateDistance = -generateDistance;
        go.GetComponent<Human>().init(type);
        SFXManager.Instance.HumanSpawn();
        EnemyManager.Instance.addEnemy(go.GetComponent<Human>());
        if (generateDistance < 0)
        {
            go.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    IEnumerator generateYield()
    {

        yield return new WaitForSeconds(GameManager.Instance.startWaveInterval);
        while (true)
        {
            var currentInfo = enemyGeneratorInfos[currentRound][currentWave];

            SFXManager.Instance.WaveStart();
            foreach (var pair in currentInfo)
            {
                for (int i = 0; i < pair.Value; i++)
                {
                    yield return new WaitForSeconds(GameManager.Instance.enemyInterval);
                    addEnemy(pair.Key);
                }
            }
            yield return new WaitForSeconds(GameManager.Instance.waveInterval);
            currentWave++;
            if(currentWave>= enemyGeneratorInfos[currentRound].Count)
            {
                if(currentRound>= enemyGeneratorInfos.Count)
                {

                    currentWave = 0;
                }
                else
                {
                    currentRound++;
                    EventPool.Trigger("upgradeRound");
                }
            }
        }

       // currentWave++;
    }
    //    if (currentInfo.magic > 0)
    //    {
    //        GameLoopManager.Instance.addDialogue(false, "magic");
    //    }
    //    if (currentInfo.soldier > 0)
    //    {
    //        GameLoopManager.Instance.addDialogue(false, "soldier");
    //    }
    //    if (currentInfo.lady > 0)
    //    {
    //        GameLoopManager.Instance.addDialogue(false, "lady");
    //    }
    //    if (currentInfo.soldier2 > 0)
    //    {
    //        GameLoopManager.Instance.addDialogue(false, "soldier2");
    //    }
    //    if (currentInfo.dark > 0)
    //    {
    //        GameLoopManager.Instance.addDialogue(false, "dark");
    //    }
    //    yield return new WaitForSeconds(0.1f);
    //    for (int i = 0; i < currentInfo.villager; i++)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        addEnemy("villager");
    //    }
    //    for (int i = 0; i < currentInfo.magic; i++)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        addEnemy("magic");
    //    }
    //    for (int i = 0; i < currentInfo.soldier; i++)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        addEnemy("soldier");
    //    }


    //    for (int i = 0; i < currentInfo.lady; i++)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        addEnemy("lady");
    //        GameLoopManager.Instance.addDialogue(false, "lady");
    //    }


    //    for (int i = 0; i < currentInfo.soldier2; i++)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        addEnemy("soldier2");
    //        GameLoopManager.Instance.addDialogue(false, "soldier2");
    //    }

    //    for (int i = 0; i < currentInfo.dark; i++)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        addEnemy("dark");
    //        GameLoopManager.Instance.addDialogue(false, "dark");
    //    }

    //    for (int i = 0; i < currentInfo.witch; i++)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        addEnemy("witch");
    //        GameLoopManager.Instance.addDialogue(false, "witch");
    //    }
    //    for (int i = 0; i < currentInfo.nohair; i++)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        addEnemy("nohair");
    //        GameLoopManager.Instance.addDialogue(false, "nohair");
    //    }

    //    for (int i = 0; i < currentInfo.cow; i++)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        addEnemy("cow");
    //        GameLoopManager.Instance.addDialogue(false, "cow");
    //    }
    //    for (int i = 0; i < currentInfo.soldier3; i++)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        addEnemy("soldier3");
    //        GameLoopManager.Instance.addDialogue(false, "soldier3");
    //    }

    //}

    public void upgradeLevel()
    {
        currentRound++;
        EventPool.Trigger("changeLevel");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
