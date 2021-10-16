using System.Collections.Generic;

using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Spell))]
public class SpellEditor : Editor
{
    [SerializeField] private Spell _spell;
    private bool _isSpellGenerated;

    private Vector2 _scrollPosition = Vector2.zero;

    public override void OnInspectorGUI()
    {
        _spell = (Spell)target;

        serializedObject.Update();
        RefreshEditor();

        if (_isSpellGenerated == false)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Length"));
            if (GUILayout.Button("Generate Spell"))
            {
                _spell.Runes.Clear();

                for (int i = 0; i < _spell.Length; i++)
                {
                    _spell.Runes.Add(null);
                }
                _isSpellGenerated = true;
            }
        }


        if (_isSpellGenerated == true)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Name"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ManaCost"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Prefab"));

            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, true, false, GUILayout.Height(200));
            GUILayout.BeginHorizontal();
            for (int i = 0; i < _spell.Length; i++)
            {
                if (_spell.Runes[i] == null)
                {
                    EditorGUILayout.BeginVertical("box");
                    GUILayout.Box("None", GUILayout.Width(100), GUILayout.Height(100));
                    DrawChooseButton(_spell.Runes, i);                   
                    EditorGUILayout.EndVertical();
                }
                else
                {
                    EditorGUILayout.BeginVertical("box", GUILayout.Width(100));
                    GUILayout.Label($"{_spell.Runes[i].Name}");
                    GUILayout.Box(_spell.Runes[i].Sprite.texture, GUILayout.Width(100), GUILayout.Height(100));
                    DrawChooseButton(_spell.Runes, i);

                    if (GUILayout.Button("Delete", GUILayout.Width(100)))
                    {
                        _spell.Runes[i] = null;
                    }

                    EditorGUILayout.EndVertical();
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.EndScrollView();

            if (GUILayout.Button("Spell Logic"))
            {
                SpellEditorWindow.Open(_spell, _spell.SpellNodes, _spell.Groups);
            }
        }

        if (_isSpellGenerated == true)
        {
            GUILayout.Space(10f);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Regenerate Spell"))
            {               
                _spell.ManaCost = 0;
                _spell.Prefab = null;
                _spell.Runes.Clear();

                _isSpellGenerated = false;
            }

            if (GUILayout.Button("Clear Graph"))
            {
                _spell.SpellNodes.Clear();
                _spell.Groups.Clear();
            }
            GUILayout.EndHorizontal();
        }

        if (GUI.changed)
        {
            serializedObject.ApplyModifiedProperties();
        }
    }

    private void RefreshEditor()
    {
        if (_spell.Runes.Count != 0 && _isSpellGenerated == false)
            _isSpellGenerated = true;
    }

    private void DrawChooseButton(List<Rune> runes, int index)
    {
        if (GUILayout.Button("Choose", GUILayout.Width(100)))
        {
            AssetDatabase.LoadAllAssetsAtPath("Assets/Resources/ScriptableObjects");
            var list = Resources.FindObjectsOfTypeAll(typeof(Rune));
            ReferenceObjectWindow.Open(list, $"ScriptableObjects/Spells/{_spell.name}", "Runes", index, true);
        }
    }
}
