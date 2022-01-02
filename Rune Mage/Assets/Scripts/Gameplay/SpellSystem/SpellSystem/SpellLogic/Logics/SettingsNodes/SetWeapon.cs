using System.Collections;

using UnityEngine;

public class SetWeapon : ISpellLogic
{
    [SerializeField] private Weapon _weapon;

    public LogicType LogicType { get; set; }
    public bool IsLogicEnded { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public IEnumerator Logic(GameObject spell, ISpell iSpell)
    {
        var player = PlayerManager.Singleton.GetPlayer();
        var weaponInventory = player.GetComponent<WeaponInventory>();
        weaponInventory.SetWeapon(Object.Instantiate(_weapon));

        iSpell.IsLogicEnded = true;
        yield return null;
    }
}