using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }


    public Sprite deadSprite;
    public GameObject Gun;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 20f;
        // Resets health to full on game load
        CurrentHealth = MaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void DealDamage(float damageValue)
    {
        //Deduct the damage dealt from the character's health
        CurrentHealth -= damageValue;
       
        //If the character is out of health, die!
        if (CurrentHealth <= 0)
            Die();
    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    void Die()
    {
        CurrentHealth = 0;
        FindObjectOfType<GlobalVariables>().enemiesdied++;
        gameObject.GetComponent<Animator>().enabled = false;
        Destroy(Gun);
        //Destroy(gameObject.GetComponentInChildren<SpriteRenderer>());

        Destroy(gameObject.GetComponent<EnemyFollow>());
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;
        Debug.Log("Enemy dead.");
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
