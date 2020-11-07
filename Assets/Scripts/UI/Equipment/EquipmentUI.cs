using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    [SerializeField] GameObject equipmentWeaponButtonPrefab;
    EquipmentWeaponButton weapon;
    public void Initialize()
    {
        ItemsOnPlayer.EquipmentChanged += OnEquipmentChange;
        weapon = Instantiate(equipmentWeaponButtonPrefab, transform).GetComponent<EquipmentWeaponButton>();
        OnEquipmentChange();
    }
    void OnEquipmentChange()
    {
        weapon.Initialize(ItemsOnPlayer.Weapon);
    }
}
