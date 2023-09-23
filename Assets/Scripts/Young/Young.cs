using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Young : ButtonClick
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
        Notification = $"Упс, не правильно!" +
                       $"\nПравильный ответ: {_tasks.GetTrueResponse()}";
         yield return base.Lose(Notification);
    }
}
