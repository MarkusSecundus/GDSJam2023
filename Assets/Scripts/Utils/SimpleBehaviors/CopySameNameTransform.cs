using MarkusSecundus.PhysicsSwordfight.Utils.Extensions;
using MarkusSecundus.Utils.Datastructs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CopySameNameTransform : MonoBehaviour
{
    [SerializeField] Transform NamespaceRoot;


    public Transform _toCopy;

    private CopySameNameTransform[] _children;
    void Start()
    {
        _toCopy = NamespaceRoot.Find(this.name);
        if (!_toCopy)
        {
            Debug.Log($"Destroying self: {this.name}", gameObject);
            Destroy(this);
        }
        //_children = this.transform.GetComponentsInShallowChildren<CopySameNameTransform>().ToArray();

        if (!transform.parent.GetComponent<CopySameNameTransform>())
        {
            this.PerformCyclically(copyBfs, new WaitForFixedUpdate());
        }
    }

    void copyBfs()
    {
        var queue = new Queue<CopySameNameTransform>();
        queue.Enqueue(this);
        while (!queue.IsEmpty())
        {
            var current = queue.Dequeue();
            current.doCopyParent();
            foreach (var ch in current.transform.GetComponentsInShallowChildren<CopySameNameTransform>()) if(ch) queue.Enqueue(ch);
        }
    }

    void doCopyParent()
    {
        if (!_toCopy)
        {
            Debug.LogWarning($"Nothing to copy! {this.name}", this);
            return;
        }
        this.transform.position = _toCopy.transform.position;
        this.transform.rotation = _toCopy.transform.rotation;
    }
}
