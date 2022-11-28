using ChartAndGraph;
using UnityEngine;

public class pie_manager : MonoBehaviour
{
    public PieChart pichart;
    int gold, silver, crypto, stock;
    [SerializeField] playfab_manager pf_m;


    public void set_data(int gold, int silver, int crypto, int stock)
    {
        this.gold = gold;
        this.silver = silver;
        this.crypto = crypto;
        this.stock = stock;
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
