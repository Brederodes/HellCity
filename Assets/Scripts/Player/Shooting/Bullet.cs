using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRb;
    private float damage;
    
    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

   
    private void OnEnable()
    {
        Invoke("Disable", 5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>(); //checa se o objeto que colidiu possui a interface do IDamageable
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }

        Disable();
    }
    private void Disable()
    {
        bulletRb.velocity = Vector3.zero;
        gameObject.SetActive(false);
        
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
