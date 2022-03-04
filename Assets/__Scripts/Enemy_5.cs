using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class part
{
    // These three fields need to be defined in the Inspector pane
    public string name; // The name of this part
    public float health; // The amount of health this part has
    public string[] protectedBy; // The other parts that protect this

    // These two fields are set automatically in Start().
    // Caching like this makes it faster and easier to find these later
    [HideInInspector] // Makes field on the next line not appear in the Inspector
    public GameObject go; // The GameObject of this part
    [HideInInspector]
    public Material mat; // The Material to show damage
}

public class Enemy_5 : Enemy
{
    [Header("Set in Inspector: Enemy_5")]
    public Part[] parts; // The array of ship Parts

    private Vector3 p0, p1; // The two points to interpolate
    private float timeStart; // Birth time for this Enemy_4
    private float duration = 4; // Duration of movement

    // Start is called before the first frame update
    void Start()
    {
        Vector3 heroPos = Hero.S.gameObject.transform.position;

        p0 = p1 = pos;

        InitMovement();

        Transform t;
        foreach (Part prt in parts)
        {
            t = transform.Find(prt.name);
            if (t != null)
            {
                prt.go = t.gameObject;
                prt.mat = prt.go.GetComponent<Renderer>().material;
            }
        }
    }
    //This is the code needed to create the rotation required   
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime * 7);
    }

    void InitMovement()
    {
        p0 = p1; // Set p0 to the old p1
        // Assign a new on-screen location to p1
        float widMinRad = bndCheck.camWidth - bndCheck.radius;
        float hgtMinRad = bndCheck.camHeight - bndCheck.radius;
        // Reset the time
        timeStart = Time.time;
    }

    // This changes the color to white instead of red for the whole ship.
    void ShowDamage()
    {
        foreach (Material m in materials)
        {
            m.color = Color.white;
        }
        showingDamage = true;
        damageDoneTime = Time.time + showDamageDuration;
    }

    void UnShowDamage()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].color = Color.red;
        }
        showingDamage = false;
    }
}
