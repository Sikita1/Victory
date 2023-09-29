using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class ButtonClick : MonoBehaviour
{
    [SerializeField] protected TMP_Text _notification;
    [SerializeField] private TMP_Text _currentAnswer;
    [SerializeField] protected AllTasks _tasks;
    [SerializeField] protected Button _button;
    [SerializeField] private LosePanel _lose;
    [SerializeField] private Timer _timer;

    [SerializeField] private Score _score;
    [SerializeField] private PanelWin _panelWin;

    [SerializeField] private AudioClip _right;
    [SerializeField] private AudioClip _wrong;

    public event UnityAction ScoreUp;

    protected string Notification;

    private AudioSource _music;

    private Color _defaultColor;
    private Coroutine _coroutineWin;
    private Coroutine _coroutineLose;

    private void Start()
    {
        _music = GetComponent<AudioSource>();
    }

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
        _music.PlayOneShot(_right);
        yield return new WaitForSeconds(1f);
        _tasks.OrganizeTextIntoQuestions();
        _button.image.color = _defaultColor;
        _timer.SetTotalTime();
        ScoreUp?.Invoke();
        Victory();
        EventSystem.current.SetSelectedGameObject(null);
    }

    protected virtual IEnumerator Lose(string notification)
    {
        _music.PlayOneShot(_wrong);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        _button.image.color = _defaultColor;
        _notification.text = notification;
        _lose.gameObject.SetActive(true);
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
