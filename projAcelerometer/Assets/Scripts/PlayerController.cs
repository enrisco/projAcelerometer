using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody Rigidbody;
    AudioSource AudioSource;
    public float Speed, JumpForce;
    public bool OnFloor;

    bool live = true;

    [SerializeField] GameManager GameManager;
    [SerializeField] AudioClip soundDeath;
    [SerializeField] AudioClip soundJump;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.touchCount > 0) 
        {
            Touch input = Input.GetTouch(0);
            if(input.phase == TouchPhase.Began) Jump(); 
        }

        if (transform.position.y < -1.5 && live) 
        {
            live = false;
            GameManager.Lose();
            AudioSource.PlayOneShot(soundDeath);
        }
    }

    private void Move()
    {
        Rigidbody.velocity = new Vector3
        (
            Input.acceleration.x * Speed,
            Rigidbody.velocity.y,
            Input.acceleration.y * Speed
        );
    }

    private void Jump()
    {
        if (!GameManager.Won && OnFloor) 
        { 
            Rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            AudioSource.PlayOneShot(soundJump);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!GameManager.Won && collision.gameObject.tag == "Flag") GameManager.Win();
        if (collision.gameObject.tag == "Floor") OnFloor = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") OnFloor = false;
    }
}
