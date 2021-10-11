using System.Collections.Generic;
using System;

using UnityEngine;


[Serializable]
public class SpellNodeData
{
    public string Name;
    public string ID;
    public SpellNodeType Type;
    public string GroupID;
    public Vector2 Position;

    public SerilializedDictionary<string, string> Fields = new SerilializedDictionary<string, string>();
    public List<NodePortData> Ports;

    public NodePortData GetOutputPort()
    {
        for (int i = 0; i < Ports.Count; i++)
        {
            var port = Ports[i];
            if (port.Direction == UnityEditor.Experimental.GraphView.Direction.Output)
            {
                return port;
            }
        }

        return null;
    }
}
