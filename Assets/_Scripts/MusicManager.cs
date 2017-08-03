using UnityEngine;
using System.Collections;

[System.Serializable]
public class MusicList
{
    public AudioClip music;

    // 1 means full volume
    [Range(0f, 1f)] public float volumePercent = 1;
}

public class MusicManager : MonoBehaviour
{
    public MusicList[] musicList;
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // Note: this will not be invoked for first scene
    void OnLevelWasLoaded(int level)
    {
        if (musicList[level].music)
        {
            if (audioSource.clip != musicList[level].music)
            {
                audioSource.Stop();
                audioSource.clip = musicList[level].music;
                audioSource.volume = PlayerPrefsManager.GetMasterVolume() * musicList[level].volumePercent;
                audioSource.Play();
            }
        }
    }
}