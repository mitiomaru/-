using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public GameObject enemy;  // Enemyプレハブ
    public int command_position = 0;
    private Transform playerObj;
    private Transform enemyObj;
    public player1 player;
    public enemy_script enemy0;
    int Php = player1.HP;
    int Pmp = player1.MP;
    int Patk = player1.ATK;
    int Pdef = player1.DEF;
    int Pspd = player1.SPD;
    int Ehp = enemy_script.HP;
    int Emp = enemy_script.MP;
    int Eatk = enemy_script.ATK;
    int Edef = enemy_script.DEF;
    int Espd = enemy_script.SPD;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(enemy, transform.position, transform.rotation);
        //バトル開始時、敵を召還する（まだ試験段階なので一体だけ）
        playerObj = GameObject.Find("pl").GetComponent<Transform>();
        enemyObj = GameObject.Find("en").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (playerObj == null) SceneManager.LoadScene("GAMEOVER"); ;
        //if (enemyObj == null) SceneManager.LoadScene("WIN"); ;
        //PL_ATK();
        //EN_ATK();

    }

    private int Random()
    {
        throw new NotImplementedException();
    }

    void PL_ATK()//プレイヤーの攻撃
    {
        //if (Random() % 100 > 10)//命中判定（一割外れ） 
        Ehp -= (Patk - Edef);//敵にプレイヤーが攻撃
    }
    void EN_ATK()//プレイヤーの攻撃
    {
        //if (Random() % 100 > 10)// 命中判定（一割外れ）
        Php -= (Eatk - Pdef);//プレイヤーに敵が攻撃
    }









}
