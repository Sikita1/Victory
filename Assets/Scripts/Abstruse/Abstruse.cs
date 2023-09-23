using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Abstruse : ButtonClick
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected override IEnumerator Win()
    {
        _animator.SetBool("True", true);
        yield return base.Win();
        _animator.SetBool("True", false);
    }

    protected override IEnumerator Lose(string notification)
    {
        _animator.SetBool("False", true);
        Notification = $"Никогда не сдавайся!" +
                       $"\nПравильный ответ: {_tasks.GetTrueResponse()}";
        yield return base.Lose(Notification);
        _animator.SetBool("False", false);
    }
}
