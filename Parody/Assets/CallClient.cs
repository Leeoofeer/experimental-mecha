using UnityEngine;
using UnityEngine.UI;

public class CallClient : MonoBehaviour
{
    public GameObject head;
    public GameObject torso;

    public Sprite[] headSprites; 
    public Sprite[] torsoSprites; 

   

    public void LlamarCliente()
    {
        RandomizeHead();
        RandomizeTorso();
    }

    void RandomizeHead()
    {
        if (headSprites.Length > 0 && head != null)
        {
            int randomIndex = Random.Range(0, headSprites.Length);

            Image headRenderer = head.GetComponent<Image>();
            if (headRenderer != null)
            {
                headRenderer.sprite = headSprites[randomIndex];
            }
        }
        else
        {
            Debug.LogWarning("No hay sprites de cabeza asignados o falta el GameObject de la cabeza.");
        }
    }

    void RandomizeTorso()
    {
        if (torsoSprites.Length > 0 && torso != null)
        {
            int randomIndex = Random.Range(0, torsoSprites.Length);

            Image torsoRenderer = torso.GetComponent<Image>();
            if (torsoRenderer != null)
            {
                torsoRenderer.sprite = torsoSprites[randomIndex];
            }
        }
        else
        {
            Debug.LogWarning("No hay sprites de torso asignados o falta el GameObject del torso.");
        }
    }

}