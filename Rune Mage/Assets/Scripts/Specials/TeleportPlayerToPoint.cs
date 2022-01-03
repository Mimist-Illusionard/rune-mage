using UnityEngine;


public class TeleportPlayerToPoint : BaseOnStart
{
    public Transform TeleportPosition;

    public override void Logic()
    {
        var player = GameObject.FindObjectOfType<Player>();
        player.transform.position = TeleportPosition.position;
    }   
}
