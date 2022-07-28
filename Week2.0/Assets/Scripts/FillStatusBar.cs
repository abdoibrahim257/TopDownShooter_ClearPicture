using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public HealthScript playerHealth;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();   
    }

    void Update()
    {
        //Debug.Log(slider.value);
        if (playerHealth.maxHealth != 0)
        {
            float fillvalue = playerHealth.currentHealth / playerHealth.maxHealth;
            slider.value = fillvalue;
        }
        if (slider.value <= slider.minValue)
            fillImage.enabled = false;
        if (slider.value > slider.minValue && !fillImage.enabled)
            fillImage.enabled = true;
    }
}
