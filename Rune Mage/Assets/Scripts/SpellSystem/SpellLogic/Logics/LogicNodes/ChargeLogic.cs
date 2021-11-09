using System.Threading.Tasks;

using UnityEngine;

public class ChargeLogic : ISpellLogic
{
    [SerializeField] private float _charge;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Durable;
    }

    public async Task Logic(GameObject spell)
    {
        Debug.Log("ChargeNode logic");

        var chargeSlider = GameObject.FindObjectOfType<ChargeUi>();
        var currentWaitTime = 0f;
        chargeSlider.Show();

        while (true)
        {          
            currentWaitTime += Time.deltaTime;

            chargeSlider.SliderChange(currentWaitTime, _charge);

            if (currentWaitTime >= _charge)
            {
                break;
            }

            await Task.Yield();
        }

        chargeSlider.Hide();
        return;
    }
}
