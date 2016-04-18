using UnityEngine;
using System.Collections;

public interface IEnemyState {

    /*IEnumerator*/ void Patrol();

    void Attack();

    void UpdateState();
}

