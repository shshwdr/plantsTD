using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantCardCell : MonoBehaviour
{
    GameObject plantPrefab;
    PlantInfo info;
    public Image plantImage;
    public Transform orbParent;
    // Start is called before the first frame update
    void Start()
    {

        EventPool.OptIn("updateResource", updateBuyStatues);
    }

    public void init(string type)
    {
        info = PlantManager.Instance.getPlantInfo(type);
        plantPrefab = Resources.Load<GameObject>("plant/" + type);

        plantImage.sprite = Resources.Load<Sprite>("plantIcon/" + type);

        int i = 0;
        var allOrbs =
            orbParent.GetComponentsInChildren<Image>();
        for (; i < info.cost; i++)
        {
            allOrbs[i].gameObject.SetActive(true);
        }
        for (; i < allOrbs.Length; i++)
        {

            allOrbs[i].gameObject.SetActive(false);
        }
    }

    void updateBuyStatues()
    {
        if (!plantPrefab)
        {
            return;
        }
            
          if( !plantPrefab.GetComponent<BattlePlant>())

        {
            Debug.LogError("wrong plant prefab");
        }
        if (plantPrefab.GetComponent<BattlePlant>().canBuy())
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {

            GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown()
    {
        if (plantPrefab.GetComponent<BattlePlant>().canBuy())
        {

            var go = Instantiate(plantPrefab);
            MouseController.Instance.dragPlant(go.GetComponent<BattlePlant>());
        }
    }
}
