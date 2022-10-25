using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble {
    void TakeHit(float damage, RaycastHit hit);

    void TakeDamage(float damage);
}
