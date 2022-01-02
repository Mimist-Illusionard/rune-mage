using UnityEngine;


public class SpellInput : MonoBehaviour, IExecute
{
    [SerializeField] private PlayerAnimator _animator;

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
                _animator.PlayRuneUseAnimation();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (SpellsSystem.Singleton.AddNewRune(SecondRune))
            {
                CreateIcon(SecondRune);
                _animator.PlayRuneUseAnimation();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (SpellsSystem.Singleton.AddNewRune(ThirdRune))
            {
                CreateIcon(ThirdRune);
                _animator.PlayRuneUseAnimation();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpellsSystem.Singleton.UseSpell();
            RunesUi.Singleton.DeleteRuneIcons();
            _animator.PlayCastAnimation();
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
