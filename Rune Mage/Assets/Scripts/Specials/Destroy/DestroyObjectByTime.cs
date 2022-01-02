using System.Collections;

using UnityEngine;


public class DestroyObjectByTime : MonoBehaviour
{
    public float DestroyTime;
     
    public bool Initialize;

    private void Start()
    {
        if (Initialize) StartCoroutine(DestroyObject());
    }

    public IEnumerator DestroyObject()
    {
        while (DestroyTime >= 0)
        {
            DestroyTime -= Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }
}
