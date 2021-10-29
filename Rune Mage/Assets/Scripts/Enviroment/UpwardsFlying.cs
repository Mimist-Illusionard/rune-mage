using UnityEngine;
using DG.Tweening;


public class UpwardsFlying : MonoBehaviour
{
    [SerializeField] private float _upwardsFlying;
    [SerializeField] private float _randomFlyingInterval;
    [SerializeField] private float _duration;
    [SerializeField] private float _randomDurationInterval;

    private float _moveAmount = 0;

    private void Start()
    {
        UpwardsDoMove();
    }


    private void UpwardsDoMove()
    {
        _moveAmount = Random.Range(_upwardsFlying, _upwardsFlying + _randomFlyingInterval);

        transform.DOMoveY(transform.position.y + _moveAmount, Random.Range(_duration, _duration + _randomDurationInterval)).OnComplete(() => DownwardsDoMove());
    }

    private void DownwardsDoMove()
    {
        transform.DOMoveY(transform.position.y - _moveAmount, Random.Range(_duration, _duration + _randomDurationInterval)).OnComplete(() => UpwardsDoMove());
    }
}
