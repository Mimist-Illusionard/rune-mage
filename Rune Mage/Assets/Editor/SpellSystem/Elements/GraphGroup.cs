using UnityEditor.Experimental.GraphView;
using UnityEngine;

using System;
using System.Collections.Generic;


public class GraphGroup : Group
{
    public string ID;

    public GraphGroup(string groupTitle, Vector2 position)
    {
        title = groupTitle;
        ID = Guid.NewGuid().ToString();

        this.SetPosition(new Rect(position, Vector2.zero));
    }

    public GroupData Save()
    {
        return new GroupData(title, ID, GetPosition().position);
    }

    protected override void OnElementsAdded(IEnumerable<GraphElement> elements)
    {
        base.OnElementsAdded(elements);

        foreach (var element in elements)
        {
            if (element is SpellNodeBase)
            {
                var node = (SpellNodeBase)element;
                node.GroupID = ID;
            }
        }
    }

    protected override void OnElementsRemoved(IEnumerable<GraphElement> elements)
    {
        base.OnElementsRemoved(elements);

        foreach (var element in elements)
        {
            if (element is SpellNodeBase)
            {
                var node = (SpellNodeBase)element;
                node.GroupID = "";
            }
        }
    }
}
