using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingPlant : MonoBehaviour
{
    BattlePlant plant;
    float timer = 0;
    public HPBar hpbar;
    // Start is called before the first frame update
    void Start()
    {
        plant = GetComponent<BattlePlant>();
        //var plantInfo = PlantManager.Instance.getPlantInfo(plant.plantName);
        //if (plant.plantInfo!=null)
        {

            hpbar.updateMaxAndCurrent(plant.plantInfo.growTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!plant.canAttack())
        {
            return;
        }
        timer += Time.deltaTime;
        hpbar.updateCurrent(timer);
        if (timer >= plant.plantInfo.growTime)
        {
            plant.die();

            if (plant.plantInfo.upgradeTile > 0)
            {
                plant.plantPosition.upgrade(plant.plantInfo.upgradeTile);
            }

            if (plant.plantInfo.generation > 0)
            {

                var test = new List<PairInfo<int>>() { };
                test.Add(new PairInfo<int>("orb", plant.plantInfo.generation));
                //CollectionManager.Instance.AddCoins(transform.position,test);
                ClickToCollect.createClickToCollectItem(test, transform.position);
            }
        }
    }
}
