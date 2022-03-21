using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]// 인스펙터창에서 설정가능.기능
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;
    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;

   public static float sfxVolume_value;

    private void Start()
    {
     
        var obj = FindObjectsOfType<AudioManager>();

        if (obj.Length == 1)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayBGM(string p_bgmName)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (p_bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
                bgmPlayer.volume = PlayerPrefs.GetInt("BGM");
                bgmPlayer.loop = true; // BGM 반복재생.
            }
        }
    }
    public void BGM_VolumeCtr(float p_volume) //슬라이더 value값을 받아와 bgm사운드 조절.
    {
        bgmPlayer.volume = p_volume;
        PlayerPrefs.SetFloat("BGM", p_volume); // bgm의 설정 사운드를 PlayerPrefs로 저장.
    }
    public void SFX_VolumeCtr(float s_volume) //슬라이더 value값을 받아와 sfx사운드 조절.
    {
        sfxVolume_value = s_volume;
        PlayerPrefs.SetFloat("SFX", s_volume); // sfx의 설정 사운드를 PlayerPrefs로 저장.
    }

    public void StopBGM() // 멈추기 테스트.
    {
        if (bgmPlayer.isPlaying == true)
            bgmPlayer.Stop();
    }

    public void PlaySFX(string p_sfxName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (p_sfxName == sfx[i].name)
            {
                for (int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfx[i].clip;
                        sfxPlayer[x].volume = sfxVolume_value;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
                Debug.Log("모든 오디오 플레이가 재생중입니다.");
                return;
            }
        }
        Debug.Log(p_sfxName + "의 이름이 없습니다.");
    }

}
