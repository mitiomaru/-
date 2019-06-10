using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_changer : MonoBehaviour
{
    public byte push_id;//シーンを出るときのid
    public byte catch_id;//シーンに入るときのid
    //1:上　2:右　3:下　4:左 5以上:それ以外
    //例 1-3 3-1 2-4 4-2
    public GameObject player;
    public SceneObject m_nextScene;
    //public GameObject playr;
    //ゼルダみたいに上に出たら下から、右からは左に出るようになるために使う、逆もしかり
    // Start is called before the first frame update
    void Start()
    {
        if(catch_id == scene_change_manager.scene_change_id)
            Instantiate(player, transform.position, transform.rotation);
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        scene_change_manager. set_sci(push_id);
        if (c.name =="player"|| c.name == "player(Clone)") SceneManager.LoadScene( m_nextScene );
    }
}
