﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAi : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Coroutine agentColorCoroutine;
    [SerializeField] private Coroutine agentPosCoroutine;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] float agentSpeed = 2f;
    [SerializeField] TypeWriterEffect typeWriterEffect;
    [SerializeField] private SoundEffectsController sound_effect_controller;
    void Start()
    {
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        AgentEnters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AgentEnters()
    {
        transform.position = new Vector3 (transform.position.x, -1f, transform.transform.position.z);
        animator.SetBool("isWalking", true);
        spriteRenderer.color = new Color32(255,255,255,0);

        Color32 enterColor = new Color (255,255,255,255);
        agentColorCoroutine = StartCoroutine(AgentColor(enterColor));
        agentPosCoroutine = StartCoroutine(AgentPos(1.56f, true));
    }
    public void AgentExits()
    { 
        animator.SetBool("isWalking", true);
        Color32 exitColor = new Color (255,255,255,0);  
        agentColorCoroutine = StartCoroutine(AgentColor(exitColor));
        agentPosCoroutine = StartCoroutine(AgentPos(0.5f, false));
    }
    public void AgentBarks()
    {
        typeWriterEffect.CallBarkText();
        sound_effect_controller.PlayAgentThanksSound();
    }
    IEnumerator AgentColor(Color32 endingColor)
    {
        float timeElapsed = 0;
        Color32 newColor;
        Color32 startColor = spriteRenderer.color;
        Color32 endColor = endingColor;

        while( timeElapsed < agentSpeed)
        {
            newColor = Color.Lerp(startColor, endColor, timeElapsed/agentSpeed);
            timeElapsed += Time.deltaTime;
            spriteRenderer.color = newColor;
            yield return null;
        }
        spriteRenderer.color = endColor;
        animator.SetBool("isWalking", false);
        agentColorCoroutine = null;
        yield return null;
    }
    IEnumerator AgentPos(float endingPos, bool entering)
    {
        if(!entering)
        {
             typeWriterEffect.CallExitText();
             sound_effect_controller.PlayByeByeSound();
        }
        float timeElapsed = 0;
        float newPos;
        float startPos = transform.position.y;
        float endPos = endingPos;

        while(timeElapsed < agentSpeed)
        {
            newPos = Mathf.Lerp(startPos, endPos, timeElapsed/agentSpeed);
            timeElapsed += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, newPos, transform.position.z);
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, endPos, transform.position.z);
        agentPosCoroutine = null;
        yield return new WaitForSeconds(2f);
        if(entering)
        {
            typeWriterEffect.CallEnterText();
            sound_effect_controller.PlayGreetingSound();
        }
        yield return null;
    }
}