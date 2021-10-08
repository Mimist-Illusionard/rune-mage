
public abstract class NodeLogic
{
    public SpellNodeType Type;

    public abstract void GenerateFields(SerilializedDictionary<string, string> fields);
    public abstract void Logic();
}
