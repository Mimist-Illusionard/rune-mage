using System.Collections;

using UnityEngine;


public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _blendDuration;

    public void PlayAttackAnimation()
    {
        _animator.CrossFade("SwordAttack", _blendDuration);

        StopAllCoroutines();
        StartCoroutine(AnimationEndListener());
    }

    public void PlayRuneUseAnimation()
    {
        if (SpellsSystem.Singleton._currentRunes.Count / 2 == 0) _animator.CrossFade("CastRune_L", _blendDuration);
        else _animator.CrossFade("CastRune_R", _blendDuration);

        StopAllCoroutines();
        StartCoroutine(AnimationEndListener());
    }

    public void PlayCastAnimation()
    {
        _animator.CrossFade("RuneUse", 0.1f);

        StopAllCoroutines();
        StartCoroutine(AnimationEndListener());
    }

    private IEnumerator AnimationEndListener()
    {
        yield return new WaitForSeconds(0.1f);

        var animation = _animator.GetNextAnimatorClipInfo(0)[0].clip;
        var animationTime = animation.length;
        Debug.LogWarning($"Wait end of animation: {animation.name}");

        while (animationTime >= 0)
        {
            yield return new WaitForEndOfFrame();
            animationTime -= Time.deltaTime;
        }

        _animator.CrossFade("Idle", _blendDuration);
    }
}
