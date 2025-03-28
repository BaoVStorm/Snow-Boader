using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float normalSpeed = 20f;
    [SerializeField] float boostSpeed = 3f;
    [SerializeField] float torque = 1f;

    [SerializeField] ParticleSystem particleSnow;

    SurfaceEffector2D surEffect;
    
    Rigidbody2D rgbd;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        surEffect = FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            rgbd.AddTorque(torque);
            // transform.Rotate(0, 0, torque);
        }
        else
        if(Input.GetKey(KeyCode.RightArrow)) {
            rgbd.AddTorque(-torque);
            // transform.Rotate(0, 0, -torque);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "boostSpeed") {
            Debug.Log("Boost Speed");

            surEffect.speed += boostSpeed;

            // rgbd.AddForce(new Vector2(300f, 0f));

            Destroy(collision.gameObject);
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground") {
            particleSnow.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground") {
            particleSnow.Stop();
        }
    }
}
