﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {

    public string Tag;
    public float offset;

    private Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;

    public float fireRate;
    [SerializeField]
    GameObject _bullet;

    [SerializeField]
    GameObject muzzlePos;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(Tag).GetComponent<Transform>();
        StartCoroutine(FireFunc());
    }

    void LateUpdate()
    {
        targetPos = target.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
        if(transform.rotation.z < 0 )
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    IEnumerator FireFunc()
    {
        if (Vector2.Distance(transform.position, target.position) < 15)
        {
            GameObject obj = Instantiate(_bullet, muzzlePos.transform.position, Quaternion.identity);
            obj.transform.rotation = gameObject.transform.rotation;
        }
        yield return new WaitForSeconds(fireRate);
        StartCoroutine(FireFunc());
    }

}
