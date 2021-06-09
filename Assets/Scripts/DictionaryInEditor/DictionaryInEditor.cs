using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DictionaryInEditor : MonoBehaviour, ISerializationCallbackReceiver
{

    [SerializeField]
    private List<string> _keys = new List<string>();
    [SerializeField]
    private List<int> _values = new List<int>();
    [SerializeField]
    private DictionaryScriptableObjcect dictionaryScriptable;

    Dictionary<string, int> myDictionary = new Dictionary<string, int>();

    public bool modifyValues;

    public void OnAfterDeserialize()
    {
      
    }

    public void OnBeforeSerialize()
    {
        if (!modifyValues)
        {
            _keys.Clear();
            _values.Clear();
            for (int i = 0; i < Mathf.Min(dictionaryScriptable.Keys.Count, dictionaryScriptable.Values.Count); i++)
            {
                _keys.Add(dictionaryScriptable.Keys[i]);
                _values.Add(dictionaryScriptable.Values[i]);

            }
        }
    }

    public void DeserializationDictionary()
    {
        Debug.Log("Deserialization");
        myDictionary = new Dictionary<string, int>();
        dictionaryScriptable.Keys.Clear();
        dictionaryScriptable.Values.Clear();
        for (int i = 0; i < Mathf.Min(_keys.Count, _values.Count); i++)
        {
            dictionaryScriptable.Keys.Add(_keys[i]);
            dictionaryScriptable.Values.Add(_values[i]);
            myDictionary.Add(_keys[i], _values[i]);

        }
        modifyValues = false;
    }
}