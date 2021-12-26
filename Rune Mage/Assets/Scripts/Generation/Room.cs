using System.Collections.Generic;
using System;

using UnityEngine;


public class Room : MonoBehaviour
{
    public Transform Point;

    public RoomType RoomType = RoomType.Usual;
    public bool SecretRoom = true;
    public bool CanBeSecretRoom = false;
    public List<Door> Doors = new List<Door>();
    public List<Door> UsedDoors;

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

    public void RemoveDoor(Door door)
    {
        if (Doors.Remove(door))
            UsedDoors.Add(door);
    }

    public bool CheckAvailable()
    {
        var boxCollider = GetComponentInChildren<BoxCollider>();
        var colliders = Physics.OverlapBox(transform.position, Vector3.Scale(boxCollider.gameObject.transform.localScale, boxCollider.size) / 2);
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
}

[Serializable]
public class Door
{
    public GameObject Object;
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
}

public enum RoomType
{
    None     = 0,
    Usual    = 1,
    Treasure = 2,
    Special  = 3
}
