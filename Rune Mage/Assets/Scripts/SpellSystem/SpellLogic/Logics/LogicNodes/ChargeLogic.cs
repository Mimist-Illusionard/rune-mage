using System.Collections;

using UnityEngine;

public class ChargeLogic : ISpellLogic
{
    [SerializeField] private float _charge;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Durable;
    }

    public IEnumerator Logic(GameObject spell, ISpell ISpell)
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

            yield return new WaitForEndOfFrame();
        }

        ISpell.IsLogicEnded = true;
        chargeSlider.Hide();
    }
}
