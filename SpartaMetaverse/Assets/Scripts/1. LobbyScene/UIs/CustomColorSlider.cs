using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomColorSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI colorText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateText()
    {
        colorText.text = "Range: " + slider.minValue + ", " + slider.maxValue;
    }
}
