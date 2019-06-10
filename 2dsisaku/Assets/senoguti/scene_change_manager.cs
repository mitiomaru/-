using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_change_manager : MonoBehaviour
{
    public static byte scene_change_id;//シーンを変更するときに
    //ゼルダみたいに上に出たら下から、右からは左に出るようになるために使う、逆もしかり
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void set_sci(byte id)
    {
        scene_change_id = id;
    }
}
