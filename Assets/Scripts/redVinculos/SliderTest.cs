using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class SliderTest : MonoBehaviour
{
    public Slider sliderInstance;

    public int minValue;
    public int maxValue;

    [SerializeField] TextMeshProUGUI textMin;
    [SerializeField] TextMeshProUGUI textMax;


    void Start()
    {
        sliderInstance.minValue = minValue;
        sliderInstance.maxValue = maxValue;
        sliderInstance.wholeNumbers = true;
        sliderInstance.value = 1;

        textMin.text = minValue + " Hrs";
        textMax.text = maxValue + " Hrs";

    }

public void OnValueChanged(float value)
    {
        Debug.Log("New value " + value);
    }

}
