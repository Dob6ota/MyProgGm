using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image _redBar;
    [SerializeField] private Health _health;

    private RectTransform _redRect;

    private void Awake()
    {
        _redRect = _redBar.rectTransform;
    }

    private void OnEnable()
    {
        if (_health != null)
            _health.OnHealthChanged += UpdateBar;
    }

    private void OnDisable()
    {
        if (_health != null)
            _health.OnHealthChanged -= UpdateBar;
    }

    private void UpdateBar(float current, float max)
    {
        if (max <= 0) return;
        float percent = Mathf.Clamp01(current / max);

        Vector2 anchorMax = _redRect.anchorMax;
        anchorMax.x = percent;
        _redRect.anchorMax = anchorMax;
    }
}