using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Recurse : MonoBehaviour
{
    public BallLerp bl;
    public NodeScript root;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Traverse_1(NodeScript n)  //left then right
    {
        Debug.Log(n);
        if (n.leftChild == null)
        {
            yield break;
        }
        bl.GoLeft();

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(Traverse_1(n.leftChild));

        yield return new WaitForSeconds(1f);

        bl.GoBack();

        yield return new WaitForSeconds(1f);

        if (n.rightChild == null)
        {
            yield break;
        }
        bl.GoRight();

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(Traverse_1(n.rightChild));

        yield return new WaitForSeconds(1f);

        bl.GoBack();
    }

    IEnumerator Traverse_2(NodeScript n)  //right then left
    {
        if (n.rightChild == null)
        {
            yield return null;
        }
        bl.GoRight();

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(Traverse_2(n.rightChild));

        yield return new WaitForSeconds(1f);

        bl.GoBack();

        yield return new WaitForSeconds(1f);

        bl.GoLeft();

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(Traverse_2(n.leftChild));

        yield return new WaitForSeconds(1f);

        bl.GoBack();
    }

    public void OnClick()
    {
        print("onclick");
        if (Inventory.sequence.Equals("TextA TextB "))
        {
            print("mode 1");
            StartCoroutine(Traverse_1(root));
        }
        else if (Inventory.sequence.Equals("TextB TextA "))
        {
            print("mode 2");
            StartCoroutine(Traverse_2(root));
        }
    }
}
