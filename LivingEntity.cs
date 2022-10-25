using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageble
{
    public float startingHealth;
    protected float health;
    protected bool dead;

    protected virtual void Start() {
        health = startingHealth;
    }
    public void TakeHit(float damage, RaycastHit hit) {
        health -= damage;
        if( health <= 0) {
            Die();
        }
    }

    protected void Die() {
        dead = true;
        GameObject.Destroy(gameObject);
    }
}
