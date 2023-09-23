using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timer;

    [SerializeField] private LosePanel _lose;
    [SerializeField] private TMP_Text _notification;

    private float _totalTime;

    private void Start()
    {
        _lose.gameObject.SetActive(false);
        _timer.text = SetTotalTime().ToString();
    }

    private void Update()
    {
        if (_totalTime > 0)
        {
            _totalTime -= Time.deltaTime;
            _timer.text = Mathf.Round(_totalTime).ToString();
        }
        else
        {
            _lose.gameObject.SetActive(true);
            _notification.text = "Кажется у тебя законичлось время!";
        }
    }

    public float SetTotalTime() => _totalTime = 15f;
}
