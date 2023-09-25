using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using YG;

public class ButtonsLose : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Pause _pause;

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += OnRewarded;
        YandexGame.ErrorVideoEvent += OnRewardFailed;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= OnRewarded;
        YandexGame.ErrorVideoEvent -= OnRewardFailed;
    }

    public void OpenMenuClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ContinuePlaying()
    {
        //YandexGame.Instance.RewardVideo(0);
        //YandexGame.RewardVideoEvent += OnRewarded;
        //YandexGame.ErrorVideoEvent += OnRewardFailed;
        OpenRewardAd(0);
    }

    private void OpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }

    private void OnRewarded(int id)
    {
        if (id != 0)
            return;

        Time.timeScale = 1f;
        gameObject.SetActive(false);
        _timer.SetTotalTime();
        _pause.gameObject.SetActive(true);
    }

    private void OnRewardFailed()
    {
        //YandexGame.RewardVideoEvent -= OnRewarded;
        //YandexGame.ErrorVideoEvent -= OnRewardFailed;
    }
}
