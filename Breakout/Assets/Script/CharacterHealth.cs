using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public Slider healthbar;
    public GameObject gameOverPanel;

    [SerializeField]
    GameObject controlfreake;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        MaxHealth = 20f;
        // Resets health to full on game load
        CurrentHealth = MaxHealth;

        healthbar.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.X))
            DealDamage(6);
    }

    public void DealDamage(float damageValue)
    {
        //Deduct the damage dealt from the character's health
        CurrentHealth -= damageValue;
        healthbar.value = CalculateHealth();
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
        GameObject.Find("ouch").GetComponent<AudioSource>().Play();
        controlfreake.SetActive(false);
        CurrentHealth = 0;
        Debug.Log("You're dead.");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
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
