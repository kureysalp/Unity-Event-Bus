using UnityEngine;


namespace UnityEventBus
{
    public class Player : MonoBehaviour
    {
        private int _health = 100;

        private bool isDead;
        
        private void OnEnable()
        {
            EventBus.Subscribe<TakeDamageEvent>(TakeDamage);
        }
        
        private void OnDisable()
        {
            EventBus.Unsubscribe<TakeDamageEvent>(TakeDamage);
        }
        
        private void TakeDamage(TakeDamageEvent takeDamageEvent)
        {
            if (isDead) return;
            
            var damageAmount = takeDamageEvent.DamageAmount;
            
            _health -= damageAmount;

            Debug.Log($"Player took {damageAmount} damage. New health: {_health}");
            
            if(_health <= 0)
                KillPlayer();
        }

        private void KillPlayer()
        {
            isDead = true;
        }
    }
}