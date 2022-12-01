using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class data
{
    public List<int> gold, stock, silver, crypto;
    public data(List<int> gold, List<int> silver, List<int> crypto, List<int> stock)
    {
        this.gold = gold;
        this.silver = silver;
        this.crypto = crypto;
        this.stock = stock;
    }
}

public class data_handler : MonoBehaviour
{
    [SerializeField] playfab_manager pf_m;
    List<int> gold, stock, silver, crypto;
    public TextMeshProUGUI gold_text, silver_text, crypto_text, stock_text;
    public void UpdateValues(data data_list)
    {
        this.gold = data_list.gold;
        this.silver = data_list.silver;
        this.crypto = data_list.crypto;
        this.stock = data_list.stock;

        gold_text.text = gold[gold.Count - 1].ToString();
        silver_text.text = silver[silver.Count - 1].ToString();
        crypto_text.text = crypto[crypto.Count - 1].ToString();
        stock_text.text = stock[stock.Count - 1].ToString();

        this.gold.Add(gold[gold.Count - 1]);
        this.silver.Add(silver[silver.Count - 1]);
        this.stock.Add(stock[stock.Count - 1]);
        this.crypto.Add(crypto[crypto.Count - 1]);
        Debug.Log("updatedVAlues");
    }
    private void Start()
    {
        gold = new List<int>();
        silver = new List<int>();
        crypto = new List<int>();
        stock = new List<int>();

        Debug.Log(gold);
        if (gold.Count == 0 && silver.Count == 0 && crypto.Count == 0 && stock.Count == 0)
        {
            gold.Add(0);
            silver.Add(0);
            stock.Add(0);
            crypto.Add(0);
        }
        Debug.Log(gold.Count);
    }
    public void gold_add()
    {
        gold[gold.Count - 1]++;
        gold_text.text = gold[gold.Count - 1].ToString();
    }
    public void gold_remove()
    {
        if (gold[gold.Count - 1] > 0)
            gold[gold.Count - 1]--;
        gold_text.text = gold[gold.Count - 1].ToString();
    }
    public void silver_add()
    {
        silver[silver.Count - 1]++;
        silver_text.text = silver[silver.Count - 1].ToString();
    }
    public void silver_remove()
    {
        if (silver[silver.Count - 1] > 0)
            silver[silver.Count - 1]--;
        silver_text.text = silver[silver.Count - 1].ToString();
    }
    public void stock_add()
    {
        stock[stock.Count - 1]++;
        stock_text.text = stock[stock.Count - 1].ToString();
    }
    public void stock_remove()
    {
        if (stock[stock.Count - 1] > 0)
            stock[stock.Count - 1]--;
        stock_text.text = stock[stock.Count - 1].ToString();
    }
    public void crypto_add()
    {
        crypto[crypto.Count - 1]++;
        crypto_text.text = crypto[crypto.Count - 1].ToString();
    }
    public void crypto_remove()
    {
        if (crypto[crypto.Count - 1] > 0)
            crypto[crypto.Count - 1]--;
        crypto_text.text = crypto[crypto.Count - 1].ToString();
    }

    public void back_btn()
    {
        string json_vals = JsonUtility.ToJson(new data(gold,silver,crypto,stock));
        pf_m.data_update(json_vals);

    }
}
