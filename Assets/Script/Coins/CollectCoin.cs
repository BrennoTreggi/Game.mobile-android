using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : ColectBollBase
{
    [SerializeField] private CoinType itens = CoinType.Coin;

    public Collider collider;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;
    private void Start()
    {
       // ManegerItensGamer.Instance.AdsCoin(this);
    }

    protected override void OnCollect()
    {
        base.OnCollect();

        collider.enabled = false;
        collect = true;
       // PlayerController.Instance.Bounce();

        if (itens == CoinType.Coin)
        {
            ManegerItensGamer.Instance.AdsCoin();
        }


    }

    protected override void Collect()
    {
        OnCollect();
    }
    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position,
           PlayerController.Instance.transform.position, lerp * Time.deltaTime);
            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) <minDistance)
            {
                HideItens();
                Destroy(gameObject);
            }
        }
    }
}
public enum CoinType
{
    Coin,
  

}