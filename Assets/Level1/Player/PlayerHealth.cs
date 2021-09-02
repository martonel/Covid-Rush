using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image HealthBar;
    public float Health;
    private float MaxHealth;
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = Health / MaxHealth;
    }
    public void SetHealth(int number)
    {
        Health = number;
    }
    public float GetHealth()
    {
        return Health;
    }
    public void GetDamage(int number)
    {
        Health -= number;
    }
    public void PlusHealth(int number)
    {
        Health += number;
        if(Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
    }

}
