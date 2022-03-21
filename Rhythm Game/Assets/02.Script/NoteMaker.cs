using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;
public class NoteMaker : MonoBehaviour
{
    SongData songData;
    KeyCode[] keyCodes = {KeyCode.S, KeyCode.D,KeyCode.F,KeyCode.Space,KeyCode.J,KeyCode.K,KeyCode.L, };

    public VideoPlayer vp;
    public bool onRecord
    {
        set
        {
            if(value)
                StartRecording();
            else
                StopRecording();
        }
        get { return vp.isPlaying; }
    }

    private void Update()
    {
        if(onRecord)
        Recording();
    }
    public void StartRecording()
    {

        songData = new SongData();
        songData.videoName = vp.clip.name;
        vp.Play();
        Debug.Log($"Start");
    }
    public void Recording()
    {
        foreach(KeyCode keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode))
                CreateNotData(keyCode);
        }
        if (Input.GetKeyDown(KeyCode.Insert))
            SaveSongData();
           
    }
    public void StopRecording()
    {
        songData = null;
        vp.Stop();
    }
    private void CreateNotData(KeyCode keyCode)
    {
        NoteData noteData = new NoteData();
        float tmpTime = (float)vp.time * 100;
        if(tmpTime % 10 < 5)
        {
            tmpTime /= 10;
        }
        else
        {
            tmpTime /= 10;
            tmpTime++;
        }
        int tmpTImeInt = (int)tmpTime;
        float roundedTime = (float)tmpTime /100;

        noteData.time = roundedTime;
        noteData.keyCode = keyCode;
        songData.notes.Add(noteData);
        Debug.Log($"Created note {keyCode}");
    }
    private void SaveSongData()
    {
        string dir = EditorUtility.SaveFilePanel("저장할 곳을 지정하세요", "", $"{songData.videoName}", "json");
        System.IO.File.WriteAllText(dir, JsonUtility.ToJson(songData));
    }
}

