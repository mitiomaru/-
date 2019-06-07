//
//Rigidbody2Dを使わないバージョン
//
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerEX : MonoBehaviour
{
    public float speed = 5;         //移動スピード
    public GameObject zapper;       //弾のprefab
    public GameObject blaster;       //弾のprefab
    public GameObject solvalouBroken; 	//爆発アニメーション用プレハブ
    public float zapperDelay = 0.3f;  //zapperの発射間隔
    public float blasterDelay = 0.7f;	//blasterの発射間隔
    private float zt = 0;           //弾の前回発射時刻計測用
    private float bt = 0;           //弾の前回発射時刻計測用
    // ★（追加）
    // 配列の定義（「複数のデータ」を入れることのできる「仕切り」付きの箱を作る）
    public GameObject[] playerIcons;
    // ★（追加）
    // プレーヤーが破壊された回数のデータを入れる箱
    public static int destroyCount = 0;


    // Use this for initialization
    void Start()
    {
        zt = Time.time;             //スタート時の時間計測
        bt = Time.time;             //スタート時の時間計測
                                    // ★（追加）
                                    // 命令ブロック（メソッド）を呼び出す。
        UpdatePlayerIcons();

    }

    // Update is called once per frame
    void Update()
    {
        //弾の発射処理
        //if (Input.GetButton ("Fire1")) {	//ボタン１が押されたら：Ctrlキー、マウス左ボタン、ゲームパッドの１ボタン
        if (Input.GetKey(KeyCode.Z))
        {   //スペースが押されたら
            float zet = Time.time;           //現在の時刻計測
            if (zet - zt > zapperDelay)
            {       //前回の時間計測との差がzapperDelayを超えたら
                zt = zet;
                //弾をプレイヤーと同じ位置/角度で作成
                Instantiate(zapper, transform.position, transform.rotation);
            }
        }
        if (Input.GetKey(KeyCode.X))
        {   //スペースが押されたら
            float bet = Time.time;           //現在の時刻計測
            if (bet - bt > blasterDelay)
            {       //前回の時間計測との差がblasterDelayを超えたら
                bt = bet;
                //弾をプレイヤーと同じ位置/角度で作成
                Instantiate(blaster, transform.position, transform.rotation);
            }
        }

        //入力チェック（入力機器を問わないバージョン：上下左右の矢印、ASDW、ゲームパッドの十字キー）
        //float x = Input.GetAxisRaw("Horizontal");		//左右：-1 ← 0 → +1
        //float y = Input.GetAxisRaw("Vertical");		//上下：-1 ← 0 → +1

        //入力チェック（上下左右の矢印）
        /*    float x=0, y=0;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			x = -1;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			x = 1;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			y = 1;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			y = -1;
		}

        //プレイ範囲は上下で4.65ずつくらいや,左右で6.3くらいやで
        
        //移動する向きを求め、ノーマライズ（正規化）つまり長さ１のベクトルを求める
        Vector3 direction = new Vector3(x,y,0).normalized;

		//移動（現在の位置＋移動する向き×スピード×update関数の１秒あたりの呼び出し割合）
		transform.position += direction * speed * Time.deltaTime;*/
        float x = Input.GetAxisRaw("Horizontal");   // 右・左の入力
        float y = Input.GetAxisRaw("Vertical");         // 上・下の入力
        Vector2 direction = new Vector2(x, y).normalized;       // 移動する向きを求める
                                                                // 画面左下のワールド座標を取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // 画面右上のワールド座標を取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 pos = transform.position;               // プレイヤーの座標を取得
        pos += direction * speed * Time.deltaTime;  // 移動量を加える
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);   // プレイヤーのx位置を画面内で制限する
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);       // プレイヤーのy位置を画面内で制限する
        transform.position = pos;       // 制限をかけた値をプレイヤーの位置とする

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name == "EnemyBullet(Clone)" || c.name == "torid r(A)" || c.name == "torid (A)")
        {
            Instantiate(solvalouBroken, transform.position, transform.rotation);
            // ★（追加）
            destroyCount += 1;
            
        }
        if(c.name == "wood(Clone)")
        {

        }
    }
    // ★（追加）
    // プレーヤーの残機数を表示する命令ブロック（メソッド）
    void UpdatePlayerIcons()
    {

        // for文（繰り返し文）・・・まずは基本形を覚えましょう！
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (destroyCount <= i)
                playerIcons[i].SetActive(true);
            else
                playerIcons[i].SetActive(false);
        }
        //Debug.Log(destroyCount);
    }
    
}
