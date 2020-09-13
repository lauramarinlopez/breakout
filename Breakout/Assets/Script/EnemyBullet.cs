using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            other.GetComponent<CharacterHealth>().DealDamage(3f);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "walls")
        {
            Destroy(gameObject);
        }
    }

}
