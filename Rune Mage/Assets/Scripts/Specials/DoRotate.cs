using UnityEngine;

using DG.Tweening;


public class DoRotate : BaseOnStart
{
    public Vector3 RotateVector;
    public float RotateDuration;

    public bool Initialize;
    public bool Infinite;

    public override void Logic()
    {
        Rotate();
    }

    public void Rotate()
    {
        var tween = transform.DORotate(RotateVector, RotateDuration, RotateMode.LocalAxisAdd).OnComplete(() => OnRotateEnd());        
    }

    private void OnRotateEnd()
    {
        if (Infinite)
        {
            RotateVector = new Vector3(RotateVector.x + RotateVector.x, RotateVector.y + RotateVector.y, RotateVector.z + RotateVector.z);
            transform.DORotate(RotateVector, RotateDuration, RotateMode.LocalAxisAdd).OnComplete(() => OnRotateEnd());
        }
    }
}
