using UnityEngine;
using GameDev.Common;

/// <summary>
/// Insanely basic audio system which supports 3D sound.
/// Ensure you change the 'Sounds' audio source to use 3D spatial blend if you intend to use 3D sounds.
/// </summary>
public class AudioSystem : StaticInstance<AudioSystem>
{
    [SerializeField] private AudioSource _musicSource, _cannonSource;
    [SerializeField] private AudioSource _soundsSource;
    public bool canPlayFireSound = false;

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void PlayFireSound(AudioClip clip)
    {
        if (canPlayFireSound)
        {
            _cannonSource.clip = clip;
            _cannonSource.Play();
        }
    }

    public void PlaySound(AudioClip clip, Vector3 pos, float vol = 1)
    {
        _soundsSource.transform.position = pos;
        PlaySound(clip, vol);
    }

    public void PlaySound(AudioClip clip, float vol = 1)
    {
        _soundsSource.PlayOneShot(clip, vol);
    }
}