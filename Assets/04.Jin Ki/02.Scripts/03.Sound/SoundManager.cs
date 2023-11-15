using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonClass<SoundManager>
{
    #region Declaration & Definition
    public float masterVolumeBGM = 1.0f;
    public float masterVolumeSFX = 1.0f;

    [SerializeField] AudioClip BGMClip;
    [SerializeField] AudioClip[] audioClip;

    [Header("Audio Sources")]
    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] AudioSource sfxPlayer;

    Dictionary<string, AudioClip> audioClipDic;
    #endregion

    #region Unity Default Method
    private void Awake()
    {
        AwakeAfter();
    }

    #endregion

    #region Method
    void SetUpBGM()
    {
        if (BGMClip == null)
            return;

        GameObject child = new GameObject("BGM");
        child.transform.SetParent(transform);
        bgmPlayer.clip = BGMClip;
        bgmPlayer.volume = masterVolumeBGM;
    }

    void AwakeAfter()
    {
        //SetUpBGM();

        if (null != audioClipDic)
            return;

        audioClipDic = new Dictionary<string, AudioClip>();
        foreach (AudioClip item in audioClip)
            audioClipDic.Add(item.name, item);
    }

    public void PlaySound(string soundName, float soundVolume = 1.0f)
    {
        if (audioClipDic.ContainsKey(soundName) == false)
        {
            Debug.Log(soundName + "is not Contained");
            return;
        }

        sfxPlayer.PlayOneShot(audioClipDic[soundName], soundVolume * masterVolumeSFX);
    }

    public void PlayRandomSound(string[] soundNameArray, float soundVolume = 1.0f)
    {
        string playClipArray;

        playClipArray = soundNameArray[Random.Range(0, soundNameArray.Length)];

        if (audioClipDic.ContainsKey(playClipArray) == false)
        {
            Debug.Log(playClipArray + "is not Contained");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipDic[playClipArray], soundVolume * masterVolumeSFX);
    }

    public void PlayLoopSound(string soundName)
    {
        if (null == audioClipDic)
            AwakeAfter();

        if (audioClipDic.ContainsKey(soundName) == false)
            Debug.Log(soundName + "is not Contained");

        bgmPlayer.playOnAwake = false;
        bgmPlayer.clip = audioClipDic[soundName];
        bgmPlayer.volume = masterVolumeSFX;
        bgmPlayer.loop = true;
        bgmPlayer.Play();
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    public void SetVolumeSFX(float soundVolume)
    {
        masterVolumeSFX = soundVolume;
    }

    public void SetVolumeBGM(float soundVolume)
    {
        masterVolumeBGM = soundVolume;
        bgmPlayer.volume = masterVolumeBGM;
    }
    #endregion
}
