using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : HPObject
{

    public SpriteRenderer spriteRender;

    public SpriteRenderer weaponRender;

    float damageTime = 0.3f;
    float damageTimer = 0f;
    public HumanInfo humanInfo;
    Animator animator;

    bool startAttack = false;

    float attackTimer = 0;

    public SpriteRenderer intentSprite;

    public string type;
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        //transform.DOMoveX(1, 20f);
        animator = GetComponent<Animator>();
    }

    public void init(string type)
    {
        this.type = type;
        //spriteRender.sprite = Resources.Load<Sprite>("human/" + type);
        // weaponRender.sprite = Resources.Load<Sprite>("human/" + type+"_w");
        humanInfo = EnemyManager.Instance.getEnemyInfo(type);
        info = humanInfo;
        maxhp = currentHP = info.hp;
        intentSprite.sprite = Resources.Load<Sprite>("intent/" + humanInfo.intent);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        damageTimer += Time.deltaTime;

        //if (Mathf.Abs( transform.position.x) <= info.attackRange)
        //{
        //    startAttack = true;
        //}
        //if (startAttack)
        //{
        //    //startAttack
        //    transform.DOKill();
        //    attackTimer += Time.deltaTime;
        //    if (attackTimer >= info.attackSpeed)
        //    {
        //        attackTimer = 0;
        //        //attack
        //        //transform.DOShakeRotation(0.3f);
        //        // Debug.Log("attack!");
        //        if (info.attackRange > 2)
        //        {

        //            var go = Instantiate(Resources.Load<GameObject>("human/" + type), transform.position, Quaternion.identity);
        //            go.GetComponent<HealBullet>().damage = (int)info.attack;
        //            go.GetComponent<HealBullet>().targetTrans = EnemyGeneratorManager.Instance.enemies[Random.Range(0, EnemyGeneratorManager.Instance.enemies.Count)].transform;
        //            SFXManager.Instance.playhealClip();
        //        }
        //        else if (info.attackRange > 1)
        //        {

        //           var go = Instantiate( Resources.Load<GameObject>("human/" + type),transform.position,Quaternion.identity);
        //            go.GetComponent<Bullet>().damage = (int)info.attack;
        //            SFXManager.Instance.playcastClip();
        //        }
        //        else
        //        {

        //            GameLoopManager.Instance.monster.getDamage(info.attack);
        //            SFXManager.Instance.playHumanAttackClip();
        //        }
        //        //spriteRender.transform.DOJump(new Vector3(0, 0, 0), 1, 1, 0.2f);
        //        spriteRender.transform.DOShakeScale(0.3f);
        //    }
        //}

    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if(collision.tag == "monsterLine")
    //    {
    //        if (damageTimer > damageTime)
    //        {
    //            damageTimer = 0;
    //            getDamage(1);
    //        }
    //    }
    //}

    public override void getDamage(float d)
    {
        if (damageTimer > damageTime)
        {

            damageTimer = 0;
            base.getDamage(d);
            //if (d > 0)
            //{

            //    animator.SetTrigger("hit");

            //    if (!isDead)
            //    {

            //        SFXManager.Instance.playHitClip();
            //    }
            //    PopupTextManager.Instance.ShowPopupNumber(transform.position, (int)d, d);
            //}
            //else
            //{
            //    PopupTextManager.Instance.ShowPopupNumber(transform.position, (int)-d, d);

            //}
        }
    }

   public override void kill()
    {
        base.kill();
        transform.DOKill();
        EnemyManager.Instance.removeEnemy(this);
        Destroy(gameObject);
    }

    public override void die()
    {
        //transform.DOKill();
        //SFXManager.Instance.playDieClip();
        base.die();
        EnemyManager.Instance.removeEnemy(this);
        //EnemyGeneratorManager.Instance.removeEnemy(gameObject);
        ////ResourceManager.Instance.changeAmount(info.dropItem, info.dropAmount*( Random.Range(1,4)));
        //var test = new List<PairInfo<int>>() { };
        //test.Add(new PairInfo<int>(info.dropItem, Random.Range(1, 4)));
        ////CollectionManager.Instance.AddCoins(transform.position,test);
        //ClickToCollect.createClickToCollectItem(test, transform.position);
        //GameLoopManager.Instance.addDialogue(true, type + "_die");
        Destroy(gameObject);



    }
}
