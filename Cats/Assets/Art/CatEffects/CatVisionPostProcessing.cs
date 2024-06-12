using UnityEngine;

[ExecuteInEditMode]
public class CatVisionPostProcessing : MonoBehaviour
{
    private Material _material;

    void Awake()
    {
        _material = new Material(Shader.Find("Hidden/CatVisionColor"));
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (_material != null)
        {
            Graphics.Blit(src, dest, _material);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
