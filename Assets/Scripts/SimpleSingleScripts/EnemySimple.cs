using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimple : MonoBehaviour , IEnemySimple
{

    public int ID;
    #region Iface
    int IEnemySimple.SetPositive_Getnegative_ID(int argid)
    {
        if (argid > 0)
        {
            ID = argid;
        }
        return ID;
    }
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Activeateme(bool argOnOff)
    {

        throw new System.NotImplementedException();
    }
}
