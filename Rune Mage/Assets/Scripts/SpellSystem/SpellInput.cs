using System.Collections;

using UnityEngine;


public class SpellInput : MonoBehaviour, IExecute
{
    [SerializeField] private Animator _castAnimator;

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
                PlayCastAnimation();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (SpellsSystem.Singleton.AddNewRune(SecondRune))
            {
                CreateIcon(SecondRune);
                PlayCastAnimation();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (SpellsSystem.Singleton.AddNewRune(ThirdRune))
            {
                CreateIcon(ThirdRune);
                PlayCastAnimation();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpellsSystem.Singleton.UseSpell();
            RunesUi.Singleton.DeleteRuneIcons();

            _castAnimator.CrossFade("RuneUse", 0.1f);

            StopAllCoroutines();
            StartCoroutine(AnimationEndListener());
        }
    }

    private void CreateIcon(Rune rune)
    {
        RunesUi.Singleton.CreateRuneIcon(rune);
    }

    private void PlayCastAnimation()
    {
        if (SpellsSystem.Singleton._currentRunes.Count / 2 == 0) _castAnimator.CrossFade("CastRune_L", 0.1f);
        else _castAnimator.CrossFade("CastRune_R", 0.1f);

        StopAllCoroutines();
        StartCoroutine(AnimationEndListener());
    }

    public IEnumerator AnimationEndListener()
    {

        yield return new WaitForSeconds(0.1f);

        var animation = _castAnimator.GetNextAnimatorClipInfo(0)[0].clip;
        var animationTime = animation.length;
        Debug.LogWarning($"Wait end of: {animation.name}");

        while (animationTime >= 0)
        {
            yield return new WaitForEndOfFrame();
            animationTime -= Time.deltaTime;
        }

        _castAnimator.CrossFade("Idle", 0.2f);
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
