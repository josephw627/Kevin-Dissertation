using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class newObjective : MonoBehaviour
{
    public GameObject nextObjective;
    public TextMeshProUGUI text;
    public distanceToObjective tracker;
    public facePlayer arrow;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player Holder")
        {
            tracker.objective = nextObjective;
            arrow.player = nextObjective.transform;
            text.text = nextObjective.name;
        }
    }

}
