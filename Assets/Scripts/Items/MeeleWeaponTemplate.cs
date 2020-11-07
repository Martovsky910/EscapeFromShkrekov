using UnityEngine;
[CreateAssetMenu(fileName = "new Meele weapon", menuName = "Meele weapon")]
public class MeeleWeaponTemplate : ItemTemplate
{
    [SerializeField]
    int damage;
    [SerializeField]
    float attackRange;
    public int Damage => damage;
    public float AttackRange => attackRange;
    public override Item CreateInstance()
    {
        return new MeeleWeapon(this);
    }
}
