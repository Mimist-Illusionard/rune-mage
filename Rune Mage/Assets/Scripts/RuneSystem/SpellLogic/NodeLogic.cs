using System.Threading.Tasks;

using UnityEngine;


//TODO: Think about another nodeLogic create
public abstract class NodeLogic
{
    public SpellNodeType Type;
    public LogicType LogicType = LogicType.Immediately;

    public abstract void GenerateFields(SerilializedDictionary<string, string> fields);
    public abstract Task Logic(GameObject spell);
}
