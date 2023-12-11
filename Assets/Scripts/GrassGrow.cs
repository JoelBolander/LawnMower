using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrassGrow : MonoBehaviour
{
    private int GrowthCount = 0;
    private float growth;

    private GameObject player;
    private PlayerInfo playerInfo;

    public int grass = 0;

    [SerializeField] private Material material1;
    [SerializeField] private Material material2;
    [SerializeField] private Material material3;
    [SerializeField] private Material material4;

    private List<Material> materials = new List<Material>();

    private void Start() {
        materials.Add(material1);
        materials.Add(material2);
        materials.Add(material3);
        materials.Add(material4);
        GetComponent<SpriteRenderer>().material = materials[GrowthCount];

        player = GameObject.FindGameObjectWithTag("Play");
        playerInfo = player.GetComponent<PlayerInfo>();
    }

    private void FixedUpdate()
    {
        if (GrowthCount < 3)
        {
            growth = playerInfo.growth;
            int top = (int)Mathf.Floor(growth);
            int RN = Random.Range(0, top);

            if (RN == 0)
            {
                Debug.Log(top);
                Debug.Log(growth);
            }
            if (RN == 0) {
                GrowthCount++;
                GetComponent<SpriteRenderer>().material = materials[GrowthCount];
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mower") && GrowthCount == 3)
        {
            GrowthCount = 0;
            playerInfo.grass += playerInfo.gain;
            GetComponent<SpriteRenderer>().material = materials[GrowthCount];
        }
    }
}
