using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] Sections;
    [SerializeField] int zPos = 20;
    [SerializeField] bool creatingSection = false;
    [SerializeField] int sectionNumber;
    bool GameFinished;
    private void Start()
    {
        EventManager.AddListener<OnPlayerCollide>(StopGenerating);
        EventManager.AddListener<OnRestartGame>(StartGenerating);
    }

    private void StartGenerating(OnRestartGame evt)
    {
        GameFinished = false;
    }

    private void StopGenerating(OnPlayerCollide evt)
    {
        GameFinished = true;
    }

    void Update()
    {
        if (!creatingSection && !GameFinished) 
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }
    IEnumerator GenerateSection()
    {
        Instantiate(Sections[sectionNumber], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 20;
        yield return new WaitForSeconds(2f);
        creatingSection = false;
        sectionNumber++;
        if (sectionNumber > Sections.Length - 1)
            sectionNumber = 0;
    }
}
