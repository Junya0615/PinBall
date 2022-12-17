using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //�{�[����������\���̂���z���̍ŏ��l
    private float visiblePosZ = -6.5f;

    // ���_
    private int score = 0;

    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject gameoverText;

    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject scoreText;

    // Use this for initialization
    void Start()
    {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");

        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        // �{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            // GameoverText�ɃQ�[���I�[�o��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        // ���_��\��
        this.scoreText.GetComponent<Text>().text = this.score.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        // ���������ɏՓ˂����ꍇ
        if (other.gameObject.tag == "SmallStarTag")
        {
            // ���_��10���Z
            this.score += 10; 
        }
        // �傫�����ɏՓ˂����ꍇ
        if (other.gameObject.tag == "LargeStarTag")
        {
            // ���_��20���Z
            this.score += 20;
        }

        // �������_�ɏՓ˂����ꍇ
        if (other.gameObject.tag == "SmallCloudTag")
        {
            // ���_��30���Z
            this.score += 30;
        }

        // �傫���_�ɏՓ˂����ꍇ
        if (other.gameObject.tag == "LargeCloudTag")
        {
            // ���_��40���Z
            this.score += 40;
        }
    }
}
