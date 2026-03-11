using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MerchantMenu : MonoBehaviour
{
    public MerchantInventory currentMerchant;

    [SerializeField] private InventoryItemHolder playeritems;
    public InventoryItemHolder merchantItems;

    [SerializeField] private TextMeshProUGUI playerMoney;


    //singleton reference stuff but parent is dontdestroyonload so dont have that part for this script
    public static MerchantMenu Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        Invoke(nameof(UpdateInventoryHolders), 0.6f);
    }

    private void OnEnable()
    {
        UpdateInventoryHolders();
    }

    public void SetMerchant(MerchantInventory newMerchant)
    {
        currentMerchant = newMerchant;
        UpdateInventoryHolders();
    }

    public void UpdateInventoryHolders()
    {
        playeritems.UpdateItems(Player.Instance.inventory.items);
        merchantItems.UpdateItems(currentMerchant.items);

        playerMoney.text = StatManager.Instance.money.ToString();
    }
}
