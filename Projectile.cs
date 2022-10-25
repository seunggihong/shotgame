using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask collisionMask;
    float speed = 10;
    float damage = 1;
    
    public void SetSpeed(float newSpeed) {
        speed = newSpeed;
    }

    void Update () {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);

        Destroy(this.gameObject, 3f);
    }

    void CheckCollisions(float moveDistance) {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide)){
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
}
