using ChartAndGraph;
using UnityEngine;

public class pie_manager : MonoBehaviour
{
    public PieChart pichart;
    int gold, silver, crypto, stock;
    [SerializeField] playfab_manager pf_m;


    public void set_data(string gold, string silver, string crypto, string stock)
    {
        this.gold = int.Parse(gold);
        this.silver = int.Parse(silver);
        this.crypto = int.Parse(crypto);
        this.stock = int.Parse(stock);
        update_graph();
    }

    void update_graph()
    {
        Debug.Log("updated");
        pichart.DataSource.SlideValue("gold", gold, 1.5f);
        pichart.DataSource.SlideValue("silver", silver, 1.5f);
        pichart.DataSource.SlideValue("crypto", crypto, 1.5f);
        pichart.DataSource.SlideValue("stock", stock, 1.5f);
    }
}
