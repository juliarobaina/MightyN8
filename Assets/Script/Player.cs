using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject camera;
    public float Speed = 10;
    public float JumpForce = 600;
    public bool isDead = false;
    private Rigidbody2D rig;
    public bool isJumping;
    public bool doubleJump;

    public GameObject bulletPlusPrefab;
    public GameObject bulletMinusPrefab;
    public float fireRate = 50;
    public float nextFire = 0;
    public Transform shotSpawnerUp;
    public Transform shotSpawnerDown;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Shot();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        if(Input.GetAxis("Horizontal") > 0f){
            // anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        } else if(Input.GetAxis("Horizontal") < 0f){
            // anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        } else if(Input.GetAxis("Horizontal") == 0f){
            // anim.SetBool("walk", false);
        }
    }
    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if(!isJumping){
                rig.AddForce(new Vector2(0f,JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                // anim.SetBool("jump", true);
            } else {
                if(doubleJump){
                    rig.AddForce(new Vector2(0f,JumpForce/2), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 3){
            isJumping = false;
            UnityEngine.Debug.Log("enter");
            // anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.layer == 3){
            isJumping = true;
            UnityEngine.Debug.Log("exit");
        }
    }

    void Shot(){
        if(Input.GetButton("Fire1") && nextFire < Time.time){
            nextFire = Time.time + fireRate;
            GameObject tempBullet = Instantiate(bulletPlusPrefab, shotSpawnerUp.position, shotSpawnerUp.rotation);
        }
        if(Input.GetButton("Fire2") && nextFire < Time.time){
            nextFire = Time.time + fireRate;
            GameObject tempBullet = Instantiate(bulletMinusPrefab, shotSpawnerDown.position, shotSpawnerDown.rotation);
        }
    }
}
