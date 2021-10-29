using System.Threading.Tasks;

using UnityEngine;

public class ChargeNodeLogic : NodeLogic
{
    private float _charge;

    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
        LogicType = LogicType.Durable;

        var value = "";
        fields.TryGetValue("Charge", out value);

        if (!float.TryParse(value, out _charge))
            Debug.LogError($"Can't parse <b>Charge</b>:{value} into <b>charge</b> in <b>{this}</b>");
    }

    public async override Task Logic(GameObject spell)
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
