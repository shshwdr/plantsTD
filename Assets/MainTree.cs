using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTree : MonoBehaviour, Harvestable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void harvest(Human human)
    {
        GameLoopManager.Instance.gameover();
    }
}
