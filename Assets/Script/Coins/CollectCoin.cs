using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : ColectBollBase
{
    [SerializeField] private CoinType itens = CoinType.Coin;
    

    protected override void OnCollect()
    {
        base.Collect();
        
        if (itens == CoinType.Coin)
        {
            ManegerItensGamer.Instance.AdsCoin();
        }

        else if (itens == CoinType.Foguete)
        {
            ManegerItensGamer.Instance.Adsfoguete();
        }

    }
}
public enum CoinType
{
    Coin,
    Foguete

}