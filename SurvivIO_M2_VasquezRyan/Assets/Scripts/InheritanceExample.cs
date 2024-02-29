using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritanceExample : MonoBehaviour
{
    //private Item item = new Item();

    // Start is called before the first frame update
    void Start()
    {
        Item item = new Weapon("Sword", 10);

        item.Use();
        //item.x -= 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

public class Item
{
    protected readonly string name;

    public Item(string name) {
        this.name = name;

    }

    public virtual void Use() {
        Debug.Log($"Using {name}");
    }
}

public class Weapon : Item
{
    private readonly int damage;

    public Weapon(string name, int damage) : base(name)
    {
        this.damage = damage;
    }

    public override void Use()
    {
        Debug.Log($"Swinging {name} for {damage}");
    }
}
