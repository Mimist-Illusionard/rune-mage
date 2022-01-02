using UnityEngine;


public class CreateObject : MonoBehaviour
{
    public GameObject Prefab;

    public bool Initialize;

    private void Start()
    {
        if (Initialize) Create();
    }

    public void Create()
    {
        var createdObject = Instantiate(Prefab);
        createdObject.transform.position = transform.position;
    }
}
