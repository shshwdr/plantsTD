using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    HPObject hpObject;
    BattleItemInfo info;

    HPObject target;

    float attackTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        hpObject = GetComponent<HPObject>();
    }

    // Update is called once per frame
    void Update()
    {
        info = hpObject.info;
        if (!hpObject.canAttack())
        {
            return;
        }


        attackTimer += Time.deltaTime;


        if (attackTimer >= info.attackSpeed)
        {
            attackTimer = 0;

            if(!target || target.isDead)
            {
                if(info.GetType() == typeof(PlantInfo))
                {
                    var  temp = EnemyManager.Instance.findClosestEnemy();
                    if(temp && (temp.transform.position - transform.position).magnitude<= info.attackRange){
                        target = temp.GetComponent<HPObject>();
                    }

                }
                else
                {
                   // target = PlantManager.Instance.findClosestPlant();
                }
            }


            if (target && !target.isDead)
            {
                target.getDamage(info.attack);

                //attack
                transform.DOShakeRotation(0.3f);
                Debug.Log("attack!");
            }

        }
}
}
