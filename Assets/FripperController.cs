using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;
    private int leftId;
    private int rightId;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        foreach (Touch touch in Input.touches)
        {

            //タッチされたとき
            if (touch.phase == TouchPhase.Began)
            {
                
                //画面の左側をタッチした場合
                if (touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);

                    leftId = touch.fingerId;
                }
                //画面の右側をタッチした場合
                else if (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);

                    rightId = touch.fingerId;
                }
            }

            //画面から指を話したとき
            if (touch.phase == TouchPhase.Ended && tag == "LeftFripperTag" && leftId == touch.fingerId)
            {
                SetAngle(this.defaultAngle);
            }
            else if (touch.phase == TouchPhase.Ended && tag == "RightFripperTag" && rightId == touch.fingerId)
            {
                SetAngle(this.defaultAngle);
            }
        }



    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
