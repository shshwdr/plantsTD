using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlant : HPObject
{
    public string plantName;
    public PlantInfo plantInfo;
    PlantPosition plantPosition;
    bool isDragging = false;

    public SpriteRenderer spriteRender;

    void init()
    {
        plantInfo = PlantManager.Instance.getPlantInfo(plantName);
        info = plantInfo;
        maxhp = currentHP = info.hp;
    }

    public void renderCanPlant()
    {
        spriteRender.color = Color.green;
    }
    public void renderCantPlant()
    {
        spriteRender.color = Color.red;
    }
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        init();

    }



    // Update is called once per frame
    void Update()
    {

    }
    public override bool canAttack()
    {
        bool baseValue = base.canAttack();
        return baseValue && !isDragging;
    }

    public bool canPlant()
    {
        
        return canBuy();
    }
    public void finishPlant(PlantPosition pp)
    {
        spriteRender.color = Color.white;
        isDragging = false;
        plantPosition = pp;
        plantPosition.capture();
        ResourceManager.Instance.consumeResource("orb", plantInfo.cost);
    }

    public void startDragging()
    {
        isDragging = true;
    }

    public bool canBuy()
    {

        plantInfo = PlantManager.Instance.getPlantInfo(plantName);
        if (!ResourceManager.Instance.hasEnoughAmount("orb", plantInfo.cost))
        {
            return false;
        }
        return true;
    }

    public override void die()
    {
        base.die();

        if (plantInfo.upgradeTile > 0)
        {
            plantPosition.upgrade(plantInfo.upgradeTile);
        }

        if (plantInfo.generation > 0)
        {

            var test = new List<PairInfo<int>>() { };
            test.Add(new PairInfo<int>("orb", plantInfo.generation));
            //CollectionManager.Instance.AddCoins(transform.position,test);
            ClickToCollect.createClickToCollectItem(test, transform.position);
        }
        plantPosition.release();
    }
}
