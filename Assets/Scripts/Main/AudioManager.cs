
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour , IAudioManager
{
    [SerializeField]
    private AudioContainerSO _audioContainer;
    [SerializeField]
    private AudioSource _bgmAudio;
    [SerializeField]
    private AudioSource _sfxAudio;

    public AudioClip GetSfxClip(EnumMatchingAudio key)
    {
        return _audioContainer.SfxData.First(sfx =>sfx.SfxKey == key).Clip;
    }

    public void PlaySfX(EnumMatchingAudio sfx)
    {
        _sfxAudio.clip = GetSfxClip(sfx);
        _sfxAudio.Play();
    }

    public void PlayBGM(EnumMatchingAudio sfx)
    {
        _bgmAudio.clip = GetSfxClip(sfx);
        _bgmAudio.Play();
    }
}