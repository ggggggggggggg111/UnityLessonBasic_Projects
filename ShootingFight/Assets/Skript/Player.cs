using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    // ������Ƽ ( property )
    // set �Լ�, get �Լ��� ���� �������� �ʾƵ� �Ǵ� ������ ���� ź��
    private float _HP; // �����̸��տ� _ Ȥ�� m_ Ȥ�� m �� ������ ��� ���� ( Ư�� private ) ��Ī.
    public float HP
    {
        set
        {
            _HP = value;
            int HPint = (int)_HP;
            HPText.text = HPint.ToString();
            HPSlider.value = _HP / HPMax;
            
        }
        get
        {
            return _HP;
        }
    }
    [SerializeField] private float HPInit;
    [SerializeField] private float HPMax;
    [SerializeField] private Text HPText;
    [SerializeField] private Slider HPSlider;
    
    private float _score;
    public float score
    {
        set
        {
            _score = value;
            int scoreInt = (int)_score;
            scoreText.text = scoreInt.ToString();
            GameManager.instance.CheckScoreAndMoveStage(scoreInt);
        }
        get
        {
            return _score;
        }
    }
    [SerializeField] private Text scoreText;
    private void Awake()
    {
        HP = HPInit;
    }

}
