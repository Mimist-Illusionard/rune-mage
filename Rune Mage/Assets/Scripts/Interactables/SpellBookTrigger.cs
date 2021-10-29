using UnityEngine;


public class SpellBookTrigger : Interactable
{
    protected override void OnEnter(Collider other)
    {
        if (!other.GetComponent<Player>()) return;

        var spellBook = GameObject.Find("SpellBook").GetComponentInObject<SpellBook>();
        spellBook.Open();
    }

    protected override void OnExit(Collider other)
    {
        if (!other.GetComponent<Player>()) return;

        var spellBook = GameObject.Find("SpellBook").GetComponentInObject<SpellBook>();
        spellBook.Close();
    }
}
