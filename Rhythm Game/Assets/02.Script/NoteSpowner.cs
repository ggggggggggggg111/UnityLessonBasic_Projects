using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpowner : MonoBehaviour
{
    public KeyCode keyCode;
    public GameObject notePrefad;

    public void SpawnNote()
    {
        GameObject note = Instantiate(notePrefad,transform.position,Quaternion.identity);
        note.transform.localScale = transform.lossyScale;
    }
}
