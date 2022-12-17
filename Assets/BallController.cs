using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    // 得点
    private int score = 0;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //ゲームオーバを表示するテキスト
    private GameObject scoreText;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        // ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            // GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        // 得点を表示
        this.scoreText.GetComponent<Text>().text = this.score.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        // 小さい星に衝突した場合
        if (other.gameObject.tag == "SmallStarTag")
        {
            // 得点を10加算
            this.score += 10; 
        }
        // 大きい星に衝突した場合
        if (other.gameObject.tag == "LargeStarTag")
        {
            // 得点を20加算
            this.score += 20;
        }

        // 小さい雲に衝突した場合
        if (other.gameObject.tag == "SmallCloudTag")
        {
            // 得点を30加算
            this.score += 30;
        }

        // 大きい雲に衝突した場合
        if (other.gameObject.tag == "LargeCloudTag")
        {
            // 得点を40加算
            this.score += 40;
        }
    }
}
