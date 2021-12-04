using UnityEngine;
using DG.Tweening;


public class UpwardsFlying : MonoBehaviour
{
    [SerializeField] private float _upwardsFlying;
    [SerializeField] private float _randomFlyingInterval;
    [SerializeField] private float _duration;
    [SerializeField] private float _randomDurationInterval;
    [SerializeField] private Ease Ease = Ease.Linear;

    private float _moveAmount = 0;

    private void Start()
    {
        var randomnumber = Random.Range(0, 100);

        if (randomnumber >= 50)
        {
            UpwardsDoMove(true);
        } else
        {
            DownwardsDoMove(true);
        }
    }


    private void UpwardsDoMove(bool isStart)
    {
        if (isStart)
        {
            _moveAmount = Random.Range(_upwardsFlying, _upwardsFlying + _randomFlyingInterval);
            transform.DOMoveY(transform.position.y + _moveAmount, Random.Range(_duration, _duration + _randomDurationInterval)).SetEase(Ease).OnComplete(() => DownwardsDoMove(false));
        } else
        {
            transform.DOMoveY(transform.position.y + _moveAmount, Random.Range(_duration, _duration + _randomDurationInterval)).SetEase(Ease).OnComplete(() => DownwardsDoMove(true));
        }
    }

    private void DownwardsDoMove(bool isStart)
    {
        if (isStart)
        {
            _moveAmount = Random.Range(_upwardsFlying, _upwardsFlying + _randomFlyingInterval);
            transform.DOMoveY(transform.position.y - _moveAmount, Random.Range(_duration, _duration + _randomDurationInterval)).SetEase(Ease).OnComplete(() => UpwardsDoMove(false));
        }
        else
        {
            transform.DOMoveY(transform.position.y - _moveAmount, Random.Range(_duration, _duration + _randomDurationInterval)).SetEase(Ease).OnComplete(() => UpwardsDoMove(true));
        }        
    }
}
