using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip enemyDeath;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEnemyDeath()
    {
        audioSource.PlayOneShot(enemyDeath);
    }

}
