using UnityEngine;


public class OffsetTransform : MonoBehaviour
{
    [SerializeField] private Vector3 _startPostionOffset;
    
    private void Start()
    {
        transform.position = new Vector3(gameObject.transform.position.x + _startPostionOffset.x, 
            gameObject.transform.position.y + _startPostionOffset.y, 
            gameObject.transform.position.z + _startPostionOffset.z);

        Destroy(this);
    }
}
