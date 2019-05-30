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
    //プレイヤーステータス
    int Php = player1.HP, Pmp = player1.MP;
    int Patk = player1.ATK, Pdef = player1.DEF;
    int Pspd = player1.SPD;
    //エネミーステータス
    int Ehp = enemy_script.HP, Emp = enemy_script.MP;
    int Eatk = enemy_script.ATK, Edef = enemy_script.DEF;
    int Espd = enemy_script.SPD;
    //現在ステータス変数は五種存在し、体力、魔力、攻撃力、防御力、素早さでできている
    //予定としては魔撃力（MP）抵抗力（MDF）を入れたらなと

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
