using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ScrollMaterial : MonoBehaviour
{

    public Material ScrollingMaterial;
    private float Xcord, Ycord;
    [Range(-1, 1)]
    [SerializeField] private float ScollRateX, ScollRateY;

    [HideInInspector] public int TextureIndex = 0;
    [HideInInspector] public string[] TextureTypes = new string[] { "_MainTex", "_MainTex1" };

    public Texture ScrollTex;
    public Color TextureColor = new Color(1,1,1,1);
        
    void Start()
    {
       GetComponent<MeshRenderer>().sharedMaterial = (ScrollingMaterial);
    }

    private void OnRenderObject()
    {

        GetComponent<MeshRenderer>().material.SetTexture(TextureTypes[TextureIndex],ScrollTex);
        GetComponent<MeshRenderer>().material.SetColor("_Color",TextureColor);

        Xcord += ScollRateX * Time.deltaTime;
        Ycord += ScollRateY * Time.deltaTime;

        //ScrollingMaterial.SetTextureOffset(TextureTypes[TextureIndex], new Vector2(Xcord, Ycord));
        GetComponent<MeshRenderer>().material.SetTextureOffset(TextureTypes[TextureIndex], new Vector2(Xcord, Ycord));
    }
}
