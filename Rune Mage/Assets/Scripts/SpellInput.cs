using UnityEngine;


public class SpellInput : MonoBehaviour, IExecute
{
    public Rune FirstRune;
    public Rune SecondRune;
    public Rune ThirdRune;

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (SpellsSystem.Singleton.AddNewRune(FirstRune))
            {
                CreateIcon(FirstRune);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (SpellsSystem.Singleton.AddNewRune(SecondRune))
            {
                CreateIcon(SecondRune);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (SpellsSystem.Singleton.AddNewRune(ThirdRune))
            {
                CreateIcon(ThirdRune);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpellsSystem.Singleton.UseSpell();
            RunesUi.Singleton.DeleteRuneIcons();
        }
    }

    private void CreateIcon(Rune rune)
    {
        RunesUi.Singleton.CreateRuneIcon(rune);
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
