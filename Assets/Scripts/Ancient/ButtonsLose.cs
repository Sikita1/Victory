using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using YG;

public class ButtonsLose : MonoBehaviour
{
    //[SerializeField] private PanelTimer _panelTimer;
    //[SerializeField] private Button _button;
    [SerializeField] private Timer _timer;
    //[SerializeField] private LosePanel _losePanel;

    //[SerializeField] private ButtonClick _buttonClick;

    //[SerializeField] private float _adCooldown;

    //private float _nowTime;

    //private void Start()
    //{
    //    _timer.text = _adCooldown.ToString();
    //}

    //private void Update()
    //{
    //    if (_adCooldown > 0)
    //    {
    //        _button.interactable = false;
    //        _panelTimer.gameObject.SetActive(true);
    //        _adCooldown -= Time.unscaledDeltaTime;
    //        _timer.text = Mathf.Round(_adCooldown).ToString();

    //        if (_adCooldown < 0.1f)
    //            _adCooldown = 0f;
    //    }
    //    else
    //    {
    //        _panelTimer.gameObject.SetActive(false);
    //        _button.interactable = true;
    //    }
    //}

    public void OpenMenuClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ContinuePlaying()
    {
        YandexGame.Instance.RewardVideo(0);
        YandexGame.RewardVideoEvent += OnRewarded;
        YandexGame.ErrorVideoEvent += OnRewardFailed;
        //Time.timeScale = 1f;
        //gameObject.SetActive(false);
        //_timer.SetTotalTime();
        //YandexGame.FullscreenShow
    }

    private void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }

    private void OnRewarded(int id)
    {
        if (id != 0)
            return;

        OnRewardFailed();

        Time.timeScale = 1f;

        //if (_adCooldown == 0f)
        //    _adCooldown = 10f;

        //_buttonClick.Winner();
        gameObject.SetActive(false);
        _timer.SetTotalTime();
    }

    private void OnRewardFailed()
    {
        YandexGame.RewardVideoEvent -= OnRewarded;
        YandexGame.ErrorVideoEvent -= OnRewardFailed;
    }

    //private bool CanShowADS => NowTimer() > 0;

    //private float NowTimer() => _nowTime - Time.unscaledTime;
}
