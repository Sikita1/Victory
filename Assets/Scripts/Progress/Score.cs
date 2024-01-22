using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;

    [SerializeField] private ButtonClick _winButton1;
    [SerializeField] private ButtonClick _winButton2;
    [SerializeField] private ButtonClick _winButton3;
    [SerializeField] private ButtonClick _winButton4;

    [SerializeField] private AllTasks _tasks;

    private const string _saveKey = "valueSave";

    private int _value;
    private int _winningPoints;

    public int ValueYoung { get; private set; }
    public int ValueAbstruse { get; private set; }
    public int ValueAncient { get; private set; }

    private void Start()
    {
        Load();
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

    public bool IsVictory() => _value == _winningPoints;

    public void OnIncreaseValue()
    {
        _value++;

        ValueYoung = GetCurrentValue("GameYoung", ValueYoung);
        ValueAbstruse = GetCurrentValue("GameAbstruse", ValueAbstruse);
        ValueAncient = GetCurrentValue("GameAncient", ValueAncient);

        Save();
        ShowProgress();
    }

    private void Save()
    {
        SaveManager.Save(_saveKey, GetSaveScore());
    }

    private void Load()
    {
        var data = SaveManager.Load<SaveData.ScoreController>(_saveKey);

        ValueYoung = data.ScoreYoung;
        ValueAbstruse = data.ScoreAbstruse;
        ValueAncient = data.ScoreAncient;
    }

    private SaveData.ScoreController GetSaveScore()
    {
        var data = new SaveData.ScoreController()
        {
            ScoreYoung = ValueYoung,
            ScoreAbstruse = ValueAbstruse,
            ScoreAncient = ValueAncient
        };

        return data;
    }

    private int GetCurrentValue(string sceneName, int valueScene)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
            if (_value > valueScene)
                valueScene = _value;

        return valueScene;
    }

    private void ShowProgress()
    {
        _valueText.text = $"Прогресс: {_value}/{_winningPoints}";
    }
}
