using UnityEngine;


public class SpellTome : Interactable
{
    [SerializeField] private Spell _spell;
    [SerializeField] private HintRunes _hintRunes;

    private Player _player;    

    public void SetSpell(Spell spell)
    {
        _spell = spell;
    }

    protected override void OnEnter(Collider other)
    {
        if (!other.GetComponent<Player>()) return;
        _player = other.GetComponent<Player>();

        if (_spell)
        {
            if (!_hintRunes) GameObject.FindObjectOfType<HintRunes>().SetHintRunes(_spell);
            else _hintRunes.SetHintRunes(_spell);

            SpellsSystem.Singleton.GetSpells().Add(_spell);
        }

        Destroy(gameObject);
    }

    public void TeleportPlayerToTeleportPosition()
    {
        _player.GetComponent<CharacterController>().enabled = false;

        var teleportPosition = GameObject.FindGameObjectWithTag("TeleportPosition").transform;
        _player.transform.position = teleportPosition.position;
        _player.transform.rotation = teleportPosition.rotation;

        _player.GetComponent<CharacterController>().enabled = true;
    }

    public void HealPlayer()
    {
        _player.GetComponent<Health>().AddHealth(30f);
    }

    protected override void OnExit(Collider other)
    {
    }
}