using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public LayerMask collisionMask;
    float speed = 10;
    float damage = 1;

    float skinWidth = .1f;

    void Start() {
        Destroy(gameObject, 3f);

        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, .1f,collisionMask);
        if(initialCollisions.Length > 0) {
            OnHitObject(initialCollisions[0]);
        }
    }
    
    public void SetSpeed(float newSpeed) {
        speed = newSpeed;
    }

    void Update () {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float moveDistance) {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, moveDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide)){
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit) {
        IDamageble damagebleObject = hit.collider.GetComponent<IDamageble>();
        if(damagebleObject != null) {
            damagebleObject.TakeHit(damage, hit);
        }
        GameObject.Destroy(gameObject);
    }

    void OnHitObject(Collider collider) {
        IDamageble damagebleObject = collider.GetComponent<IDamageble>();
        if(damagebleObject != null) {
            damagebleObject.TakeDamage(damage);
        }
        GameObject.Destroy(gameObject);
    }
}
