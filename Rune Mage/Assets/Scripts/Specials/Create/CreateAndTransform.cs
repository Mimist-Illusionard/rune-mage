using UnityEngine;


public class CreateAndTransform : MonoBehaviour
{
    public GameObject Prefab;

    public bool Initialzie;
    public float DestroyTime;
   
    private void Start()
    {
        if (Initialzie) Create();
    }

    public void Create()
    {
        var createdObject = Instantiate(Prefab, gameObject.transform.position, new Quaternion(), null);
        var transformChild = createdObject.AddComponent<TransformChild>();
        transformChild.Owner = gameObject.transform;
        transformChild.DestroyTime = DestroyTime;
    }
}
