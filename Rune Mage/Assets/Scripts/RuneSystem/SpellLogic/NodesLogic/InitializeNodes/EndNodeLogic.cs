﻿using System.Threading.Tasks;

using UnityEngine;


public class EndNodeLogic : NodeLogic
{
    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {       
    }

    public async override Task Logic(GameObject spell)
    {
        Debug.Log("EndNode Logic");

        spell.GetComponent<IInitialize>().Initialize();

        return;
    }
}
