using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class AcelerometroT : MonoBehaviour
{
    public float velocidade;
    public TextMeshProUGUI caixaX, caixaY, caixaZ;

   

    // Update is called once per frame
    void Update()
    {
        caixaX.text = Input.acceleration.x.ToString();
        caixaY.text = Input.acceleration.y.ToString();
        caixaZ.text = Input.acceleration.z.ToString();

        Vector3 dir = Vector3.zero;

        // Assumindo que o celular está paralelo ao chão 
        // e oo botão home está a direita 

        // remapeando as coordenadas dos eixos:
        //  1) XY plane of the device is mapped onto XZ plane
        //  2) rotated 90 degrees around Y axis
        dir.x = -Input.acceleration.y;
        dir.z = Input.acceleration.x;

        
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        
        dir.y = 0.1f;
        dir.x = 0;
        dir *= Time.deltaTime;


        
        transform.Translate(dir * velocidade);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cubo")
        {
            SceneManager.LoadScene(0);
        }
    }
}
