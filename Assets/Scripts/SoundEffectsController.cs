using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip missionFailureAudioClip;
    [SerializeField] AudioClip incomingFaxAudioClip;
    [SerializeField] AudioClip paperAudioClip;
    [SerializeField] AudioClip footstepAudioClip;

    void Start()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayMissionFailureSound()
    {
        audioSource.PlayOneShot(missionFailureAudioClip);
    }

    public void PlayPaperSound()
    {
        audioSource.PlayOneShot(paperAudioClip);
    }

    public void PlayFootstepSound()
    {
        audioSource.PlayOneShot(footstepAudioClip);
    }

    public void PlayIncomingFaxSound()
    {
        audioSource.clip = incomingFaxAudioClip;
        audioSource.PlayDelayed(2);
    }
}
