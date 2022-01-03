using UnityEngine;


public class SetAxisRotation : BaseOnStart
{
    [SerializeField] private float _axisRotation;
    [SerializeField] private AxisType[] _axises;

    public override void Logic()
    {
        SetRotation();
    }

    public void SetRotation()
    {
        for (int i = 0; i < _axises.Length; i++)
        {
            var axis = _axises[i];
            switch (axis)
            {
                case AxisType.None:
                    break;

                case AxisType.AxisX:
                    transform.rotation = new Quaternion(_axisRotation, transform.rotation.y, transform.rotation.z, transform.rotation.w);
                    break;

                case AxisType.AxisY:
                    transform.rotation = new Quaternion(transform.rotation.x, _axisRotation, transform.rotation.z, transform.rotation.w);
                    break;

                case AxisType.AxisZ:
                    transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, _axisRotation, transform.rotation.w);
                    break;

                default:
                    break;
            }
        }
    }
}

public enum AxisType
{
    None  = 0,
    AxisX = 1,
    AxisY = 2,
    AxisZ = 3
}
