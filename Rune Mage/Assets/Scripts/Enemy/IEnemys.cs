using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemys
{
    Vector3 CurretPos { get; set; }
    Vector3 TargetPos { get; set; }
    float TargetDistance { get; set; }
    bool TargetVisible { get; set; }
    bool ActionPoint { get; set; }
    void GetTargetInfo();
    void GetAction();
    void Death();
}
