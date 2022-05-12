using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton
    public static EquipmentManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    InventoryManager inventory;
    Equipment[] CurrentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    private void Start()
    {
        inventory = InventoryManager.Instance;
       int NumSlot = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        CurrentEquipment = new Equipment[NumSlot];
    }

    public void Equip(Equipment newItem)
    {
        int Slotindex = (int)newItem.equipmentSlot;

        Equipment oldItem = null;

        if (CurrentEquipment[Slotindex] != null)
        {
            oldItem = CurrentEquipment[Slotindex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        CurrentEquipment[Slotindex] = newItem;
    }
}
