using System.Collections.Generic;
using System;

using UnityEditor.Experimental.GraphView;


[Serializable]
public class NodePortData
{
    public string ID;
    public Direction Direction;
    public string ConnectedNodeID;

    public NodePortData(string id, Direction direction, string connectedNodeID)
    {
        ID = id;
        Direction = direction;
        ConnectedNodeID = connectedNodeID;
    }
}
