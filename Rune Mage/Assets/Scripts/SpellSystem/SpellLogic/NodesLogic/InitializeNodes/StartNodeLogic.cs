using System.Threading.Tasks;

using UnityEngine;


public class StartNodeLogic : NodeLogic
{
    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
    }

    public async override Task Logic(GameObject spell)
    {
        Debug.Log("StartNode Logic");
        SpellsSystem.Singleton.IsSpellCasting(true);
        return;
    }
}
