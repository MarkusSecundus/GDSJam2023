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

    private CopySameNameTransform[] _children_impl;
    private CopySameNameTransform[] _children => _children_impl ??= this.transform.GetComponentsInShallowChildren<CopySameNameTransform>().ToArray();
    void Start()
    {
        _toCopy = NamespaceRoot.Find(this.name);
        if (!_toCopy)
            Destroy(this);

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
            foreach (var ch in current._children) if(ch) queue.Enqueue(ch);
        }
    }

    void doCopyParent()
    {
        if (!_toCopy)
            return;
        this.transform.position = _toCopy.transform.position;
        this.transform.rotation = _toCopy.transform.rotation;
    }
}
