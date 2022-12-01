using ChartAndGraph;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class pie_manager : MonoBehaviour
{
    public PieChart pichart;
    [SerializeField] GraphChart graph;
    List<int> gold, silver, crypto, stock;
    [SerializeField] playfab_manager pf_m;
    [SerializeField] Button LineChartBtn;

    public void set_data(List<int> gold, List<int> silver, List<int> crypto, List<int> stock)
    {
        this.gold = gold;
        this.silver = silver;
        this.crypto = crypto;
        this.stock = stock;

        update_graph();

        
        //if (gold.Count < 5)
        //    LineChartBtn.interactable = false;
        //else
        //    LineChartBtn.interactable = true;

        UpdateLine("gold",gold);
        UpdateLine("silver", silver);
        UpdateLine("crypto", crypto);
        UpdateLine("stock", stock);
    }

    void UpdateLine(string category,List<int> item)
    {
        graph.DataSource.ClearCategory(category);
        for(int i =0; i < item.Count; i++)
        {
            graph.DataSource.AddPointToCategory(category, i, item[i]);
        }

    }

    void update_graph()
    {
        Debug.Log("updated");
        pichart.DataSource.SlideValue("gold", gold[gold.Count-1], 1.5f);
        pichart.DataSource.SlideValue("silver", silver[silver.Count - 1], 1.5f);
        pichart.DataSource.SlideValue("crypto", crypto[crypto.Count - 1], 1.5f);
        pichart.DataSource.SlideValue("stock", stock[stock.Count - 1], 1.5f);
    }
}
