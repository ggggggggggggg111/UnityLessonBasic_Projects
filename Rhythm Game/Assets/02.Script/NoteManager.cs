using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    static public NoteManager instance;
    static public float noteFallingSpeed = 1f;
    static public float judgeHit_Bad = 3f;
    static public float judgeHit_Miss = 2f;
    static public float judgeHit_Good = 1.7f;
    static public float judgeHit_Great = 1.5f;
    static public float judgeHit_Cool = 1.2f;

    Transform noteSpownersTransform;
    Transform noteHittersTransform;
    Dictionary<KeyCode,NoteSpowner> spowners =new Dictionary<KeyCode,NoteSpowner>();
    public Queue<NoteData> queue =new Queue<NoteData>();
    public float noteFallingDistane
    {
        get { return noteSpownersTransform.position.y - noteHittersTransform.position.y; }
    }
    public float noteFallingTime
    {
        get { return noteFallingDistane / noteFallingSpeed; }
    }
    void Awake()
    {
        instance = this;
        noteSpownersTransform = transform.Find("NoteSpowners");
        noteHittersTransform = transform.Find("NoteHit");
        NoteSpowner[] tmpSpowners = noteSpownersTransform.GetComponentsInChildren<NoteSpowner>();
        foreach (NoteSpowner spowner in tmpSpowners)
        {
            spowners.Add(spowner.keyCode, spowner);
        }
        SetDataQueue(SongSelector.Instance.songData.notes);
    }

    public void SetDataQueue(List<NoteData> notes)
    {
        notes.Sort((x,y)=>x.time.CompareTo(y.time));
        foreach (NoteData note in notes)
            queue.Enqueue(note);
    }
    public void StartSpown()
    {
        if (queue.Count > 0)
            StartCoroutine(E_SpowerNotes());
    }
    IEnumerator E_SpowerNotes()
    {
        while (queue.Count>0)
        {
            for(int i = 0; i < queue.Count; i++)
            {
                if (queue.Peek().time < GamePlay.instance.playTime)
                {
                    NoteData data = queue.Dequeue();
                    spowners[data.keyCode].SpawnNote();
                }
                else
                    break;
            }
            yield return null;
        }
    }
    public void StopSpowner()
    {
        StopAllCoroutines();
    }
}
