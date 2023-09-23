using UnityEngine;

public class TimerFrameRotation : MonoBehaviour
{
    [SerializeField] private float _z;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, _z));
    }
}
