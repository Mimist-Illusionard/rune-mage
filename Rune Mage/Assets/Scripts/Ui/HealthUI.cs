using UnityEngine;
using UnityEngine.UI;


//TODO: Change to 1 general slider logic
public class HealthUI : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        GameObject.FindObjectOfType<Health>().OnHealthChange += SliderChange;
    }

    public void SliderChange(float mana, float Maxmana)
    {
        slider.value = mana / Maxmana;
    }
}
