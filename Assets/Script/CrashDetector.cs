using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashDelay = .5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground" && hasCrashed == false)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerControler>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", crashDelay);
        }    
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
        hasCrashed = false;
    }
}
