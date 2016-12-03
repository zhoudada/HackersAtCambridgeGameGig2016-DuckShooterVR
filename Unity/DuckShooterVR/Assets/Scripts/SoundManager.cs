using UnityEngine;
using System.Collections.Generic;



public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField]
    private AudioSource _laser_sound;
    [SerializeField]
    private AudioSource _rocket_sound;
    [SerializeField]
    private AudioSource _duck_normal;
    [SerializeField]
    private AudioSource __background_sound;
    [SerializeField]
    private AudioSource _explosionSound;
    [SerializeField]
    private AudioSource _bigExplosionSound;
    [SerializeField]
    private AudioSource __reward_sound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                DestroyImmediate(gameObject);
            }
        }
    }

    private void PlayAudioSource(AudioSource source)
    {
        if (source != null)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
            source.Play();
        }
    }

    private void StopAudioSource(AudioSource source)
    {
        if (source != null)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
        }
    }

    public void PlayLaserSound()
    {
        PlayAudioSource(_laser_sound);
    }

    public void PlayRocketSound()
    {
        PlayAudioSource(_rocket_sound);
    }

    public void PlayDuckSound()
    {
        PlayAudioSource(_duck_normal);
    }

    //public void PlayShiftSound()
    //{
    //    PlayAudioSource(_warning_sound);
    //}

    public void PlayRewardSound()
    {
        PlayAudioSource(__reward_sound);
    }

    public void PlayExplosionSound()
    {
        PlayAudioSource(_explosionSound);
    }

    public void PlayBigExplosionSound()
    {
        PlayAudioSource(_bigExplosionSound);
    }

}
