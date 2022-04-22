using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class distanceToObjective : MonoBehaviour
{
    public GameObject objective;
    public GameObject player;
    private TextMeshProUGUI text;
    private float distance;
    private void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, objective.transform.position);
        text.text = ((int)(distance * 3.3)) + " ft";
    }
}
