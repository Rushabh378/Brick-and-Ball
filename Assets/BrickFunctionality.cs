using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BrickFunctionality : MonoBehaviour
{
    private TextMeshPro defText;
    [Range(0, 100)]
    public int defence = 10;
    // Start is called before the first frame update
    void Start()
    {
        defText = GetComponentInChildren<TextMeshPro>();
        defText.text = defence.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
