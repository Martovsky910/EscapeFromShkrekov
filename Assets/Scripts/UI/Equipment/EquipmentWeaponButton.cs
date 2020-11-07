using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentWeaponButton : MonoBehaviour
{
    Image sprite;
    void Awake()
    {
        sprite = GetComponent<Image>();
    }
    public void Initialize(Item item)
    {
        sprite.sprite = item.Template.Sprite;
    }
}
