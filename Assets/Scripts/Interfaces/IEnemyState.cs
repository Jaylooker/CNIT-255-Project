using UnityEngine;
using System.Collections;

public interface IEnemyState {

    void Patrol();

    void Attack();

    void Dead();

    void UpdateState();
}

