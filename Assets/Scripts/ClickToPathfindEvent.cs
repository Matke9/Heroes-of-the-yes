using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class ClickToPathfindEvent : MonoBehaviour
{
    private Gridd grid;
    private int x1, y1, x2, y2;
    private List<Node> Open, Closed, Path;
    private Node start, current, end, current1;
    [SerializeField]
    private GameObject pathDot;

    void Start()
    {
        grid = GetComponent<GridObject>().grid;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Open != null)
                Open.Clear();
            if (Closed != null)
                Closed.Clear();
            if (Path != null)
                Path.Clear();
            if (grid.GetValue(Mathf.FloorToInt(UtilsClass.GetMouseWorldPosition().x), Mathf.FloorToInt(UtilsClass.GetMouseWorldPosition().y)) != 0)
            {
                end = new Node(Mathf.FloorToInt(UtilsClass.GetMouseWorldPosition().x), Mathf.FloorToInt(UtilsClass.GetMouseWorldPosition().y),
                    Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0, grid); ;
                start = new Node(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y),
                    Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0, grid);
                Open.Add(start);
                current = start;
                while(true) 
                {
                    Open.Sort(delegate(Node n1, Node n2) 
                    {
                        return n1.FCost.CompareTo(n2.FCost);
                    });
                    current = Open[Open.Count - 1];
                    Open.Remove(current);
                    Closed.Add(current);

                    if (current == end) 
                    {
                        break;
                    }

                    foreach (Node a in current.neighbours)
                    {
                        if (!Closed.Contains(a))
                        {
                            if (Open.Find(x => x.xy == a.xy) != null)
                            {
                                Node y = Open.Find(x => x.xy == a.xy);
                                if (a.FCost < y.FCost)
                                {
                                    Open.Remove(y);
                                    Open.Add(a);
                                }
                            }
                            a.parent = current;
                            if (Open.Find(x => x.xy == a.xy) == null)
                            {
                                Open.Add(a);
                            }
                        }
                    }
                }
            }
            current1 = current;
            if(current1.parent != null)
            while (current1.parent != null) 
            {
                Path.Add(current1);
                current1 = current1.parent;
            }
            foreach (Node x in Path) 
            {
                Instantiate(pathDot,new Vector3(x.xy.x,x.xy.y), new Quaternion());
            }
        }
    }
}
