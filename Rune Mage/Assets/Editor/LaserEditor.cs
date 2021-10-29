using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Laser))]
public class LaserEditor : Editor
{
    [SerializeField] private Laser _laser;

    public override void OnInspectorGUI()
    {
        _laser = (Laser)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("StartPoint"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("EndPoint"));

        if(GUILayout.Button("Refresh Positions"))
        {
            if (!_laser.StartPoint || !_laser.EndPoint) return;

            _laser.GetComponent<LineRenderer>().SetPosition(0, _laser.StartPoint.position);
            _laser.GetComponent<LineRenderer>().SetPosition(1, _laser.EndPoint.position);
        }

        if (GUI.changed)
        {
            serializedObject.ApplyModifiedProperties();

            if (!_laser.StartPoint || !_laser.EndPoint) return;

            _laser.GetComponent<LineRenderer>().SetPosition(0, _laser.StartPoint.position);
            _laser.GetComponent<LineRenderer>().SetPosition(1, _laser.EndPoint.position);
        }
    }
}
