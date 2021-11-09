using System.Threading.Tasks;
using UnityEngine;

public interface ISpellLogic
{
    public LogicType LogicType { get; set; }

    void Initialize();
    Task Logic(GameObject spell);
}
