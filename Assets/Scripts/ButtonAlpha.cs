using UnityEngine;
using UnityEngine.UI;

public class ButtonAlpha : MonoBehaviour
{
    [Range(0f, 1f)] //1
    public float AlphaLevel = 1f; //2
    private Image _button; //3

    void Start()
    {
        _button = gameObject.GetComponent<Image>();
        _button.alphaHitTestMinimumThreshold = AlphaLevel; //4
    }
}