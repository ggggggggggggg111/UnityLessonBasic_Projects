using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    // 카메라가 1등에게 따라 붙게하고싶다.
    // 
    // 뭐가 필요할까? 
    // 1. 카메라 자체의 Transform 컴포넌트 
    // 2. 경주말들의 Transform 컴포넌트
    //
    // 쟤들로 뭘해야할까 ?
    // 1. 경주말들의 등수를 실시간으로 체크한다.
    // 2. 1등말의 위치를 가져온다. 
    // 3. 카메라의 위치를 1등말의 위치에다가 특정 거리만큼 떨어뜨린다.
    static public CameraHandler instance;
    private void Awake()
    {
        if(instance == null) instance = this;
    }

    Transform tr;
    Transform leader;
    Transform target;
    int targetindex;
    public Vector3 offset;
    [SerializeField] private Transform platformCampPoint;

    private void Start()
    {
        tr = this.gameObject.GetComponent<Transform>();

    }
    private void Update()
    {
        
        if(Input.GetKeyDown("tab"))
                SwitchNexTarget();

        if (target == null)
            SwitchNexTarget();
        else
            tr.position = target.position + offset;  
       
    }
    public void SwitchNexTarget()
    {
        targetindex++;
        if (targetindex > RacingPlay.instance.GetTotalPlayerNumber() - 1)
            targetindex = 0;
        target = RacingPlay.instance.GetPlayer(targetindex);
    }

    public void SwitchTargetTotGrade()
    {
        target = RacingPlay.instance.GetGradePlayer();
        
    }
    public void MoveToPlatform()
    {
        tr.position = platformCampPoint.position;
        tr.rotation = platformCampPoint.rotation;
    }
}
