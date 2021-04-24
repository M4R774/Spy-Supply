using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] List<AudioClip> menuAudioClips;
    [SerializeField] List<AudioClip> footstepAudioClips;
    [SerializeField] Coroutine footstepsCoroutine = null;

    void Start()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        
    }
    public void PlayMenuSound() // Plays random sound from menuAudioClips list
    {
        int i = Random.Range(0,menuAudioClips.Count);
        audioSource.PlayOneShot(menuAudioClips[i]);
    }
    public void PlayFootSteps() // Plays footstep from footstepsAudioClips in the order they are in
    {
        if(footstepsCoroutine == null)
        {
            footstepsCoroutine = StartCoroutine(FootSteps());
        }
    }
    IEnumerator FootSteps()
    {
        for(int i = 0; i < 3; i++)
        {
            audioSource.PlayOneShot(footstepAudioClips[i]);
            yield return new WaitForSeconds(0.25f);
        }
        yield return null;
    }
}
