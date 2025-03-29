using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crashPlayer : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] AudioClip crashAudio;
    AudioSource audioSource;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ground" && !isDead) {
            isDead = true;

            Debug.Log("Crash Player!!");

            // this.gameObject.GetComponent<PlayerController>().DisableController();
            FindObjectOfType<PlayerController>().DisableController();


            if(crashParticle != null)
                crashParticle.Play();

            if(audioSource != null && crashAudio != null)
                audioSource.PlayOneShot(crashAudio);

            Invoke("reloadScene", 1f);
        }
    }

    void reloadScene() {
        SceneManager.LoadScene(0);
    }
}
