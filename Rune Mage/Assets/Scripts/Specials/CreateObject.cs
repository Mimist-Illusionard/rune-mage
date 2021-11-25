using UnityEngine;


public class CreateObject : MonoBehaviour
{
    public GameObject Prefab;

    public void Create()
    {
        var createdObject = Instantiate(Prefab);
        createdObject.transform.position = transform.position;
    }
}
