using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlant : HPObject,Harvestable
{
    public string plantName;
    public PlantInfo plantInfo;
    public PlantPosition plantPosition;
    bool isDragging = false;



    public SpriteRenderer spriteRender;

    public void init()
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
        plantPosition.downgrade(plantInfo.minTileLevel);
        ResourceManager.Instance.consumeResource("orb", plantInfo.cost);
        PlantManager.Instance.addPlant(this);
        SFXManager.Instance.PlantSpawn();
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

        
        plantPosition.release();
        PlantManager.Instance.removePlant(this);
        Destroy(gameObject);
    }

    

    public override void kill()
    {
        base.kill();
        plantPosition.release();
        PlantManager.Instance.removePlant(this);
        Destroy(gameObject);

    }
    public void harvest(Human human)
    {
        getDamage(human.humanInfo.attack);
        //kill();
    }
}
