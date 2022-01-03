using System.Collections;

using UnityEngine;


public class DestroyObjectByTime : BaseOnStart
{
    public float DestroyTime;

    public IEnumerator DestroyObject()
    {
        while (DestroyTime >= 0)
        {
            DestroyTime -= Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }

    public override void Logic()
    {
        StartCoroutine(DestroyObject());
    }
}
