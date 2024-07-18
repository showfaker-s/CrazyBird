using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManager : MonoBehaviour
{
    public GameObject pipelineTemp;

    List<Pipeline> pipelines = new List<Pipeline>();

    public float speed;

    public Transform born;

    //销毁管道列表中的管道
    public void Init()
    {
        for (int i = 0; i < pipelines.Count; i++)
        {
            Destroy(pipelines[i].gameObject);
        }
        pipelines.Clear();
    }

    Coroutine coroutine = null;
    public void StartRun()
    {
        coroutine = StartCoroutine(GenaratePipelines());
    }
    public void StopRun()
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < pipelines.Count; i++)
        {
            //隐藏已经生成的
            pipelines[i].enabled = false;

        }
    }
    IEnumerator GenaratePipelines()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                if (pipelines.Count < 3)
                {
                    GenaratePipeline();
                }
                else
                {
                    //若有管道，则显示出来
                    pipelines[i].enabled = true;
                    //更改管道y值
                    pipelines[i].Init();
                }
                yield return new WaitForSeconds(speed);

            }
        }
    }
    void GenaratePipeline()
    {
        //小于3个才新生成
        if (pipelines.Count < 3)
        {
            GameObject obj = Instantiate(pipelineTemp, born);
            Pipeline p = obj.GetComponent<Pipeline>();
            pipelines.Add(p);
        }
    }
}
