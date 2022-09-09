using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;
using DG.Tweening;

public class HumanMoveBehavior : MonoBehaviour
{
    Human human;
    Harvestable target;

    float harvestTimer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        human = GetComponent<Human>();

        EventPool.OptIn("plantUpdate", updateTarget);
    }

    // Update is called once per frame
    void Update()
    {
        if (!human.canAttack())
        {
            return;
        }

        //find tree, target tree, move to tree. if tree is in range, get wood
        if (target == null)
        {
            updateTarget();
        }
        var dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.Translate(dir * human.humanInfo.moveSpeed*Time.deltaTime);


        if((target.transform.position - transform.position).magnitude <= human.humanInfo.attackRange)
        {
            harvestTimer += Time.deltaTime;
            if (harvestTimer >= human.humanInfo.attackSpeed)
            {

                transform.DOShakeRotation(0.3f);
                target.harvest(human);
                harvestTimer = 0;
            }
            //give some time
            //human.kill();
        }
    }

    void updateTarget()
    {

        switch (human.humanInfo.intent)
        {
            case "wood":

                target = PlantManager.Instance.mainTree;
                break;
            case "plants":

                target = PlantManager.Instance.getClosestPlant(transform);
                break;

        }
    }
}
