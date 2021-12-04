using UnityEngine;


public class TeleportTrigger : Interactable
{
    protected override void OnEnter(Collider other)
    {
        if (!other.GetComponent<Player>()) return;

        var player = other.gameObject;

        player.GetComponent<CharacterController>().enabled = false;

        var teleportPosition = GameObject.FindGameObjectWithTag("TeleportPosition_2").transform;
        player.transform.position = teleportPosition.position;
        player.transform.rotation = teleportPosition.rotation;

        player.GetComponent<CharacterController>().enabled = true;
    }

    protected override void OnExit(Collider other)
    {
    }
}
