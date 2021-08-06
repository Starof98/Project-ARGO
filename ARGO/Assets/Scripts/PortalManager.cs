using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;
public class PortalManager : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Edificio;
    private Material[] EdiMaterials;

    // Start is called before the first frame update
    void Start()
    {
        EdiMaterials = Edificio.GetComponent<Renderer>().sharedMaterials;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);
        //Identifica is la cam esta dins o fora del edifici
        if(camPositionInPortalSpace.y < 0.5f)
        {
            //Desactiva stencil test
            for(int i = 0; i < EdiMaterials.Length; ++i)
            {
                EdiMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
        }
        else
        {
            //Activa stencil test
            for (int i = 0; i < EdiMaterials.Length; ++i)
            {
                EdiMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
        }
    }
}
