using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBulletSimple : MonoBehaviour, ISpaceBulletSimple
{
  public  float _curSpeed = 5;
    float _OriginalSpeed = 5;
    bool isReadyTogo = false;

    public event Action<bool> yo;
    MeshRenderer _myMesh;
    Transform _refStartPlace;

    void Awake() {

        _myMesh = GetComponentInChildren<MeshRenderer>();
    }
    void Start()
    {
        
    }

     
    void Update()
    {
        transform.position += transform.up * _curSpeed * Time.deltaTime;

        if (transform.position.y >= 7) { RestPlace(); }

    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("BALL hit ");
    //}


    //public void OnCollisionEnter2D(Collision2D coll)
    //{
    //    Debug.Log("bullet hit smth");



    //    if (coll.gameObject.CompareTag("Wall_Limits"))
    //    {

    //        Debug.Log("bullet hit WALL");
    //    }

    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //  // Debug.Log("bullet hit smth");



    //    if (collision.gameObject.CompareTag("Wall_Limits"))
    //    {
    //        RestPlace();

    //       // Debug.Log("bullet hit WALL");
    //    }

    //}

    public void StartMove()
    {
        if (isReadyTogo)
        {
            transform.parent = null;
            _curSpeed = _OriginalSpeed;
            Showme(true);
            isReadyTogo = false;

        }
        // throw new NotImplementedException();
    }

    public void RestPlace()
    {
        _curSpeed = 0;
       // Debug.Log("STOOOOOOOOOOOOOOP");
        transform.position = new Vector3( _refStartPlace.position.x, _refStartPlace.position.y, _refStartPlace.position.z);
        transform.parent = _refStartPlace;
        Showme(false);
        isReadyTogo = true;
        // throw new NotImplementedException();
    }

    public void Showme(bool argOnOff)
    {
        _myMesh.enabled = argOnOff;
      //  throw new NotImplementedException();
    }

    public void SetBselocationTrans(Transform argTrans)
    {
        _refStartPlace = argTrans;
       // throw new NotImplementedException();
    }
}
