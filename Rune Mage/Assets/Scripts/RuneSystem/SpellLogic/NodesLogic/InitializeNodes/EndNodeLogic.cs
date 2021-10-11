using UnityEngine;


public class EndNodeLogic : NodeLogic
{
    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {       
    }

    public override void Logic(GameObject spell)
    {
        Debug.Log("EndNode Logic");
    }
}
