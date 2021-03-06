using UnityEngine;
using UnityEngine.UI;


//TODO: Change to 1 general slider logic
public class HealthUI : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        var health = GameObject.FindObjectOfType<Player>().gameObject.GetComponentInObject<Health>();

        health.OnHealthChange += SliderChange;
        health.AddHealth(0);
    }

    public void SliderChange(float mana, float Maxmana)
    {
        slider.value = mana / Maxmana;
    }
}
