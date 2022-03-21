using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RacingPlay : MonoBehaviour
{
    static public RacingPlay instance;

    private void Awake()
    {
        if(instance == null) instance = this;
    }



    private List<PlayerMove>list_PlayerMove = new List<PlayerMove>();
    private List<Transform> list_FinshedPlayer = new List<Transform> ();
    [SerializeField]private List<Transform> list_WinPlayer = new List<Transform> ();
    private int totalPlayerNum;
    private int grade;
    [SerializeField] Transform goal;
    [SerializeField]  Text gradePlayerNameText;
    public void Register(PlayerMove playerMove)
    {
        list_PlayerMove.Add(playerMove);
        totalPlayerNum++;
        Debug.Log($"{playerMove.gameObject.name}(��)�� ��� �Ϸ� �Ǿ����ϴ�. ���� �� ��� �� : {list_PlayerMove.Count}");

    }
    public void Update()
    {
        CheckPlayerReachedToGoalAddStopMove();
    }
    public void StartRancing()
    {
        foreach (PlayerMove playerMove in list_PlayerMove)
        {
            playerMove.doMove = true;
        }
    }
    public Transform GetPlayer ( int index)
    {
        

        Transform tmpPlayerTransform = null;
        if (index < list_PlayerMove.Count )
        {
             tmpPlayerTransform = list_PlayerMove [index].transform;
            
        }
        return tmpPlayerTransform;
    }
    private void CheckPlayerReachedToGoalAddStopMove()
    {
        PlayerMove tmpFinshedPlayerMove = null;
        foreach(PlayerMove playerMove in list_PlayerMove)
        {
            if (playerMove.transform.position.z > goal.position.z)
            {
                tmpFinshedPlayerMove = playerMove;
                break;
            }
        }
        //�÷��̾ ��ǥ������ ����������
        if (tmpFinshedPlayerMove != null)
        {
            tmpFinshedPlayerMove.doMove = false;
            list_FinshedPlayer.Add(tmpFinshedPlayerMove.transform);
            list_PlayerMove.Remove(tmpFinshedPlayerMove);
        }
        //���ְ� �����ٸ� ( ��� �÷��̾ ��ǥ�� ������� ��)
        if(list_FinshedPlayer.Count == totalPlayerNum)
        {
            //1,2,3���� �ܻ� ��ġ��Ű��, ī�޶�� �ܻ��� �ﵵ�� �Ѵ�.
            for(int i= 0; i < list_WinPlayer.Count; i++)
            {
                list_FinshedPlayer[i].position = list_WinPlayer[i].position;
            }
            CameraHandler.instance.MoveToPlatform();
            gradePlayerNameText.text = list_FinshedPlayer[0].name;
            gradePlayerNameText.gameObject.SetActive(true);
        }
    }
    public Transform GetGradePlayer()
    {
        Transform leader = list_PlayerMove[0].gameObject.GetComponent<Transform>();
        float preDistrance = list_PlayerMove[0].distance;
        foreach (PlayerMove playerMove in list_PlayerMove)
        {
            if(playerMove.distance > preDistrance)
            {
                preDistrance = playerMove.distance;
                leader = playerMove.gameObject.GetComponent<Transform>();
            }
        }
        return leader;
    }
    public int GetTotalPlayerNumber()
    {
        return list_PlayerMove.Count;
    }
}