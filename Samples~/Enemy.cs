using UnityEngine;

namespace UnityEventBus
{
    public class Enemy : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                EventBus.Raise(new TakeDamageEvent
                {
                    DamageAmount = 10
                });
        }
    }
}