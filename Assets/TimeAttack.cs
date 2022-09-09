using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttack:MonoBehaviour
{
    HPObject hpObject;
    protected BattleItemInfo info;


    float attackTimer = 0;
    // Start is called before the first frame update
    void Awake()
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

            attack();

        }
    }

    public virtual void attack()
    {

    }
}