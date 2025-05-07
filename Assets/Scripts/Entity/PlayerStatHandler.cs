using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    //[SerializeField] public string? Name { get; protected set; }
    //[SerializeField] public float CurrentHp { get; protected set; }
    //[SerializeField] public float CurrentMp { get; protected set; }
    //[SerializeField] public float CurrentAttackPower { get { return TotalAttackPower; } set { } }
    //[SerializeField] public float CurrentDefensivePower => TotalDefensivePower;
    //[SerializeField] public int Level { get; private set; }
    //[SerializeField] public int Exp { get; private set; }
    //[SerializeField] public int RequiredExp { get; private set; }
    //[SerializeField] public float BasicHp { get; private set; }
    //[SerializeField] public float AdditionalHp { get; private set; }
    //[SerializeField] public float TotalHp => BasicHp + AdditionalHp;
    //[SerializeField] public float BasicAttackPower { get; private set; }
    //[SerializeField] public float AdditionalAttackPower { get; private set; }
    //[SerializeField] public float TotalAttackPower => BasicAttackPower + AdditionalAttackPower;
    //[SerializeField] public float BasicDefensivePower { get; private set; }
    //[SerializeField] public float AdditionalDefensivePower { get; private set; }
    //[SerializeField] public float TotalDefensivePower => BasicDefensivePower + AdditionalDefensivePower;
    //[SerializeField] public int Gold { get; private set; }



    //public Player(string? _inputName)
    //{
    //    Name = _inputName;
    //    Level = 1;
    //    Exp = 0;
    //    RequiredExp = 10;
    //    Gold = 50000;
    //    BasicHp = 100f;
    //    AdditionalHp = 0f;
    //    CurrentHp = TotalHp;
    //    BasicAttackPower = 10f;
    //    AdditionalAttackPower = 0f;
    //    BasicDefensivePower = 5f;
    //    AdditionalDefensivePower = 0f;
    //    //equippedAttackPowerItem = null;
    //    //equippedDefensivePowerItem = null;
    //    //equippedHpItem = null;
    //    //equippedMpItem = null;
    //    //AvailableSkills = new();
    //}

    //public void LevelUp()
    //{
    //    ++Level;
    //    BasicAttackPower += 0.5f;
    //    BasicDefensivePower += 1f;
    //    CurrentHp = TotalHp;
    //}

    //public void UpdateExp(int value)
    //{
    //    if ((value > 0 && Exp > int.MaxValue - value) ||
    //    (value < 0 && Exp < int.MinValue - value))
    //    {
    //        Console.WriteLine("Exp값이 유효하지 않습니다.");
    //        return;
    //    }

    //    Exp += value;

    //    if (Exp < 0)
    //    {
    //        Exp = 0;
    //    }

    //    while (Exp >= RequiredExp)
    //    {
    //        LevelUp();
    //        Exp -= RequiredExp;
    //        RequiredExp += 5 * (Level + 3);
    //    }
    //}
    //public void UpdateGold(int value)
    //{
    //    if ((value > 0 && Gold > int.MaxValue - value) ||
    //    (value < 0 && Gold < int.MinValue - value))
    //    {
    //        Console.WriteLine("Gold값이 유효하지 않습니다.");
    //        return;
    //    }

    //    Gold += value;

    //    if (Gold < 0)
    //    {
    //        Gold = 0;
    //    }
    //}
    //public bool SpendGold(int value)
    //{
    //    if ((value > 0 && Gold > int.MaxValue - value) || (value < 0 && Gold < int.MinValue - value))
    //    {
    //        Console.WriteLine("Gold값이 유효하지 않습니다.");
    //        return false;
    //    }

    //    Gold -= value;

    //    if (Gold < 0)
    //    {
    //        Gold += value;
    //        return false;
    //    }

    //    return true;
    //}
    //public void UpdateBasicHp(float value)
    //{
    //    if ((value > 0.0f && BasicHp > float.MaxValue - value) ||
    //    (value < 0.0f && BasicHp < float.MinValue - value))
    //    {
    //        Console.WriteLine("BasicHp값이 유효하지 않습니다.");
    //        return;
    //    }

    //    BasicHp += value;
    //}
    //public void UpdateAdditionalHp(float value)
    //{
    //    if ((value > 0.0f && AdditionalHp > float.MaxValue - value) ||
    //    (value < 0.0f && AdditionalHp < float.MinValue - value))
    //    {
    //        Console.WriteLine("AdditionalHp값이 유효하지 않습니다.");
    //        return;
    //    }

    //    AdditionalHp += value;
    //}
    //public void Heal(float value)
    //{
    //    if ((value > 0.0f && CurrentHp > float.MaxValue - value) ||
    //    (value < 0.0f && CurrentHp < float.MinValue - value))
    //    {
    //        Console.WriteLine("CurrentHp값이 유효하지 않습니다.");
    //        return;
    //    }

    //    CurrentHp += value;

    //    if (CurrentHp > TotalHp)
    //    {
    //        CurrentHp = TotalHp;
    //    }
    //}

    //public void UpdateBasicAttackPower(float value)
    //{
    //    if ((value > 0.0f && BasicAttackPower > float.MaxValue - value) ||
    //    (value < 0.0f && BasicAttackPower < float.MinValue - value))
    //    {
    //        Console.WriteLine("BasicAttackPower값이 유효하지 않습니다.");
    //        return;
    //    }

    //    BasicAttackPower += value;
    //}
    //public void UpdateAdditionalAttackPower(float value)
    //{
    //    if ((value > 0.0f && AdditionalAttackPower > float.MaxValue - value) ||
    //    (value < 0.0f && AdditionalAttackPower < float.MinValue - value))
    //    {
    //        Console.WriteLine("AdditionalAttackPower값이 유효하지 않습니다.");
    //        return;
    //    }

    //    AdditionalAttackPower += value;
    //}
    ////public void UpdateCurrentAttackPower(float value)
    ////{
    ////    if ((value > 0.0f && CurrentAttackPower > float.MaxValue - value) ||
    ////    (value < 0.0f && CurrentAttackPower < float.MinValue - value))
    ////    {
    ////        Console.WriteLine("CurrentAttackPower값이 유효하지 않습니다.");
    ////        return;
    ////    }

    ////    CurrentAttackPower += value;
    ////} 버프스킬용
    //public void UpdateBasicDefensivePower(float value)
    //{
    //    if ((value > 0.0f && BasicDefensivePower > float.MaxValue - value) ||
    //    (value < 0.0f && BasicDefensivePower < float.MinValue - value))
    //    {
    //        Console.WriteLine("BasicDefensivePower값이 유효하지 않습니다.");
    //        return;
    //    }

    //    BasicDefensivePower += value;
    //}
    //public void UpdateAdditionalDefensivePower(float value)
    //{
    //    if ((value > 0.0f && AdditionalDefensivePower > float.MaxValue - value) ||
    //    (value < 0.0f && AdditionalDefensivePower < float.MinValue - value))
    //    {
    //        Console.WriteLine("AdditionalDefensivePower값이 유효하지 않습니다.");
    //        return;
    //    }

    //    AdditionalDefensivePower += value;
    //}
    ////public void UpdateCurrentDefensivePower(float value)
    ////{
    ////    if ((value > 0.0f && CurrentDefensivePower > float.MaxValue - value) ||
    ////    (value < 0.0f && CurrentDefensivePower < float.MinValue - value))
    ////    {
    ////        Console.WriteLine("CurrentDefensivePower값이 유효하지 않습니다.");
    ////        return;
    ////    }

    ////    float tempBuffedAttack = CurrentAttackPower * 1.2f;
    ////} 버프스킬용

    ////public void OnWeapon(EquipmentItem equipmentItem)
    ////{
    ////    if (this.equippedAttackPowerItem != null)
    ////    {
    ////        OffWeapon(this.equippedAttackPowerItem);
    ////    }
    ////    this.equippedAttackPowerItem = equipmentItem;
    ////    this.AdditionalAttackPower += equipmentItem.ItemAbility;
    ////}
    ////public void OnArmor(EquipmentItem equipmentItem)
    ////{
    ////    if (this.equippedDefensivePowerItem != null)
    ////    {
    ////        OffWeapon(this.equippedDefensivePowerItem);
    ////    }
    ////    this.equippedDefensivePowerItem = equipmentItem;
    ////    this.AdditionalDefensivePower += equipmentItem.ItemAbility;
    ////}
    ////public void OffWeapon(EquipmentItem equipmentItem)
    ////{
    ////    this.equippedAttackPowerItem = null;
    ////    this.AdditionalAttackPower -= equipmentItem.ItemAbility;
    ////}
    ////public void OffArmor(EquipmentItem equipmentItem)
    ////{
    ////    this.equippedDefensivePowerItem = null;
    ////    this.AdditionalDefensivePower -= equipmentItem.ItemAbility;
    ////}
    ////public void SetEquippedAttackPowerItem(EquipmentItem item)
    ////{
    ////    equippedAttackPowerItem = item;
    ////}
    ////public void SetEquippedDefensivePowerItem(EquipmentItem item)
    ////{
    ////    equippedDefensivePowerItem = item;
    ////}}
}
