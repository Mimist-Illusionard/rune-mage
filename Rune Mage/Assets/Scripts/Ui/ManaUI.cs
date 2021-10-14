using UnityEngine;
using UnityEngine.UI;

//TODO: Change to 1 general slider logic
public class ManaUI : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        PlayerManager.Singleton.GetMana().OnMahaChange += SliderChange;
    }

    public void SliderChange(float mana, float Maxmana)
    {
        slider.value = mana / Maxmana;
    }
}
