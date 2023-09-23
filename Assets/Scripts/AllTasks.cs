using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllTasks : MonoBehaviour
{
    [SerializeField] private TextAsset _tasksFile;
    [SerializeField] private TMP_Text _questionText;

    [SerializeField] private List<TMP_Text> _response;

    private string[] _tasksArray;
    private List<string> _tasksList;
    private string _currentTask;
    private string[] _split;
    private string _trueResponse;
    private string[] _responsesArray;

    private int _answerOptions = 4;

    private void Start()
    {
        _tasksList = new List<string>();
        FillListTasks();
        OrganizeTextIntoQuestions();
    }

    public string GetTrueResponse() => _trueResponse;

    public List<string> DeleteCurentTask()
    {
        _tasksList.Remove(_currentTask);
        return _tasksList;
    }

    public void OrganizeTextIntoQuestions()
    {
        int randomLine = Random.Range(0, _tasksList.Count);
        _currentTask = _tasksList[randomLine];
        _split = _currentTask.Split('/');
        _responsesArray = _split[1].Split(';');

        _questionText.text = _split[0];
        _trueResponse = _responsesArray[0];

        RandomResponses(Shaffle(_responsesArray));
    }

    private void FillListTasks()
    {
        _tasksArray = _tasksFile.text.Split("\n");

        for (int i = 0; i < _tasksArray.Length; i++)
            _tasksList.Add(_tasksArray[i]);
    }

    private void RandomResponses(string[] responses)
    {
        for (int i = 0; i < _answerOptions; i++)
            _response[i].text = responses[i];
    }

    private string[] Shaffle(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            string current = array[i];
            int randomIndex = Random.Range(0, array.Length);
            array[i] = array[randomIndex];
            array[randomIndex] = current;
        }

        return array;
    }
}
