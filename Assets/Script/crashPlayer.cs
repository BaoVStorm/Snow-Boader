using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crashPlayer : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ground") {
            Debug.Log("Crash Player!!");

            if(crashParticle != null)
                crashParticle.Play();

            Invoke("reloadScene", 1f);
        }
    }

    void reloadScene() {
        SceneManager.LoadScene(0);
    }
}
