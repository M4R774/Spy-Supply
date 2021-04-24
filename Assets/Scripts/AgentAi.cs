using System.Collections;
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
        animator.SetBool("isWalking", true);
        spriteRenderer.color = new Color32(255,255,255,0);

        agentColorCoroutine = StartCoroutine(AgentColor());
        agentPosCoroutine = StartCoroutine(AgentPos());
    }
    IEnumerator AgentColor()
    {
        float timeElapsed = 0;
        Color32 newColor;
        Color32 startColor = spriteRenderer.color;
        Color32 endColor = new Color (255,255,255,255);

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
    IEnumerator AgentPos()
    {
        float timeElapsed = 0;
        float newPos;
        float startPos = transform.position.y;
        float endPos = 2.5f;

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
        typeWriterEffect.CallChangeText();
        yield return null;
    }
}
