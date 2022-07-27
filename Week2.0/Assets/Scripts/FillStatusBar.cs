using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthScript playerHealth;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue)
            fillImage.enabled = false;
        if (slider.value > slider.minValue && !fillImage.enabled)
            fillImage.enabled = true;
        float fillvalue = playerHealth.currentHealth / playerHealth.maxHealth;
        slider.value = fillvalue;
    }
}
