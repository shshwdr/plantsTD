using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPObject : MonoBehaviour
{
    public float maxhp;

    public float currentHP;
    public bool isDead = false;
    public BattleItemInfo info;
    HPBar hpbar;

    public virtual void Start()
    {
        currentHP = maxhp;
        hpbar = GetComponentInChildren<HPBar>();
        if (hpbar)
        {
            hpbar.updateMaxAndCurrent(info.hp);
        }
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(0.1f);
        hpbar = GetComponentInChildren<HPBar>();
        if (hpbar)
        {
            hpbar.updateMaxAndCurrent(info.hp);
        }
    }

    public virtual void getDamage(float d)
    {
        currentHP -= d;
        if (currentHP <= 0 && !isDead)
        {
            die();
        }
        if (currentHP > maxhp)
        {
            currentHP = maxhp;
        }


        if (hpbar)
        {
            hpbar.updateCurrent(currentHP);
        }
    }

    public virtual void die()
    {
        isDead = true;
    }


    public virtual bool canAttack()
    {
        return !isDead;
    }
}