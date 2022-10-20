using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public GameObject TreePrefab;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    public bool isOnGround = true;
    public bool gameOver = false;
    void Update()
    {// checks if space is pressed to make the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) dirtParticle.Stop(); playerAudio.PlayOneShot(jumpSound, 1.0f);  
        {
            playerRb.AddForce(Vector3.up *  jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround) { 
            {
                playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump.trig");}
            }
        }
        }
        private void OnCollisionEnter(Collision collision) { 
          if (collision.gameObject.CompareTag("Ground"))
        { isOnGround = true;
        } else if (collision.gameObject.CompareTag(("Obstacle"))) playerAudio.PlayOneShot(crashSound, 1.0f); 
            {gameOver = true;}
        explosionParticle.Play();
        Debug.Log(("Game Over!"));
        gameOver = true;
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
            
        }

                                
    
      
    


    }

