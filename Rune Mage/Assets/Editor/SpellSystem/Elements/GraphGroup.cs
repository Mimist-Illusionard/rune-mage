using UnityEditor.Experimental.GraphView;
using UnityEngine;

using System;


public class GraphGroup : Group
{
    public string ID;

    public GraphGroup(string groupTitle, Vector2 position)
    {
        title = groupTitle;
        ID = Guid.NewGuid().ToString();

        this.SetPosition(new Rect(position, Vector2.zero));
    }
}
