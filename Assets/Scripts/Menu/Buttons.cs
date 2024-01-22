using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OpenGameYoung() => SceneManager.LoadScene("GameYoung");
    public void OpenGameAbstruse() => SceneManager.LoadScene("GameAbstruse");
    public void OpenGameAncient() => SceneManager.LoadScene("GameAncient");
}

