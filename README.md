# Generic Unity Event Bus

A simple generic event solution for Unity. Events are generic by creating an IEvent object which can have any properties inside.

## Installation

Through Unity Package Manager with git URL:
```
https://github.com/kureysalp/Unity-Event-Bus.git
```

## Example Usage

**TakeDamageEvent**
```csharp
    public struct TakeDamageEvent : IEvent
    {
        public int DamageAmount;
    }
```

**Enemy**
```csharp
    private void DealDamage()
    {
        EventBus.Raise(new TakeDamageEvent
        {
            DamageAmount = 10
        });
    }
```

**Player**
```csharp
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
            // Kill the player.
    }
```