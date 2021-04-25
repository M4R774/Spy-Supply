using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentAi : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Coroutine agentColorCoroutine;
    [SerializeField] private Coroutine agentPosCoroutine;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] float agentSpeed = 2f;
    [SerializeField] TypeWriterEffect typeWriterEffect;
    [SerializeField] private SoundEffectsController sound_effect_controller;
    [SerializeField] private GameObject case_file;
    [SerializeField] private Image case_file_sprite;
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
        case_file_sprite = case_file.GetComponent<Image>();
        AgentEnters();
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

    IEnumerator FadeInAndOutCaseFile(Color32 endingColor)
    {
        float timeElapsed = 0;
        Color32 newColor;
        Color32 startColor = case_file_sprite.color;
        Color32 endColor = endingColor;

        while (timeElapsed < agentSpeed)
        {
            newColor = Color.Lerp(startColor, endColor, timeElapsed / agentSpeed);
            timeElapsed += Time.deltaTime;
            case_file_sprite.color = newColor;
            yield return null;
        }
        case_file_sprite.color = endColor;
        if (endColor.a == 0)
        {
            case_file.SetActive(false);
        }
        yield return null;
    }

    IEnumerator AgentPos(float endingPos, bool entering)
    {
        if(!entering)
        {
            typeWriterEffect.CallExitText();
            sound_effect_controller.PlayByeByeSound();
            StartCoroutine(FadeInAndOutCaseFile(new Color(255, 255, 255, 0)));
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
            case_file.SetActive(true);
            case_file_sprite.color = new Color(255, 255, 255, 0);
            StartCoroutine(FadeInAndOutCaseFile(new Color(255, 255, 255, 255)));
        }
        yield return null;
    }
}