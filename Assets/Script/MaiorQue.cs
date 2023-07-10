using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaiorQue : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        operation = 0;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(targetDistance < attackDistance){
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
