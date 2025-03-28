using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLIne : MonoBehaviour
{
    [SerializeField] ParticleSystem finishParticle;

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
        if(collision.tag=="Player") {
            Debug.Log("Finish Game!!");

            if(finishParticle != null)
                finishParticle.Play();

            Invoke("finishGame", 0.5f);
        }
    }

    void finishGame() {
        SceneManager.LoadScene(0);
    }
}
