using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private AudioSource uiSource;
    [SerializeField] private AudioClip uiClip;

    public void PlayUIClick()
    {
        uiSource.PlayOneShot(uiClip);
    }
}
