using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create CSV Impoter")]
public class CsvImporter : ScriptableObject
{
    public TextAsset csvFile;
}