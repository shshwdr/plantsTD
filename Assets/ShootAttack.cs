using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : TimeAttack
{
    Transform startPosition;
    private void Start()
    {
        startPosition = transform.Find("shootPoint");
    }
    public override void attack()
    {

        var temp = EnemyManager.Instance.findClosestEnemy();
        if (temp != null)
        {
            transform.DOShakeScale(0.3f);
            var go = Instantiate(Resources.Load<GameObject>("bullet/" + info.type), startPosition.position, Quaternion.identity);
            go.GetComponent<Bullet>().init(temp.transform.position, info.attack);
            SFXManager.Instance.Shoot();
        }
    }
}
