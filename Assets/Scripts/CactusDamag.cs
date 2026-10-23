using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _cooldown = 1f;

    private float _lastHitTime = -999f;

    private void OnTriggerStay(Collider other)
    {
        if (Time.time - _lastHitTime < _cooldown) return;

        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
            _lastHitTime = Time.time;
        }
    }
}