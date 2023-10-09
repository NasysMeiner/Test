using UnityEngine;
using UnityEngine.Events;

public class StartBorder : MonoBehaviour
{
    [SerializeField] private GameObject _startText;

    public event UnityAction StartTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            StartTime?.Invoke();
            _startText.SetActive(false);
        }
    }
}
