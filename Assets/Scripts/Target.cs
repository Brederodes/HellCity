using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    [SerializeField] private float current_health;
    

    public float GetHealth()
    {
        return current_health;
    }

    public void TakeDamage(float damage)
    {
        current_health -= damage;
        IsDead();
        Debug.Log(current_health);
        
    }
    
    //Usado para qd tiver curas por exemplo
    public void Heal(float heal)
    {
        current_health += heal;
    }
    public bool IsDead()
    {
        if (current_health <= 0)
        {
            Destroy(gameObject); //Quando for fazer o object pool dos inimigos, desativar inves de destruir
            return true;
        }
        return false;
    }


}
