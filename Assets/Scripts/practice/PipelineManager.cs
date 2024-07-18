using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManager : MonoBehaviour
{
    public GameObject pipelineTemp;

    List<Pipeline> pipelines = new List<Pipeline>();

    public float speed;

    public Transform born;

    //���ٹܵ��б��еĹܵ�
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
            //�����Ѿ����ɵ�
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
                    //���йܵ�������ʾ����
                    pipelines[i].enabled = true;
                    //���Ĺܵ�yֵ
                    pipelines[i].Init();
                }
                yield return new WaitForSeconds(speed);

            }
        }
    }
    void GenaratePipeline()
    {
        //С��3����������
        if (pipelines.Count < 3)
        {
            GameObject obj = Instantiate(pipelineTemp, born);
            Pipeline p = obj.GetComponent<Pipeline>();
            pipelines.Add(p);
        }
    }
}
