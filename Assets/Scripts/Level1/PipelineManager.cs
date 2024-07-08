using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManager : MonoBehaviour
{
    public GameObject pipelineTemp;

    public Transform pipelineBorn;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    Coroutine coroutine = null;
    public void StartRun()
    {
        coroutine = StartCoroutine(GenaratePipelines());
    }
    public void StopRun()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator GenaratePipelines()
    {
        while (true)
        {
            GenaratePipeline();

            yield return new WaitForSeconds(2f);

            
        }
    }
    void GenaratePipeline()
    {
        Instantiate(pipelineTemp, pipelineBorn);
    }
}
