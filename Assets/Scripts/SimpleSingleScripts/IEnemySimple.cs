using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemySimple 
{
 
    void Attack();

    void Move(); 
    void Die();

    int SetPositive_Getnegative_ID(int argid);

    void Activeateme(bool argOnOff);

}
