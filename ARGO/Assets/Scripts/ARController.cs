using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

#if UNITY_EDITOR
using input = GoogleARCore.InstantPreviewInput;
#endif

public class ARController : MonoBehaviour
{

    private List<DetectedPlane> m_NewTrackedPlanes = new List<DetectedPlane>();
    public GameObject arCamera;
    public GameObject box;
    public GameObject gridPrefab;
    private bool positioned;
    // Start is called before the first frame update
    void Start()
    {
        positioned = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Comprobar el estado de la sesion de ARCore
        if(Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        //Llenamos el m_NewTrackedPlanes con planos que ARCore ha detectado en el fotograma
        Session.GetTrackables<DetectedPlane>(m_NewTrackedPlanes, TrackableQueryFilter.New);

        //Instanciamos una Grid por cada plano detectado
        for(int i = 0; i < m_NewTrackedPlanes.Count; i++)
        {
            GameObject grid = Instantiate(gridPrefab, Vector3.zero, Quaternion.identity, transform);

            //esta funcion iniciara la posicion de la grid i modificara los vertices de la malla
            grid.GetComponent<GridVisualizer>().Initialize(m_NewTrackedPlanes[i]);
        }

        //Comprobamos que el usuario ha tocado la pantalla
        Touch touch;
        if(Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        //Comprobamos si el usuario ha tocado alguno de los planos trackeados
        TrackableHit hit;
        if(Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit) && !positioned)
        {
            //Situamos entonces el objeto encima del plano que hemos tocado

            //Activamos el objeto
            box.SetActive(true);

            //Creamos un Anchor nuevo
            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

            //Seteamos la posicion del objeto para que coincida con el lugar pulsado
            box.transform.position = hit.Pose.position;
            box.transform.rotation = hit.Pose.rotation;

            //Queremos que el objeto mire a la camara
            Vector3 cameraPosition = arCamera.transform.position;

            //El objeto solo debe girar con el eje de las y
            cameraPosition.y = hit.Pose.position.y;

            //Rotamos el objeto para que mie a la camara
            box.transform.LookAt(cameraPosition, box.transform.up);

            //ARCore mantendra actualizados los anchors en relacion a lo que tengamos que añadir
            box.transform.parent = anchor.transform;

            //Set positioned a true (ya ha sido posicionado el objeto)
            positioned = true;

        }
    }
}
