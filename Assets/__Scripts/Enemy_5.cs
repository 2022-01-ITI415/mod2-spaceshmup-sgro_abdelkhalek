using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_5 : Enemy
{
    [Header("Set in Inspector: Enemy_5")]


    private float timeStart; // Birth time for this Enemy_4
    private float duration = 4; // Duration of movement
    private float birthTime;

    // Start is called before the first frame update
    void Start()
    {
        birthTime = Time.time;

        InitMovement();
    }
    //This is the code needed to create the rotation required and gets the position of the hero
    void Update()
    {
        Vector3 heroPos = Hero.S.gameObject.transform.position;

        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, heroPos, step);

        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime * 6);

        if (showingDamage && Time.time > damageDoneTime)
        {
            UnShowDamage();
        }
    }

    void InitMovement()
    {
        // Assign a new on-screen location to p1
        float widMinRad = bndCheck.camWidth - bndCheck.radius;
        float hgtMinRad = bndCheck.camHeight - bndCheck.radius;
        // Reset the time
        timeStart = Time.time;
    }

    // This changes the color to white instead of red for the whole ship when it takes damage
    public override void ShowDamage()
    {
        Debug.Log("showingDamage in Enemy Five");
        foreach (Material m in materials)
        {
            m.color = Color.white;
        }
        showingDamage = true;
        damageDoneTime = Time.time + showDamageDuration;
    }

    public override void UnShowDamage()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].color = Color.red;
        }
        showingDamage = false;
    }
}
