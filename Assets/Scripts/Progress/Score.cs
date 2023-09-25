using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;

    [SerializeField] private ButtonClick _winButton;

    private int _value;

    private void Start()
    {
        _valueText.text = $"Прогресс: {_value}/100";
    }

    private void OnEnable()
    {
        _winButton.ScoreUp += OnIncreaseValue;
    }

    private void OnDisable()
    {
        _winButton.ScoreUp -= OnIncreaseValue;
    }

    //private void Update()
    //{
    //    _valueText.text = $"Прогресс: {_value}/100";
    //}

    public void OnIncreaseValue()
    {
        _value++;
        _valueText.text = $"Прогресс: {_value}/100";
    }
}
