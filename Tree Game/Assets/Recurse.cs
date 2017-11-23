using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recurse : MonoBehaviour
{
    public BallLerp bl;
    public NodeScript root;
    public Text current;

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
        UpdateCurrent(n);

        yield return new WaitForSeconds(.5f);

        if (n.leftChild == null)
        {
            yield break;
        }
        bl.GoLeft();

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(Traverse_1(n.leftChild));

        UpdateCurrent(n);

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


        UpdateCurrent(n);

        bl.GoBack();
    }

    IEnumerator Traverse_2(NodeScript n)  //right then left
    {
        UpdateCurrent(n);

        yield return new WaitForSeconds(.5f);

        if (n.rightChild == null)
        {
            yield break;
        }
        bl.GoRight();

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(Traverse_2(n.rightChild));

        UpdateCurrent(n);

        yield return new WaitForSeconds(1f);

        bl.GoBack();

        yield return new WaitForSeconds(1f);

        if (n.leftChild == null)
        {
            yield break;
        }

        bl.GoLeft();

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(Traverse_2(n.leftChild));

        UpdateCurrent(n);

        bl.GoBack();
    }

    public void UpdateCurrent(NodeScript n)
    {
        current.text = "Current Node: " + n.gameObject.name;
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
