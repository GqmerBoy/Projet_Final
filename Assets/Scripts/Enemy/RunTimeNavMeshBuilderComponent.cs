using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
using Meta.XR.MRUtilityKit;

public class RunTimeNavMeshBuilderComponent : MonoBehaviour
{

    private NavMeshSurface _navmeshSurface;

    // Start is called before the first frame update
    void Start()
    {
        _navmeshSurface = GetComponent<NavMeshSurface>();
        MRUK.Instance.RegisterSceneLoadedCallback(BuildNavMesh);
    }

    public void BuildNavMesh()
    {
        _navmeshSurface.BuildNavMesh();
    }
}
