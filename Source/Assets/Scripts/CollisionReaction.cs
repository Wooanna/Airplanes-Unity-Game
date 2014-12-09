using UnityEngine;
using System.Collections;

public class CollisionReaction : MonoBehaviour
{

    private int damage;
    private int heal;
    private int armor;
    public WoodBoxType type;
    private Material boxMaterial;

    void Start()
    {
        if (type == WoodBoxType.ArmorBox)
        {
            boxMaterial =  Resources.Load("ArmorBoxMaterial", typeof(Material)) as Material;
            this.armor = 1;
        }
        if (type == WoodBoxType.HealBox)
        {
            boxMaterial = Resources.Load("HealBoxMaterial", typeof(Material)) as Material;
            this.heal = 10;
        }
        if (type == WoodBoxType.QuestionBox)
        {
            boxMaterial = Resources.Load("QuestionBoxMaterial", typeof(Material)) as Material;
            this.damage = 20;
        }
        gameObject.renderer.material = boxMaterial;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        ElementStats stats = other.gameObject.GetComponent<ElementStats>();
        if (stats != null)
        {
            if (type == WoodBoxType.ArmorBox)
            {
                stats.RepairArmor(this.armor);
            }
            if (type == WoodBoxType.HealBox)
            {
                stats.Heal(this.heal);
            }
            if (type == WoodBoxType.QuestionBox)
            {
                stats.InflictDamage(this.damage);
            }

            Destroy(gameObject);
        }
    }
}
