using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public Transform leftCounterTransform;
    public Transform rightCounterTransform;
    public Vector3 offset;
    public Vector3 offset2;
    private TextMeshProUGUI leftCounterText;
    private TextMeshProUGUI rightCounterText;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        target = FindObjectOfType<Player>().transform;
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        leftCounterText = leftCounterTransform.GetComponentInChildren<TextMeshProUGUI>();
        rightCounterText = rightCounterTransform.GetComponentInChildren<TextMeshProUGUI>();
        UnityEngine.Debug.Log(leftCounterText);

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        targetDistance = transform.position.x - target.position.x;
        leftCounterTransform.position = transform.position + offset;
        rightCounterTransform.position = transform.position + offset2;
        leftCounterText.text = valueLeft.ToString();
        rightCounterText.text = valueRight.ToString();

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
        sprite.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

}
