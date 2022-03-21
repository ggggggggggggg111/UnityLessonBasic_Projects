using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    // ī�޶� 1��� ���� �ٰ��ϰ�ʹ�.
    // 
    // ���� �ʿ��ұ�? 
    // 1. ī�޶� ��ü�� Transform ������Ʈ 
    // 2. ���ָ����� Transform ������Ʈ
    //
    // ����� ���ؾ��ұ� ?
    // 1. ���ָ����� ����� �ǽð����� üũ�Ѵ�.
    // 2. 1��� ��ġ�� �����´�. 
    // 3. ī�޶��� ��ġ�� 1��� ��ġ���ٰ� Ư�� �Ÿ���ŭ ����߸���.
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
