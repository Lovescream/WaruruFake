using System;
using UnityEngine;

public class StoreItem {

    #region Properties

    public int Index { get; private set; }
    public bool IsPurchased {
        get => _isPurchased;
        set {
            _isPurchased = value;
            PlayerPrefs.SetInt($"SkinPurchased_{Index}", value ? 1 : 0);
            OnChangedPurchased?.Invoke(value);
        }
    }
    public bool IsEquipped {
        get => _isEquipped;
        set {
            _isEquipped = value;
            PlayerPrefs.SetInt($"SkinEquipped_{Index}", value ? 1 : 0);
            OnChangedEquipped?.Invoke(value);
        }
    }
    public int ItemPrice => 2;

    #endregion

    #region Fields

    private bool _isPurchased;
    private bool _isEquipped;

    public Action<bool> OnChangedPurchased;
    public Action<bool> OnChangedEquipped;

    #endregion


    public StoreItem(int index) {
        this.Index = index;

        this.IsPurchased = index == 0 ? true : PlayerPrefs.GetInt($"SkinPurchased_{index}", 0) == 1;
        this.IsEquipped = PlayerPrefs.GetInt($"SkinEquipped_{index}", 0) == 1;
    }

}