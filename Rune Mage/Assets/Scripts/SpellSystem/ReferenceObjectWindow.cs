using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class ReferenceObjectWindow : EditorWindow
{

    private static string _objectPath;
    private static string _fieldName;
    private static bool _isArray;
    private static int _index;
    private static Object[] _objects;

    private Vector2 _scrollPosition = Vector2.zero;

    public static void Open(Object[] objects, string objectPath, string fieldName, int index = 0, bool isArray = false)
    {
        _objects = objects;
        _objectPath = objectPath;
        _fieldName = fieldName;

        _index = index;
        _isArray = isArray;

        GetWindow<ReferenceObjectWindow>($"{objects} Reference Window");
    }

    private void OnGUI()
    {
        _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, false, true);
        for (int i = 0; i < _objects.Length; i++)
        {
            var item = _objects[i];

            if (item.name == "") continue;

            GUILayout.BeginHorizontal();
            GUILayout.Box(AssetPreview.GetAssetPreview(item), GUILayout.Width(20), GUILayout.Height(20));
            GUILayout.Box(item.name, GUILayout.ExpandWidth(true));
            if (GUILayout.Button("Choose", GUILayout.Width(80)))
            {
                ScriptableObject @object = Resources.Load<ScriptableObject>($"{_objectPath}");

                if (_isArray)
                {
                    System.Collections.IList objectArray = (System.Collections.IList)@object.GetType().GetField(_fieldName).GetValue(@object);
                    objectArray[_index] = item;
                }
                else
                {
                    @object.GetType().GetField(_fieldName).SetValue(@object, item);
                }

                Close();
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.EndScrollView();

        if (GUILayout.Button("Close"))
        {
            Close();
        }
    }

}
#endif
