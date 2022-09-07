using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenu : MonoBehaviour
{
    PlantCardCell[] cells;
    void Start()
    {
        cells = GetComponentsInChildren<PlantCardCell>();
        updateUI();
        EventPool.OptIn("updateResource", updateUI);
    }

    public void updateUI()
    {

        int i = 0;
        foreach (var plant in PlantManager.Instance.plantInfos)
        {
            cells[i].gameObject.SetActive(true);
            cells[i].init(plant.type);
            i++;
        }
        for (; i < cells.Length; i++)
        {
            cells[i].gameObject.SetActive(false);
        }
        //for (; i < cells.Length; i++)
        //{
        //    cells[i].gameObject.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
