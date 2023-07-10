using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float attackDistance;
    public GameObject deathAnimation;
    public int valueLeft;
    public int valueRight;
    public int operation;

    protected Animator anim;
    protected Transform target;
    protected float targetDistance;
    protected Rigidbody2D rb2d;
    protected SpriteRenderer sprite;
    private GUIStyle guiStyle = new GUIStyle();
    public Transform leftCounter;
    public Transform rightCounter;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        target = FindObjectOfType<Player>().transform;
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        targetDistance = transform.position.x - target.position.x;
    }
    
    public void Hited(int damage){

        if(operation == 0){
            valueLeft += damage;
            if(valueLeft > valueRight){
                // Instantiate(deathAnimation, transform.position, transform.rotation);

                gameObject.SetActive(false);
            } else{
                StartCoroutine(HitedCoRoutine());
            }
        } else if(operation == 1){
            valueLeft += damage;
            if(valueLeft < valueRight){
                // Instantiate(deathAnimation, transform.position, transform.rotation);
                gameObject.SetActive(false);
            }else{
                StartCoroutine(HitedCoRoutine());
            }
        }
    }

    IEnumerator HitedCoRoutine(){
        UnityEngine.Debug.Log("test");
        sprite.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    
}
