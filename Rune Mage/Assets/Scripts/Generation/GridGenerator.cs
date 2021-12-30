using System.Collections.Generic;
using System.Collections;
using System;

using UnityEngine;

using Sirenix.OdinInspector;


public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _startRoomPrefab;

    [SerializeField] private GenerationConfig _config;

    [SerializeField] private GridRoom[] _gridRooms;

    [SerializeField] private List<Room> _createdRooms = new List<Room>();

    private int _currentRoomAmounts;
    private float _generationTime;

    [Button("Generate")]
    private void Generate()
    {
        _generationTime = _config.GenerationTime;

        DestroyAllRooms();
        _createdRooms.Clear();
        _currentRoomAmounts = 0;

        CreateStartRoom();
        StartCoroutine(GenerationTime());
        StartCoroutine(Generation());
    }

    private void CreateStartRoom()
    {
        var startRoom = Instantiate(_startRoomPrefab);
        var room = startRoom.GetComponent<Room>();

        for (int i = 0; i < UnityEngine.Random.Range(0, 2f); i++)
        {
            room.Doors.Remove(room.Doors[UnityEngine.Random.Range(0, room.Doors.Count)]);
        }

        _createdRooms.Add(room);

        _currentRoomAmounts++;
    }

    //This coroutine regenerate dungeon if generation is bad. For example start room and only deadEnds
    private IEnumerator GenerationTime()
    {
        while (true) 
        {
            _generationTime -= Time.deltaTime;

            if (_currentRoomAmounts >= _config.MaxRoomAmount) break;

            if (_generationTime <= 0f)
            {
                DestroyAllRooms();
                StopAllCoroutines();
                Generate();
            }

            yield return new WaitForEndOfFrame();
        }
    }

    //Simple rooms deleting
    private void DestroyAllRooms()
    {
        foreach (var room in _createdRooms)
        {
            if (!room) continue;
            Destroy(room.gameObject);
        }
    }

    //Main generation method
    private IEnumerator Generation()
    {
        while (true)
        {
            if (CheckIsNeedCreateSpecial(out var specialGridRoom)) //Cheching if dungeon isn't create needed rooms.
            {
                var chosenRoom = _createdRooms[UnityEngine.Random.Range(0, _createdRooms.Count)];
                CreateRoom(specialGridRoom, chosenRoom);
            }
            else
            {
                var gridRoom = new GridRoom();
                for (int i = 0; i < _gridRooms.Length; i++) //Percentage room choser.
                {
                    gridRoom = _gridRooms[i];
                    var probability = UnityEngine.Random.Range(0, 100f);

                    if (gridRoom.Probability > probability) break;
                }

                var chosenRoom = _createdRooms[UnityEngine.Random.Range(0, _createdRooms.Count)];
                CreateRoom(gridRoom, chosenRoom);
            }

            ClearNullRooms();

            if (_currentRoomAmounts >= _config.MaxRoomAmount) break;
            yield return new WaitForSeconds(0.1f);
        }

        if (CreateBossRoom())
        {
            CreateDeadEnds();
            StartCoroutine(CreateSecretRooms());
        }
    }

    private bool CheckIsNeedCreateSpecial(out GridRoom result)
    {
        var currentMaxRoomAmount = _config.MaxRoomAmount;
        for (int i = 0; i < _gridRooms.Length; i++)
        {
            var gridRoom = _gridRooms[i];

            if (!gridRoom.IsNeedCreate) continue;
            if (currentMaxRoomAmount - gridRoom.Amount > _currentRoomAmounts)
            {
                currentMaxRoomAmount -= gridRoom.Amount;
            }
            else if (currentMaxRoomAmount - gridRoom.Amount <= _currentRoomAmounts)
            {
                result = gridRoom;
                return true;
            }
        }

        result = null;
        return false;
    }

    private bool CreateRoom(GridRoom gridRoom, Room roomPlace)
    {
        for (int i = 0; i < gridRoom.Prefabs.Length; i++)
        {
            var roomPrefab = gridRoom.Prefabs[i];

            if (roomPlace.Doors.Count <= 0) return false;
            var randomDoor = roomPlace.Doors[UnityEngine.Random.Range(0, roomPlace.Doors.Count)];
            var createdRoom = Instantiate(roomPrefab);

            createdRoom.transform.position = randomDoor.Object.transform.position;

            var nearCreatedDoor = createdRoom.GetComponent<Room>().FindNearDoor(randomDoor);

            if (nearCreatedDoor == null)
            {
                Destroy(createdRoom);
                return false;
            }
            
            SetRoomPosition(createdRoom, nearCreatedDoor, randomDoor);

            var room = createdRoom.GetComponent<Room>();
            if (!room.CheckAvailable())
            {
                Destroy(createdRoom);
                return false;
            }

            if (gridRoom.IsNeedCreate) gridRoom.Amount--;

            _generationTime = _config.GenerationTime;

            roomPlace.RemoveDoor(randomDoor);
            room.RemoveDoor(nearCreatedDoor);

            _createdRooms.Add(room);
            _currentRoomAmounts++;
        }

        return true;
    }

    private bool CreateBossRoom()
    {
        var distance = 0f;
        var roomIndex = 0;
        for (int i = 0; i < _createdRooms.Count; i++)
        {
            var createdRoom = _createdRooms[i];
            if (createdRoom.Doors.Count <= 0) continue;

            var distanceToRoom = Vector2.Distance(createdRoom.transform.position, _createdRooms[0].transform.position);
            if (distance < distanceToRoom) roomIndex = i;
        }

        var roomPlace = _createdRooms[roomIndex];
        for (int i = 0; i < _config.Boss_1.Prefabs.Length; i++)
        {
            var randomDoor = roomPlace.Doors[UnityEngine.Random.Range(0, roomPlace.Doors.Count)];

            var roomPrefab = _config.Boss_1.Prefabs[i];
            var createdRoom = Instantiate(roomPrefab);
            createdRoom.transform.position = randomDoor.Object.transform.position;

            var nearCreatedDoor = createdRoom.GetComponent<Room>().FindDoorByOppositeDoorType(randomDoor.Type);

            SetRoomPosition(createdRoom, nearCreatedDoor, randomDoor);           

            var room = createdRoom.GetComponent<Room>();
            if (!room.CheckAvailable())
            {
                Destroy(createdRoom);

                //Regenerate Dungeon
                StopAllCoroutines();
                DestroyAllRooms();
                Generate();

                return false;
            }

            roomPlace.RemoveDoor(randomDoor);
            room.RemoveDoor(nearCreatedDoor);

            _createdRooms.Add(room);
            _currentRoomAmounts++;           
        }

        return true;
    }

    //Creating walls to not used door ways
    private void CreateDeadEnds()
    {
        for (int i = 0; i < _createdRooms.Count; i++)
        {
            var createdRoom = _createdRooms[i];
            if (createdRoom.Doors.Count <= 0) continue;

            for (int j = 0; j < createdRoom.Doors.Count; j++)
            {
                var door = createdRoom.Doors[j];

                var wall = Instantiate(_config.WallPrefab, door.Object.transform);
                wall.transform.position = new Vector3(wall.transform.position.x, 2.77f, wall.transform.position.z);

                if (createdRoom.CanBeSecretRoom) createdRoom.SecretRoom = true;
            }

            for (int j = 0; j < createdRoom.Doors.Count; j++)
            {
                var door = createdRoom.Doors[j];
                createdRoom.Doors.Remove(door);
            }
        }
    }

    //Find random rooms to made from it secretRoom
    private IEnumerator CreateSecretRooms()
    {
        var time = 3f;
        var secretRooms = 0;
        if (_config.Constant) secretRooms = _config.SecretsAmount;
        else secretRooms = _currentRoomAmounts / _config.SecretsDivide;

        while (true)
        {
            var room = _createdRooms[UnityEngine.Random.Range(0, _createdRooms.Count)];
            time -= Time.deltaTime;

            if (time <= 0f) break;
            if (secretRooms <= 0) break;
            if (room.SecretRoom == false) continue;
            if (room.UsedDoors.Count > 1) continue;

            var wall = Instantiate(_config.SecretWallPrefab, room.UsedDoors[0].Object.transform);
            wall.transform.position = new Vector3(wall.transform.position.x, 2.47f, wall.transform.position.z);

            var item = Instantiate(_config.ItemsPrefabs[UnityEngine.Random.Range(0, _config.ItemsPrefabs.Length)]);
            item.transform.position = room.transform.position;
            item.transform.parent = room.transform;

            room.SecretRoom = false;
            secretRooms--;

            yield return new WaitForSeconds(0.15f);
        }       
    }

    private void ClearNullRooms()
    {
        var nullRooms = new List<Room>();
        for (int i = 0; i < _createdRooms.Count; i++)
        {
            var createdRoom = _createdRooms[i];
            if (createdRoom == null) nullRooms.Add(createdRoom);
        }

        for (int i = 0; i < nullRooms.Count; i++)
        {
            var nullRoom = nullRooms[i];
            _createdRooms.Remove(nullRoom);
            _currentRoomAmounts--;
        }
    }

    //Very strange room place method but it works...
    private void SetRoomPosition(GameObject room, Door roomsDoor, Door chosenRoomDoor)
    {
        switch (chosenRoomDoor.Direction)
        {
            case Direction.None:
                break;
            case Direction.X:
                room.transform.position = new Vector3(
                    chosenRoomDoor.Object.transform.position.x
                    + (Vector3.Distance(room.transform.position, roomsDoor.Object.transform.position)
                    * Math.Sign(chosenRoomDoor.Object.transform.localPosition.x)),
                    chosenRoomDoor.Object.transform.position.y,
                    chosenRoomDoor.Object.transform.position.z);
                break;
            case Direction.Z:
                room.transform.position = new Vector3(
                    chosenRoomDoor.Object.transform.position.x,
                    chosenRoomDoor.Object.transform.position.y,
                    chosenRoomDoor.Object.transform.position.z
                    + (Vector3.Distance(room.transform.position, roomsDoor.Object.transform.position)
                    * Math.Sign(chosenRoomDoor.Object.transform.localPosition.z)));
                break;
            default:
                break;
        }
    }
}

[Serializable]
public class GridRoom
{
    [Range(0, 100f)]
    public int Probability;
    public bool IsNeedCreate;
    [ShowIf("IsNeedCreate")]
    public int Amount;
    public GameObject[] Prefabs;
}