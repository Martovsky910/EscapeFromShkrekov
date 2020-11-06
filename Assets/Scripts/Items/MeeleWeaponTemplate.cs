using UnityEngine;

public class MeeleWeaponTemplate : ItemTemplate
{
    [SerializeField]
    int damage;

    public int Damage => damage;
}
