using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPosition : MonoBehaviour
{
    bool isUsed = false;
    int tileLevel = 0;
    public SpriteRenderer spriteRender;

    void updateTileState()
    {
        spriteRender.color = new Color(0, 1, 1,( tileLevel+1) / 5f);

    }
    // Start is called before the first frame update
    void Start()
    {
        updateTileState();
    }

    public void upgrade(int level)
    {
        tileLevel += level;
        updateTileState();
    }

    public void downgrade(int level)
    {

        tileLevel -= level;
        updateTileState();
    }
    public void capture()
    {
        isUsed = true;
    }

    public void release()
    {
        isUsed = false;
    }

    public bool canBuild(BattlePlant plant)
    {
        if (isUsed)
        {
            return false;
        }
        if (plant.plantInfo.minTileLevel > tileLevel)
        {
            return false;
        }
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
