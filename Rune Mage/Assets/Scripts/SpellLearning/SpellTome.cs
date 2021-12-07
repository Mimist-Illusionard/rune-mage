using UnityEngine;


public class SpellTome : Interactable
{
    [SerializeField] private GameObject _learnPrefab;
    [SerializeField] private Spell _spell;

    public void SetSpell(Spell spell)
    {
        _spell = spell;
    }

    protected override void OnEnter(Collider other)
    {
        if (!other.GetComponent<Player>()) return;

        if (_spell)
        {
            GameObject.FindObjectOfType<HintRunes>().SetHintRunes(_spell);

            SpellsSystem.Singleton.GetSpells().Add(_spell);
        }

        var player = other.gameObject;

        player.GetComponent<CharacterController>().enabled = false;

        var teleportPosition = GameObject.FindGameObjectWithTag("TeleportPosition").transform;
        player.transform.position = teleportPosition.position;
        player.transform.rotation = teleportPosition.rotation;

        player.GetComponent<CharacterController>().enabled = true;

        Destroy(gameObject);
    }

    protected override void OnExit(Collider other)
    {
    }
}