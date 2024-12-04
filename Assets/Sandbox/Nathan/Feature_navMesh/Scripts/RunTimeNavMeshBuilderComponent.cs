using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
using Meta.XR.MRUtilityKit;

public class RunTimeNavMeshBuilderComponent : MonoBehaviour
{

    private NavMeshSurface _navmeshSurfave;


    // Start is called before the first frame update
    void Start()
    {
        _navmeshSurfave = GetComponent<NavMeshSurface>();
        MRUK.Instance.RegisterSceneLoadedCallback(BuildNavMesh);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildNavMesh()
    {
        _navmeshSurfave.BuildNavMesh();
    }
}
