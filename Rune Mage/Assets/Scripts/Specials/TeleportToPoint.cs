using UnityEngine;


public class TeleportToPoint : Interactable
{
    public Transform _teleportPoint;

    protected override void OnEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var player = other.gameObject;

            player.GetComponent<CharacterController>().enabled = false;
             
            player.transform.position = _teleportPoint.position;
            player.transform.rotation = _teleportPoint.rotation;

            player.GetComponent<CharacterController>().enabled = true;
        }
    }

    protected override void OnExit(Collider other)
    {
    }   
}
