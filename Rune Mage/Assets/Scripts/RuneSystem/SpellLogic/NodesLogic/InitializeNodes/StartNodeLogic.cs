using UnityEngine;


public class StartNodeLogic : NodeLogic
{
    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
    }

    public override void Logic(GameObject spell)
    {
        Debug.Log("StartNode Logic");
    }
}
