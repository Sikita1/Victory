using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
