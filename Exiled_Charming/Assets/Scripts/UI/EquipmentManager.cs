using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//permet d'attribuer des slot a un equipement defini et de remettre l'ancien équipement dans l'inventaire si un nouvelle équipement (sur le meme slot) voudrait être équipé, list d'image qui permet de récuperer l'image de l'equipement actuellment équipé
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
   public Equipment[] CurrentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public List<Image> images;

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
        EquipeUI(newItem);
    }

    public void EquipeUI(Equipment equipment)
    {
        images[(int)equipment.equipmentSlot].enabled = true;
        images[(int)equipment.equipmentSlot].sprite = equipment.Icon;
    }
}
