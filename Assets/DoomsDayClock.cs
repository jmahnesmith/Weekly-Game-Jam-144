using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoomsDayClock : MonoBehaviour
{
    public float timeLeft = 300f;

    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Dooms Day: " + Mathf.Round(timeLeft);
        if(timeLeft < 0)
        {
            //ToDo
        }
    }
}
