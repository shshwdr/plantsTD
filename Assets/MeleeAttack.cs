using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : TimeAttack
{
    HPObject target;
    public override void attack()
    {
        if (!target || target.isDead)
        {
            if (info.GetType() == typeof(PlantInfo))
            {
                var temp = EnemyManager.Instance.findClosestEnemy();
                if (temp && (temp.transform.position - transform.position).magnitude <= info.attackRange)
                {
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
            //Debug.Log("attack!");
        }
    }
}
