using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed = 10;
    public int damage = 1;
    public float destroyTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        DestructBlock block = collision.gameObject.GetComponent<DestructBlock>();
        if (enemy != null)
        {
            enemy.Hited(damage);
        } else if(block != null){
            block.Hited(damage);
        }
        Destroy(gameObject);
    }
}
