using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSky : MonoBehaviour
{
    public GameObject skyPrefab;
    public float bias = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(skyPrefab, transform.position + new Vector3(0, bias, 0), Quaternion.identity);
    }
}
