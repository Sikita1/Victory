using UnityEngine;
using TMPro;

public class MaxScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _recordYoungScene;
    [SerializeField] private TMP_Text _recordAnciendScene;
    [SerializeField] private TMP_Text _recordAbstruseScene;

    private int _recordYoung;
    private int _recordAnciend;
    private int _recordAbstruse;

    private const string _saveKey = "valueSave";

    private void Start()
    {
        Load();

        ShowCurrentRecord(_recordYoungScene, _recordYoung.ToString());
        ShowCurrentRecord(_recordAnciendScene, _recordAnciend.ToString());
        ShowCurrentRecord(_recordAbstruseScene, _recordAbstruse.ToString());
    }

    private void Load()
    {
        var data = SaveManager.Load<SaveData.ScoreController>(_saveKey);

        _recordYoung = data.ScoreYoung;
        _recordAbstruse = data.ScoreAbstruse;
        _recordAnciend = data.ScoreAncient;
    }

    private void ShowCurrentRecord(TMP_Text scene, string scoreText)
    {
        scene.text = $"{scoreText}/100";
    }
}
