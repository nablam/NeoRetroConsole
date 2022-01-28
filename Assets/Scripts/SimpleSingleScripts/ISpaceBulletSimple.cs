using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public interface ISpaceBulletSimple  
{
    void StartMove();
    void RestPlace();

    void Showme(bool argOnOff);

    void SetBselocationTrans(Transform argTrans);
    event Action<bool> yo;
}
