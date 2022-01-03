using UnityEngine;


public class OffsetTransform : BaseOnStart
{
    [SerializeField] private Vector3 _startPostionOffset;

    public override void Logic()
    {
        transform.position = new Vector3(gameObject.transform.position.x + _startPostionOffset.x,
            gameObject.transform.position.y + _startPostionOffset.y,
            gameObject.transform.position.z + _startPostionOffset.z);

        Destroy(this);
    }
}
