using UnityEngine;


public class DestroyIsHasPlayer : BaseOnStart
{
    public override void Logic()
    {
        if (GameObject.FindObjectsOfType<Player>().Length >= 2)
        {
            Destroy(gameObject);
        }
    }
}
