using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEngine : MonoBehaviour
{
    public TransformEngine Use;

    private void Awake()
    {
        Use = this;
    }

    public static float GiveSpeed(float Distance, float Speed)
    {
        return (Distance / Speed);
    }

    public static float MathNumber(float Number, int Round)
    {
        return (float)(int)(Number * Round) / Round;
    }

    public static float MomentLerpMove(GameObject @object, Vector3 start, Vector3 end, float speed, float t)
    {
        float TT = t + MathNumber(GiveSpeed(speed, Vector3.Distance(start, end)), 1000);
        @object.transform.position = Vector3.Lerp(start, end, TT);
        return TT;
    }

    public static void TransformLookAt(GameObject @object, Vector3 vector, float RotateSpeed)
    {
        if (@object == null) return;
        Vector3 vector3 = vector - @object.transform.position;
        Quaternion quaternion = Quaternion.LookRotation(vector3, @object.transform.up);
        @object.transform.localRotation = Quaternion.Lerp(@object.transform.localRotation, quaternion, RotateSpeed * Time.deltaTime);
    }
}
