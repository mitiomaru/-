using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]
public class BouguData : ScriptableObject
{
    public int id;
    public string part;
    public string name;
    public string Class;
    public int rare;
    public int def;
    public int price;
    // Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
