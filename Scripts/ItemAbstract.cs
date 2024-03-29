using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAbstract : MonoBehaviour
{
    public AudioClip collectSound;
    public AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator CollectProcess()
    {
        yield return new WaitForSeconds(collectSound.length);
        Destroy(gameObject);
    }

    public virtual void PlayCollectSound()
    {
        audioSource.PlayOneShot(collectSound);
    }
    public virtual void StartCollectProcess()
    {
        spriteRenderer.enabled = false;
        PlayCollectSound();
        StartCoroutine("CollectProcess");
    }
    public abstract void Collect();
}
