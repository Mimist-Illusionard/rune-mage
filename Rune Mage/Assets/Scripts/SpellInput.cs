using UnityEngine;


public class SpellInput : MonoBehaviour
{
    public Rune FirstRune;
    public Rune SecondRune;
    public Rune ThirdRune;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpellsSystem.Singleton.AddNewRune(FirstRune);
            Debug.Log("Press Alpha1 button");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpellsSystem.Singleton.AddNewRune(SecondRune);
            Debug.Log("Press Alpha2 button");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpellsSystem.Singleton.AddNewRune(ThirdRune);
            Debug.Log("Press Alpha3 button");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpellsSystem.Singleton.UseSpell();
        }
    }
}
