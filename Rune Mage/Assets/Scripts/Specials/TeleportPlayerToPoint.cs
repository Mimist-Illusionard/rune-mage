using UnityEngine;


public class TeleportPlayerToPoint : MonoBehaviour
{
    public Transform TeleportPosition;

    private void Start()
    {
        var player = GameObject.FindObjectOfType<Player>();
        player.transform.position = TeleportPosition.position;
    }    
}
