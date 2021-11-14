using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using Sirenix.OdinInspector;


[CreateAssetMenu(fileName = "Spell", menuName = "Data/SpellSystem/Spell")]
[Serializable]
public class Spell : SerializedScriptableObject, ISpell
{
    [PreviewField(80f, Alignment = ObjectFieldAlignment.Left), HideLabel, HorizontalGroup("Split",80)]
    public Sprite Sprite;

    [LabelText("Bullet"), VerticalGroup("Split/Right"), LabelWidth(60), PropertyOrder(3)]
    public GameObject _Prefab;

    [HideInInspector()]
    public List<Rune> Runes = new List<Rune>();

    [LabelText("Input"), VerticalGroup("Split/Right"), LabelWidth(60), PropertyOrder(4)]
    public InputModeType InputMode = InputModeType.Down;

    [LabelText("Name"), VerticalGroup("Split/Right"), LabelWidth(60)]
    public string Name;

    [TextArea(), VerticalGroup("Split/Right"), LabelWidth(60), PropertyOrder(5)]
    public string Description;

    [LabelText("Cost"), VerticalGroup("Split/Right"), LabelWidth(60)]
    public float ManaCost;

    [HideInInspector]
    public float Interval;

    public List<ISpellLogic> SpellLogics = new List<ISpellLogic>();

    private Vector2 _scrollPosition = Vector2.zero;

    public GameObject Prefab => _Prefab;
    public bool IsLogicEnded { get; set; }

    public void SpellLogic()
    {
        IsLogicEnded = false;

        var spell = Instantiate(Prefab);

        for (int i = 0; i < SpellLogics.Count; i++)
        {
            var spellLogic = SpellLogics[i];
            spellLogic.Initialize();
        }

        CoroutineManager.Singleton.RunCoroutine(Logic(spell));
    }

    private IEnumerator Logic(GameObject spell)
    {
        int spellCount = SpellLogics.Count;
        int currentSpellCount = 0;

        var nextSpellLogic = SpellLogics[currentSpellCount];

        CoroutineManager.Singleton.RunCoroutine(nextSpellLogic.Logic(spell, this));

        while (true)
        {
            if (nextSpellLogic.LogicType == LogicType.Durable)
            {
                yield return new WaitForEndOfFrame();
            }

            if (IsLogicEnded)
            {
                currentSpellCount++;

                if (currentSpellCount == spellCount)
                {
                    break;
                }

                IsLogicEnded = false;
                nextSpellLogic = SpellLogics[currentSpellCount];
                CoroutineManager.Singleton.RunCoroutine(nextSpellLogic.Logic(spell, this));
            }
        }

        if (spell) spell.GetComponent<IInitialize>().Initialize();
        IsLogicEnded = false;
    }

    #region Inspector
#if UNITY_EDITOR

    [OnInspectorGUI(), PropertyOrder(6)]
    private void DrawRunes()
    {
        if (GUILayout.Button("Add Rune", GUILayout.MaxWidth(120f)))
        {
            Runes.Add(null);
        }

        _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, true, false, GUILayout.Height(200));
        GUILayout.BeginHorizontal("box");
        for (int i = 0; i < Runes.Count; i++)
        {
            if (Runes[i] == null)
            {
                EditorGUILayout.BeginVertical("box");
                GUILayout.Box("None", GUILayout.Width(100), GUILayout.Height(100));
                DrawChooseButton(Runes, i);
                if (GUILayout.Button("Delete", GUILayout.Width(100)))
                {
                    Runes.Remove(Runes[i]);
                }
                EditorGUILayout.EndVertical();
            }
            else
            {
                EditorGUILayout.BeginVertical("box", GUILayout.Width(100));
                GUILayout.Label($"{Runes[i].Name}");
                GUILayout.Box(Runes[i].Sprite.texture, GUILayout.Width(100), GUILayout.Height(100));

                DrawChooseButton(Runes, i);
                if (GUILayout.Button("Delete", GUILayout.Width(100)))
                {
                    Runes.Remove(Runes[i]);
                }
                EditorGUILayout.EndVertical();
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndScrollView();
    }

    private void DrawChooseButton(List<Rune> runes, int index)
    {
        if (GUILayout.Button("Choose", GUILayout.Width(100)))
        {
            AssetDatabase.LoadAllAssetsAtPath("Assets/Resources/ScriptableObjects");
            var list = Resources.FindObjectsOfTypeAll(typeof(Rune));
            ReferenceObjectWindow.Open(list, $"ScriptableObjects/Spells/{name}", "Runes", index, true);
        }
    }
#endif
    #endregion
}
