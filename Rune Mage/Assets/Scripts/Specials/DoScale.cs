using UnityEngine.Events;
using UnityEngine;

using DG.Tweening;


public class DoScale : BaseOnStart
{
    [SerializeField] private Vector3 _scaleVector;
    [SerializeField] private float _scaleDuration;

    public bool AddScale;
    public bool Initialize;

    public UnityEvent Event;

    public override void Logic()
    {
        Scale();
    }

    public void Scale()
    {
        var scaleVector = new Vector3(0f, 0f, 0f);

        if (AddScale) scaleVector = new Vector3(gameObject.transform.position.x + _scaleVector.x, gameObject.transform.position.y + _scaleVector.y, gameObject.transform.position.z + _scaleVector.z);
        else scaleVector = new Vector3(_scaleVector.x, _scaleVector.y, _scaleVector.z);

        transform.DOScale(scaleVector, _scaleDuration).OnComplete(() => Event?.Invoke());
    }
}
