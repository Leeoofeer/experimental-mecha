using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase.Firestore;

public class FirebaseTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        CheckFirebase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método para comprobar si Firebase se ha inicializado correctamente
    void CheckFirebase()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;
                FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
                Debug.Log("Firebase initialized successfully!");
            }
            else
            {
                Debug.LogError($"Failed to initialize Firebase: {task.Exception}");
            }
        });
    }

    public void SendDataButton()
    {
        SendDataToFirestore("Leo", "Compu");
    }

    void SendDataToFirestore(string nombre, string ubicacion)
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        // Document ID del usuario
        string documentId = "leo_device";

        // Data enviada a Firestore
        Dictionary<string, object> data = new Dictionary<string, object>
        {
            {"nombre", nombre},
            { "lugar", ubicacion},
            { "actualizacion", Time.time}
        };

        // Si es el mismo documento, se actualiza, si no, se crea uno nuevo
        db.Collection("usuarios").Document(documentId).SetAsync(data)
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Datos actualizados correctamente en Firestore.");
                }
                else
                {
                    Debug.LogError($"Error al actualizar datos en Firestore: {task.Exception}");
                }
            });
    }

     
}
