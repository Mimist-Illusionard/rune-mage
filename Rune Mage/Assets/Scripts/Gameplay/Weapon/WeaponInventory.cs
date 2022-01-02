using System.Collections.Generic;

using UnityEngine;


public class WeaponInventory : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Weapon _currentWeapon;

    [SerializeField] private Transform _swordSpawnpoint;
    [SerializeField] private List<Transform> _spheresSpawnpoints;

    private List<GameObject> _createdWeapons = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _currentWeapon != null && _currentWeapon.Durability > 0)
        {
            _animator.PlayAttackAnimation();
            UseWeaponLogic();

            if (_currentWeapon.Durability <= 0)
            {
                foreach (var weapon in _createdWeapons)
                {
                    Destroy(weapon);
                    _currentWeapon = null;
                }
            }
        }
    }

    private void InitializeWeapon()
    {
        switch (_currentWeapon.Type)
        {
            case WeaponType.None:
                break;

            case WeaponType.Sword:
                var createdObject = Instantiate(_currentWeapon.WeaponPrefab, _swordSpawnpoint);

                createdObject.transform.position = _swordSpawnpoint.position;

                _createdWeapons.Add(createdObject);
                break;

            case WeaponType.Spheres:
                for (int i = 0; i < _spheresSpawnpoints.Count; i++)
                {
                    var sphereSpawnpoint = _spheresSpawnpoints[i];
                    var createdObject_2 = Instantiate(_currentWeapon.WeaponPrefab, sphereSpawnpoint);

                    createdObject_2.transform.position = sphereSpawnpoint.position;

                    _createdWeapons.Add(createdObject_2);
                }
                break;

            default:
                break;
        }
    }

    private void UseWeaponLogic()
    {
        _currentWeapon.UseLogic();
        _currentWeapon.Durability--;
    }

    public void SetWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        InitializeWeapon();
    }
}
