using UnityEngine;
using System.Threading;

public interface IEnemyAction
{
    GameObject bject { get; set; }
    void PlayAction(GameObject @object,IEnemyAction _Parent = null);
    void ExitToMain();
}
