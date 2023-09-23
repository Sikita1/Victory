using System.Collections;
using UnityEngine;

public class Ancient : ButtonClick
{
    [SerializeField] private Color _trueColor;
    [SerializeField] private Color _falseColor;

    protected override IEnumerator Win()
    {
        _button.image.color = _trueColor;
        yield return base.Win();
    }

    protected override IEnumerator Lose(string notification)
    {
        _button.image.color = _falseColor;
        Notification = $"Каждая ошибка делает нас сильнее!" +
                       $"\nПравильный ответ: {_tasks.GetTrueResponse()}";
        yield return base.Lose(Notification);
    }
}
