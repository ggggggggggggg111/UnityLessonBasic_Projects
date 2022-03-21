using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class SongSelector : MonoBehaviour
{
    public static SongSelector Instance;
    private void Awake()
    {
        if(Instance == null)
            Destroy(Instance);
        Instance = this;
        DontDestroyOnLoad(Instance);
    }
    public bool isPlayable { get { return songData != null && clip != null; } }
    [HideInInspector] public VideoClip clip;
    [HideInInspector] public SongData songData;
    public void LoadSong(string videoName)
    {
        clip =  Resources.Load<VideoClip>($"VideoClips/{videoName}");       
        TextAsset songDataText = Resources.Load<TextAsset>($"SongData/{videoName}");
        songData = JsonUtility.FromJson<SongData>(songDataText.ToString());

    }
}
