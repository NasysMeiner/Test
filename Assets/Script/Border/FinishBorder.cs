using UnityEngine;
using UnityEngine.Events;

public class FinishBorder : MonoBehaviour
{
    public event UnityAction StopTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
            StopTime?.Invoke();
    }
}
