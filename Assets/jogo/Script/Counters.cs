using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counters : MonoBehaviour
{
    public Enemy enemy;
    public Vector3 offset;
    private TextMeshProUGUI leftCounterText;
    private TextMeshProUGUI rightCounterText;

    void Start()
    {
        leftCounterText = GetComponentInChildren<TextMeshProUGUI>();
        rightCounterText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        this.transform.position = enemy.transform.position + offset;
        UnityEngine.Debug.Log(leftCounterText);
        if(enemy.valueLeft.ToString() != null){
            leftCounterText.text = enemy.valueLeft.ToString();
        }
    }
}
