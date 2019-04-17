using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHandler : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    [SerializeField]
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (meshRenderer == null)
        {
            meshRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>();

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            ChangeMat(5);
            Debug.Log(materials[5]);
            Debug.Log("Change Colour");
        }
    }

    public void ChangeMat(int index)
    {
        if (index >= materials.Count)
        {
            return;
        }

        MaterialPropertyBlock props = new MaterialPropertyBlock();
        props.SetColor("_Color", materials[index].color);
        meshRenderer.GetComponent<Renderer>().SetPropertyBlock(props);
    }
}
