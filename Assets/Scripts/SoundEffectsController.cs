using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundEffectsController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource agentAudioSource;
    [SerializeField] AudioClip missionFailureAudioClip;
    [SerializeField] AudioClip incomingFaxAudioClip;
    [SerializeField] AudioClip paperAudioClip;
    [SerializeField] AudioClip footstepAudioClip;
    [SerializeField] AudioClip briefingAudioClip;
    [SerializeField] AudioClip greetingAudioClip;
    [SerializeField] AudioClip byebyeAudioClip;
    [SerializeField] AudioClip radioBlibAudioClip;
    [SerializeField] List<AudioClip> agentThanksClips;

    void Start()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if(agentAudioSource == null)
        {
            agentAudioSource = GetComponent<AudioSource>();
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

    public void PlayMissionBriefingSound()
    {
        agentAudioSource.clip = briefingAudioClip;
        agentAudioSource.Play();
    }

    public void PlayGreetingSound()
    {
        agentAudioSource.clip = greetingAudioClip;
        agentAudioSource.Play();
    }
    public void PlayByeByeSound()
    {
        agentAudioSource.clip = byebyeAudioClip;
        agentAudioSource.Play();
    }

    public void PlayRadioBlipSound()
    {
        audioSource.PlayOneShot(radioBlibAudioClip);
    }

    public void PlayAgentThanksSound()
    {
        agentAudioSource.clip = agentThanksClips[Random.Range(0, agentThanksClips.Count)];
        agentAudioSource.Play();
    }
}
