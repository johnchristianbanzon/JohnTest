using UnityEngine;

[CreateAssetMenu(menuName = "Audio/AudioContainer")]
public class AudioContainerSO : ScriptableObject
{
    public AudioData[] SfxData;
    public AudioData[] BgmData;
}
