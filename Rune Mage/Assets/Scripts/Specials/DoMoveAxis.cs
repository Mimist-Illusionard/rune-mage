using UnityEngine.Events;
using UnityEngine;

using DG.Tweening;


public class DoMoveAxis : BaseOnStart
{
    [SerializeField] private Vector3 _moveVector;
    [SerializeField] private float _moveDuration;

    [SerializeField] private UnityEvent _event;

    public override void Logic()
    {
        var moveVector = new Vector3(gameObject.transform.position.x + _moveVector.x, gameObject.transform.position.y + _moveVector.y, gameObject.transform.position.z + _moveVector.z);
        transform.DOMove(moveVector, _moveDuration).OnComplete(() => _event?.Invoke());
    }
}
