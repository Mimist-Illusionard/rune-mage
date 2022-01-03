using UnityEngine;


public class DestroyObject : BaseOnStart
{
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public override void Logic()
    {
        Destroy();
    }
}
