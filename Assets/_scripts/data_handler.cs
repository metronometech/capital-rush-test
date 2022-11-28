using TMPro;
using UnityEngine;

public class data_handler : MonoBehaviour
{
    [SerializeField] playfab_manager pf_m;
    int gold = 0, stock = 0, silver = 0, crypto = 0;
    public TextMeshProUGUI gold_text, silver_text, crypto_text, stock_text;
    public void UpdateValues(int gold, int silver, int crypto, int stock)
    {
        this.gold = gold;
        this.silver = silver;
        this.crypto = crypto;
        this.stock = stock;

        gold_text.text = gold.ToString();
        silver_text.text = silver.ToString();
        crypto_text.text = crypto.ToString();
        stock_text.text = stock.ToString();
    }
    public void gold_add()
    {
        gold++;
        gold_text.text = gold.ToString();
    }
    public void gold_remove()
    {
        if (gold > 0)
            gold--;
        gold_text.text = gold.ToString();
    }
    public void silver_add()
    {
        silver++;
        silver_text.text = silver.ToString();
    }
    public void silver_remove()
    {
        if (silver > 0)
            silver--;
        silver_text.text = silver.ToString();
    }
    public void stock_add()
    {
        stock++;
        stock_text.text = stock.ToString();
    }
    public void stock_remove()
    {
        if (stock > 0)
            stock--;
        stock_text.text = stock.ToString();
    }
    public void crypto_add()
    {
        crypto++;
        crypto_text.text = crypto.ToString();
    }
    public void crypto_remove()
    {
        if (crypto > 0)
            crypto--;
        crypto_text.text = crypto.ToString();
    }

    public void back_btn()
    {
        pf_m.data_update(gold, silver, crypto, stock);
        crypto_text.text = crypto.ToString();
    }
}
