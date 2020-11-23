using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FileReader : MonoBehaviour
{
    [SerializeField] private StatsLogger _stats;
    [SerializeField] private List<GameObject> _strings;

    // Start is called before the first frame update
    void Start()
    {
        _stats.LoadStats();

        _strings[0].GetComponent<TextMeshProUGUI>().text = _stats.TotalTime().ToString() + "s";
        for (int i = 0; i < 4; i++)
        {
            _strings[i + 1].GetComponent<TextMeshProUGUI>().text = _stats.CheckpointTime(i).ToString() + "s"; 
        }
        _strings[5].GetComponent<TextMeshProUGUI>().text = _stats.Attacks().ToString();
        _strings[6].GetComponent<TextMeshProUGUI>().text = _stats.Hits().ToString();
        _strings[7].GetComponent<TextMeshProUGUI>().text = _stats.Accuracy().ToString() + "%";
        _strings[8].GetComponent<TextMeshProUGUI>().text = _stats.Enemies().ToString();
        _strings[9].GetComponent<TextMeshProUGUI>().text = _stats.Jumps().ToString();
        _strings[10].GetComponent<TextMeshProUGUI>().text = _stats.Deaths().ToString();
    }

}
