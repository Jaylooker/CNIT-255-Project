using UnityEngine;
using System.Collections;

public interface IEnemyState {

    void Patrol();

    void Attack();

    void UpdateState();
}

