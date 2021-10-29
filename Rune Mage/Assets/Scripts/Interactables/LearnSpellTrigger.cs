using UnityEngine;

public class LearnSpellTrigger : Interactable
{
    [SerializeField] private SpellInfo _spell;

    protected override void OnEnter(Collider other)
    {
        if (!other.GetComponent<Player>()) return;

        SpellsSystem.Singleton.GetSpells().Add(_spell);

        Destroy(gameObject);
    }

    protected override void OnExit(Collider other)
    {        
    }
}
