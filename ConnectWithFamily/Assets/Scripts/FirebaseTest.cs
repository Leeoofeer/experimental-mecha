using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase.Firestore;
using System;
using UnityEngine.UI;
using TMPro;

public class FirebaseTest : MonoBehaviour
{
    FirebaseFirestore db = null;
    string documentId = "leo_device";
    string actualizacion;
    string nombre = "Leo";
    string lugar;
    string mood;
    public GameObject[] places; // Array de imagenes de los lugares
    public TextMeshProUGUI lastUpdate, currentMood, place;

    // Start is called before the first frame update
    void Start()
    {
        CheckFirebase();
        Screen.SetResolution(1080, 1920, true);
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
                db = FirebaseFirestore.DefaultInstance;
                Debug.Log("Firebase initialized successfully!");
            }
            else
            {
                Debug.LogError($"Failed to initialize Firebase: {task.Exception}");
            }
        });
    }

    #region Firebase basic methods
    public void StartDataButton() { SendDataToFirestore("Compu", "Ansioso"); }
    void SendDataToFirestore(string ubicacion, string mood)
    {
        // Data enviada a Firestore
        Dictionary<string, object> data = new Dictionary<string, object>
        {
            { "nombre", nombre},
            { "lugar", ubicacion},
            { "mood", mood},
            { "actualizacion", GetCurrentTime()}
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

    public void GetDataFromFirestore()
    {
        DocumentReference docRef = db.Collection("usuarios").Document(documentId);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    // Obtener solo las tres key a usar
                    Dictionary<string, object> data = snapshot.ToDictionary();
                    actualizacion = data.ContainsKey("actualizacion") ? data["actualizacion"].ToString() : "Valor por defecto";
                    nombre = data.ContainsKey("nombre") ? data["nombre"].ToString() : "Valor por defecto";
                    lugar = data.ContainsKey("lugar") ? data["lugar"].ToString() : "Valor por defecto";
                    mood = data.ContainsKey("mood") ? data["mood"].ToString() : "Valor por defecto";

                    Debug.Log($"Actualización: {actualizacion}");
                    Debug.Log($"Nombre: {nombre}");
                    Debug.Log($"Mood: {mood}");
                    Debug.Log($"Lugar: {lugar}");
                    CheckPlace();
                    UpdateText();
                }
                else
                {
                    Debug.LogError("El documento no existe.");
                }
            }
            else
            {
                Debug.LogError($"Error al obtener datos: {task.Exception}");
            }
        });
    }
    #endregion

    #region Firebase send mood method
    public void SendMoodButton(string mood)
    {
        SendMoodToFirestore(mood);
    }
    void SendMoodToFirestore(string mood)
    {
        // Data enviada a Firestore
        Dictionary<string, object> data = new Dictionary<string, object>
        {
            { "mood", mood },
            { "actualizacion", GetCurrentTime() }
        };

        // Si es el mismo documento, se actualiza, si no, se crea uno nuevo
        db.Collection("usuarios").Document(documentId).UpdateAsync(data)
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
    #endregion

    #region Firebase send place method
    public void SendPlaceButton(string place)
    {
        SendPlaceToFirestore(place);
    }

    void SendPlaceToFirestore(string mood)
    {
        // Data enviada a Firestore
        Dictionary<string, object> data = new Dictionary<string, object>
        {
            { "lugar", mood },
            { "actualizacion", GetCurrentTime() }
        };

        // Si es el mismo documento, se actualiza, si no, se crea uno nuevo
        db.Collection("usuarios").Document(documentId).UpdateAsync(data)
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
    #endregion

   

    public static string GetCurrentTime()
    {
        return DateTime.Now.ToString("HH:mm");
    }

    void CheckPlace() 
    {
        GameObject contenedor = null; Image placeImage = null;
        TurnOffPlaces();
        LightUpPlace(contenedor,  placeImage);        
    }

    private void LightUpPlace( GameObject contenedor,  Image placeImage)
    {    
        contenedor = GameObject.Find("Point_" + lugar);
        placeImage = contenedor.GetComponentInChildren<Image>(); placeImage.color = Color.red;
    }

    private void TurnOffPlaces()
    {
        Image placeImage = null;
        foreach (GameObject place in places)
        {
            placeImage = place.GetComponentInChildren<Image>(); placeImage.color = Color.grey;
        }
    }

    public void ConstantUpdate()
    {
        if (IsInvoking("GetDataFromFirestore"))
        {
            CancelInvoke("GetDataFromFirestore");
            Debug.Log("Actualización constante desactivada.");
        }
        else
        {
            InvokeRepeating("GetDataFromFirestore", 0, 5);
            Debug.Log("Actualización constante activada.");
        }
        
    }

    void UpdateText()
    {
        lastUpdate.text = "Último update: " + actualizacion + " Italia";
        currentMood.text = "Ahora me siento..." + mood;
        place.text = "Me encuentro en: " + lugar;
    }


}
