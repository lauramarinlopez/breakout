using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smove : MonoBehaviour
{
    public Transform tofollow;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = tofollow.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tofollow.position - offset;
    }
}
