using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encounter_monster : MonoBehaviour
{
    public int Encounter_id;
    public SceneObject batoru;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        
        if (c.name == "player" || c.name == "player(Clone)") Application.LoadLevelAdditive(batoru);
    }
}
