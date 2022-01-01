using System.Collections.Generic;
using System;

using UnityEngine;


public class Room : MonoBehaviour
{
    public Transform Point;

    [Header("Room Settings")]
    public bool CanBeSecretRoom = false;
    [HideInInspector()]
    public bool SecretRoom = true;
    [HideInInspector()] 
    public bool IsSecretRoom = false;
    public List<Door> Doors = new List<Door>();
    public List<Door> UsedDoors;

    [Header("Enemy Spawn Settings")]
    public int EnemyPoints;
    public List<GameObject> MainPoints;
    public List<GameObject> Enemies;

    private List<GameObject> _createdBlockDoors = new List<GameObject>();
    private bool _isTriggered;

    #region Enemy Spawning Methods
    private void OnTriggerEnter(Collider other)
    {
        if (_isTriggered || IsSecretRoom || !other.GetComponent<Player>()) return;

        AIController.Singleton.MainPoints.Clear();
        AIController.Singleton.MainPoints = MainPoints;

        var aiSpawner = GameObject.FindObjectOfType<AISpawner>();
        aiSpawner.EnemyPoints = EnemyPoints;
        aiSpawner.OnWavesEnd += DestroyExitBlockers;
        aiSpawner.PointsEnemys_1 = Enemies;
        aiSpawner.StartWaves();

        var generationConfig = GameObject.FindObjectOfType<Generator>().GetConfig();
        for (int i = 0; i < UsedDoors.Count; i++)
        {
            if (UsedDoors[i].ConnectedRoom.IsSecretRoom) continue;

            var blockDoor = Instantiate(generationConfig.BlockerDoor, UsedDoors[i].Object.transform);
            blockDoor.transform.position = new Vector3(blockDoor.transform.position.x, 2.77f, blockDoor.transform.position.z);
            _createdBlockDoors.Add(blockDoor);
        }

        _isTriggered = true;
    }

    private void DestroyExitBlockers()
    {
        "Destroying blockers".Log();
        for (int i = 0; i < _createdBlockDoors.Count; i++)
        {
            Destroy(_createdBlockDoors[i]);
        }

        GameObject.FindObjectOfType<AISpawner>().OnWavesEnd -= DestroyExitBlockers;
    }

    #endregion

    #region Generation Methods
    public Door FindNearDoor(Door target)
    {
        Door nearDoor = default;
        var distance = 999f;
        foreach (var door in Doors)
        {
            if (door.Direction != target.Direction || door.Type == target.Type) continue;
            if (door.Type == DoorType.Left && target.Type != DoorType.Right) continue;
            if (door.Type == DoorType.Right && target.Type != DoorType.Left) continue;
            if (door.Type == DoorType.Up && target.Type != DoorType.Down) continue;
            if (door.Type == DoorType.Down && target.Type != DoorType.Up) continue;

            var doorsDistance = Vector3.Distance(door.Object.transform.position, target.Object.transform.position);
            if (distance > doorsDistance)
            {
                distance = doorsDistance;
                nearDoor = door;
            }
        }

        return nearDoor;
    }

    public Door FindDoorByOppositeDoorType(DoorType doorType)
    {
        DoorType findDoorType = DoorType.None;
        switch (doorType)
        {
            case DoorType.None:
                break;
            case DoorType.Up:
                findDoorType = DoorType.Down;
                break;
            case DoorType.Down:
                findDoorType = DoorType.Up;
                break;
            case DoorType.Right:
                findDoorType = DoorType.Left;
                break;
            case DoorType.Left:
                findDoorType = DoorType.Right;
                break;
            default:
                break;
        }

        for (int i = 0; i < Doors.Count; i++)
        {
            var door = Doors[i];
            if (door.Type == findDoorType) return door;
        }

        return null;
    }

    public void RemoveDoor(Door door, Room connectedRoom)
    {
        if (Doors.Remove(door))
        {
            UsedDoors.Add(door);
            door.ConnectedRoom = connectedRoom;
        }
    }

    public bool CheckAvailable()
    {
        var boxCollider = GetComponentInChildren<BoxCollider>();
        int layerMask = 1 << 14;
        var colliders = Physics.OverlapBox(transform.position, Vector3.Scale(boxCollider.gameObject.transform.localScale, boxCollider.size) / 2, Quaternion.identity, layerMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            var collider = colliders[i];
            if (collider == boxCollider) continue;
            if (collider.GetComponentInParent<Room>())
            {
                return false;
            }
        }

        return true;
    }
    #endregion
}

[Serializable]
public class Door
{
    public GameObject Object;
    public Room ConnectedRoom;
    public Direction Direction;
    public DoorType Type;
}

public enum DoorType
{
    None  = 0,
    Up    = 1,
    Down  = 2,
    Right = 3,
    Left  = 4,
}

public enum Direction
{
    None = 0,
    X    = 1,
    Z    = 2,
    Y    = 3
}
