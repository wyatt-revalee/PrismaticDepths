using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI hp;
    public TextMeshProUGUI mana;
    public Animator portraitAnimator;
    public Player player;

    private void Update()
    {
        if(GetInventoryState())
        {
            UpdateStats(player);
            UpdatePlayerPortrait(player);
        }
    }

    public void ActivateInventory()
    {
        this.transform.gameObject.SetActive(!GetInventoryState());
    }

    public bool GetInventoryState()
    {
        return this.transform.gameObject.activeInHierarchy;
    }

    public void UpdatePlayerPortrait(Player player)
    {
        // If player has a weapon, animate portrait with it, otherwise default to weapon-less player animation
        if(player.primaryWeapon != null)
        {
            portraitAnimator.runtimeAnimatorController = player.primaryWeapon.weaponData.animatorOverrideController;
            Debug.Log("Assigning weapon animation.");
        }
        else
        {
            portraitAnimator.runtimeAnimatorController = player.GetComponent<Animator>().runtimeAnimatorController;
        }
    }

    public void UpdateStats(Player player)
    {
        string hpText = string.Format("{0}/{1}", player.currentHealth, player.playerStats.maxHealth.Value);
        hp.text = hpText;

        string manaText = string.Format("{0}/{1}", (int)player.currentMana, player.playerStats.maxMana.Value);
        mana.text = manaText;
    }


}
