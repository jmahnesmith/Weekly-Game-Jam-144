using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessController : MonoBehaviour
{
    public Transform playerVision;
    public int scaleChange = 20;
    private Vector3 curScale;

    private void Start()
    {
        curScale = playerVision.localScale;
    }

    public void SetDarkness()
    {
        Vector3 changedScale = new Vector3(curScale.x - scaleChange, curScale.y - scaleChange, 0);
        if(changedScale.x > 0 && changedScale.x > 0)
        playerVision.localScale = changedScale;
        curScale = playerVision.localScale;
    }
}
