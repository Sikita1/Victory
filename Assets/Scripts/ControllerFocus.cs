using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerFocus : MonoBehaviour
{
    [SerializeField] private Pause _pause;
    [SerializeField] private LosePanel _losePanel;

    private bool _isFocus;

    private void Start()
    {
        _isFocus = true;
    }

    private void Update()
    {
        if (_isFocus == true)
        {
            Time.timeScale = 0f;

            if (_losePanel.gameObject.activeSelf == false
             && _pause.gameObject.activeSelf == false)
                Time.timeScale = 1f;
        }
        else
        {
            _pause.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        _isFocus = focus;
    }
}
