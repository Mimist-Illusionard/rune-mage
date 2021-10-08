using System;
using System.Collections.Generic;

using UnityEngine;


[Serializable]
public class SerilializedDictionary<TKey, TValue>
{
    [SerializeField] private List<SerilializedDictionaryData> _data;

    public SerilializedDictionary()
    {
        _data = new List<SerilializedDictionaryData>();
    }

    public void Add(TKey key, TValue value)
    {
        _data.Add(new SerilializedDictionaryData(key, value));
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        for (int i = 0; i < _data.Count; i++)
        {
            var dictionaryData = _data[i];
            if (dictionaryData.Key.ToString() == key.ToString())
            {
                value = dictionaryData.Value;
                return true;
            }
        }

        value = default;
        return false;
    }

    [Serializable]
    private class SerilializedDictionaryData
    {
        [SerializeField] public TKey Key;
        [SerializeField] public TValue Value;

        public SerilializedDictionaryData(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
