using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Script : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask osnova;
    public LayerMask osnovaa;
    public float offsetDistance = 0.5f;
    public GameObject Redcube;
    public GameObject Greencube;
    public GameObject BlueCube;
    public List<GameObject> listt = new List<GameObject>() {};
    private GameObject SelectJbject;
    private GameObject previu;
    private GameObject nextiu;
    private void Start()
    {
        listt = new List<GameObject>() {Redcube,Greencube,BlueCube};
        SelectJbject = Redcube;
        previu = Redcube;
        nextiu = Instantiate(SelectJbject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("S");
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                // Вариант 1: Указываем родителя при создании
                GameObject clone = Instantiate(SelectJbject);
                clone.transform.SetParent(hit.collider.transform);

                Vector3 spawnPosition = hit.point + hit.normal * offsetDistance;
                spawnPosition.x = Mathf.Round(spawnPosition.x * 4f) / 4f;
                spawnPosition.y = Mathf.Round(spawnPosition.y * 4f) / 4f;
                spawnPosition.z = Mathf.Round(spawnPosition.z * 4f) / 4f;

                clone.transform.position = spawnPosition;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 20f, osnova))
            {
                Debug.Log("S");
                Destroy(hit.collider.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectJbject = listt[0];
            previu = listt[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectJbject = listt[1];
            previu = listt[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectJbject = listt[2];
            previu = listt[3];
        }
    }
}