using UnityEngine;
using UnityEngine.UI;

public class ChargeUi : MonoBehaviour
{
    public Slider slider;
   
    public void SliderChange(float value, float maxValue)
    {
        slider.value = value / maxValue;
    }

    public void Show()
    {
        slider.gameObject.SetActive(true);
    }

    public void Hide()
    {
        slider.gameObject.SetActive(false);
    }
}
