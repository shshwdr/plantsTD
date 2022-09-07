using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image hpImage;
    float max;
    float current;
    public void updateMaxAndCurrent(float value)
    {

        max = value;
        current = value;
        updateUI();
    }
    public void updateMax(float value)
    {
        max = value;
        updateUI();
    }
    public void updateCurrent(float value)
    {
        current = value;
        updateUI();
    }

    void updateUI()
    {
        hpImage.fillAmount = current / max;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
