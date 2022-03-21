using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;
    public float playTime;
    void Start()
    {
        Play();
        GameManager.instance .NextState ();
    }
    public VideoPlayer vp;

    void Awake()
    {
        instance = this;
    }
     void Update()
    {
        playTime += Time.deltaTime;
    }
    private void Play() 
    {

        
        StartCoroutine(E_Play());
    }
    IEnumerator E_Play()
    {
        NoteManager.instance.StartSpown();
        yield return new WaitForSeconds(NoteManager.instance.noteFallingTime);
        vp.clip = SongSelector.Instance.clip;
        vp.Play();
    }
    public void Stop()
    {
        NoteManager.instance.StopSpowner();
    }
}
