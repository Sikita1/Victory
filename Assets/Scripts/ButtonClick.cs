using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class ButtonClick : MonoBehaviour
{
    [SerializeField] protected Button _button;
    [SerializeField] protected AllTasks _tasks;
    [SerializeField] protected TMP_Text _notification;

    [SerializeField] private Timer _timer;
    [SerializeField] private Score _score;
    [SerializeField] private LosePanel _lose;
    [SerializeField] private PanelWin _panelWin;
    [SerializeField] private TMP_Text _currentAnswer;

    [SerializeField] private AudioClip _right;
    [SerializeField] private AudioClip _wrong;

    [SerializeField] private AudioSource _music;

    public event UnityAction ScoreUp;

    protected string Notification;

    private Color _defaultColor;
    private Coroutine _coroutineWin;
    private Coroutine _coroutineLose;

    public void Check()
    {
        _defaultColor = _button.image.color;
        _tasks.DeleteCurentTask();

        if (_currentAnswer.text == _tasks.GetTrueResponse())
            Winner();
        else
            _coroutineLose = StartCoroutine(Lose(Notification));
    }

    protected virtual IEnumerator Win()
    {
        _button.interactable = false;
        _music.PlayOneShot(_right);
        yield return new WaitForSeconds(1f);
        _tasks.OrganizeTextIntoQuestions();
        _button.image.color = _defaultColor;
        _timer.SetTotalTime();
        ScoreUp?.Invoke();
        Victory();
        _button.interactable = true;
        EventSystem.current.SetSelectedGameObject(null);
    }

    protected virtual IEnumerator Lose(string notification)
    {
        _button.interactable = false;
        _music.PlayOneShot(_wrong);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        _button.image.color = _defaultColor;
        _notification.text = notification;
        _lose.gameObject.SetActive(true);
        _button.interactable = true;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Winner()
    {
        _coroutineWin = StartCoroutine(Win());
    }

    private void Victory()
    {
        if (_score.IsVictory())
            _panelWin.gameObject.SetActive(true);
    }
}
