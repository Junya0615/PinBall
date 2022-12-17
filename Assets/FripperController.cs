using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;
    //�e�������̌X��
    private float flickAngle = -20;
    private int leftId;
    private int rightId;

    // Use this for initialization
    void Start()
    {
        //HingeJoint�R���|�[�l���g�擾
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //�����L�[�������������t���b�p�[�𓮂���
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //�E���L�[�����������E�t���b�p�[�𓮂���
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //���L�[�����ꂽ���t���b�p�[�����ɖ߂�
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

            //�^�b�`���ꂽ�Ƃ�
            if (touch.phase == TouchPhase.Began)
            {
                
                //��ʂ̍������^�b�`�����ꍇ
                if (touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);

                    leftId = touch.fingerId;
                }
                //��ʂ̉E�����^�b�`�����ꍇ
                else if (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);

                    rightId = touch.fingerId;
                }
            }

            //��ʂ���w��b�����Ƃ�
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

    //�t���b�p�[�̌X����ݒ�
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
