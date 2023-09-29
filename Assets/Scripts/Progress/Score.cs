using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;

    [SerializeField] private ButtonClick _winButton1;
    [SerializeField] private ButtonClick _winButton2;
    [SerializeField] private ButtonClick _winButton3;
    [SerializeField] private ButtonClick _winButton4;

    [SerializeField] private AllTasks _tasks;

    private int _value;
    private int _winningPoints;

    private void Start()
    {
        _winningPoints = _tasks.GetCount();
        ShowProgress();
    }

    private void OnEnable()
    {
        _winButton1.ScoreUp += OnIncreaseValue;
        _winButton2.ScoreUp += OnIncreaseValue;
        _winButton3.ScoreUp += OnIncreaseValue;
        _winButton4.ScoreUp += OnIncreaseValue;
    }

    private void OnDisable()
    {
        _winButton1.ScoreUp -= OnIncreaseValue;
        _winButton2.ScoreUp -= OnIncreaseValue;
        _winButton3.ScoreUp -= OnIncreaseValue;
        _winButton4.ScoreUp -= OnIncreaseValue;
    }

    public void OnIncreaseValue()
    {
        _value++;
        ShowProgress();
    }

    public bool IsVictory() =>_value == _winningPoints;

    private void ShowProgress()
    {
        _valueText.text = $"Прогресс: {_value}/{_winningPoints}";
    }
}
