using UnityEngine;



public class CreateObjectAtCamera : MonoBehaviour
{
    public GameObject Prefab;

    public bool Initialize;   

    private void Start()
    {
        if (Initialize) CreateObject();
    }

    public void CreateObject()
    {
        Object.Instantiate(Prefab, Camera.main.transform);
    }
}
