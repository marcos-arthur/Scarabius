using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Changeable Variables
    private int bulletsInChamber,maxBullets;
    private double health;

    // Mutipliers
    private double moveSpeed,resistance,attackSpeed,bulletsOutput;

    // Active Effects
    private double reflectingTimer, invisibleTimer, shieldedTimer;
    // Start is called before the first frame update
    void Start()
    {
        // Starting Values
        maxBullets = 6;
        bulletsInChamber = 6;
        moveSpeed = 10;
        health = 100;

        // Starting Mutipliers
        resistance = 1;
        attackSpeed = 1;
        bulletsOutput = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Method for applying the detemrined changes depending on used item
    void useItem() 
    {
        if (false) // Max Bullets Buff
        {
            maxBullets++;
        }
        else if (false) // Move Speed Buff
        {
            moveSpeed += 2;
        }
        else if (false) // Max Health Buff
        {
            health += 5;            
        }
        else if (false) // Resistance Buff
        {
            if (resistance >= 0.05) resistance -= 0.05;            
        }
        else if (false) // Attack Speed Buff
        {
            attackSpeed += 0.05;
        }
        else if (false) // Bullets Output Buff
        {
            bulletsOutput++;
        }
        else if (false) // Reflecting Attacks Consumable
        {
            reflectingTimer = 120f;
        }
        else if (false) // Invisibility Consumer
        {
            invisibleTimer = 120f;
        }
        else if (false) // Shield Consumable
        {
            shieldedTimer = 120f;
            if ((resistance - 0.5) >= 0.05) resistance -= 0.5;
            else resistance -= 0.5-(resistance-0.55);
        }                
    }
}
