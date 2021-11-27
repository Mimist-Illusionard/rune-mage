using UnityEngine;

using DG.Tweening;


public class DoRotate : MonoBehaviour
{
    public Vector3 RotateVector;
    public float RotateDuration;

    public bool Initialize;
    public bool Infinite;

    private void Start()
    {
        if (Initialize)
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
