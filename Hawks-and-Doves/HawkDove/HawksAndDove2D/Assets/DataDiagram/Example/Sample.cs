using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour {

    List<GameObject> lineList = new List<GameObject>();

    private DD_DataDiagram m_DataDiagram;
    //private RectTransform DDrect;

    private bool m_IsContinueInput = false;
    private float m_Input = 0f;
    private float h = 0;

    void AddALine() {

        if (null == m_DataDiagram)
            return;

        Color color = Color.HSVToRGB((h += 0.1f) > 1 ? (h - 1) : h, 0.8f, 0.8f);
        GameObject line = m_DataDiagram.AddLine(color.ToString(), color);
        if (null != line)
            lineList.Add(line);
    }

    // Use this for initialization
    void Start () {

        GameObject dd = GameObject.Find("DataDiagram");
        if(null == dd) {
            //Debug.LogWarning("can not find a gameobject of DataDiagram");
            return;
        }
        m_DataDiagram = dd.GetComponent<DD_DataDiagram>();

        m_DataDiagram.PreDestroyLineEvent += (s, e) => { lineList.Remove(e.line); };

        for(int i=0; i<3; i++){
            AddALine();
        }
    }

    // Update is called once per frame
    void Update () {

    }

    private void FixedUpdate() {

        m_Input += Time.deltaTime;
        ContinueInput(m_Input);
    }

    private void ContinueInput(float f) {
        if (null == m_DataDiagram)
            return;

        if (false == m_IsContinueInput)
            return;

        DataSource data = DataSource.getSingletonInstance();

        int maxVal = System.Math.Max(data.getNumberOfDoves(), System.Math.Max(data.getNumberOfHawks(), data.getNumberOfFood()));
        float[] graphsPoints = getScaledValues(maxVal, data.getNumberOfDoves(), data.getNumberOfHawks(), data.getNumberOfFood());
        int index = 0;
        float pointVal = 0f;
//        Debug.Log("asdnfkjdgnkddgf");
//        Debug.Log(graphsPoints[0]);
//        Debug.Log(graphsPoints[1]);
//        Debug.Log(graphsPoints[2]);
        foreach (GameObject l in lineList)
        {
            pointVal += graphsPoints[index];
            //Debug.Log("Graph Points:" + pointVal);
            m_DataDiagram.InputPoint(l, new Vector2(0.1f, (Mathf.Sin(f + pointVal) + 1f) * 2f));
            index++;
        }
    }

    private float[] getScaledValues(int max, int hawks, int dove, int food)
    {
        float[] graphsPoints = new float[3];
        float check = 7f;
        while(max > check)
        {
            check *= 10;
        }
        graphsPoints[0] = hawks / check;
        graphsPoints[1] = dove / check;
        graphsPoints[2] = food / check;
 /*       Debug.Log("asdasda");
        Debug.Log(check);
        Debug.Log(hawks);
        
        Debug.Log(graphsPoints[0]);
        Debug.Log(graphsPoints[1]);
        Debug.Log(graphsPoints[2]);
        Debug.Log("asdasda");
        Debug.Log(graphsPoints);
*/
        return graphsPoints;
    }

    public void onButton() {

        if (null == m_DataDiagram)
            return;

        foreach (GameObject l in lineList) {
            m_DataDiagram.InputPoint(l, new Vector2(1, Random.value * 4f));
        }
    }

    public void OnAddLine() {
        AddALine();
    }

    public void OnRectChange() {

        if (null == m_DataDiagram)
            return;

        Rect rect = new Rect(Random.value * Screen.width, Random.value * Screen.height,
            Random.value * Screen.width / 2, Random.value * Screen.height / 2);

        m_DataDiagram.rect = rect;
    }

    public void OnContinueInput() {

        m_IsContinueInput = !m_IsContinueInput;

    }

}
