using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Para guardar las imágenes

public class TV : MonoBehaviour
{
    public Material tvMaterial; // Material al que se asignará la textura de la cámara
    private WebCamTexture webcamTexture; // Textura generada por la cámara
    private int captureCounter = 1; // Contador para los nombres de las imágenes
    private string savePath; // Ruta donde se guardarán las imágenes

    void Start()
    {
        // Verificar si hay cámaras disponibles
        if (WebCamTexture.devices.Length > 0)
        {
            // Mostrar el nombre de la cámara en la consola
            Debug.Log("Cámara detectada: " + WebCamTexture.devices[0].name);

            // Inicializar la textura de la cámara
            webcamTexture = new WebCamTexture(WebCamTexture.devices[0].name);
            tvMaterial.mainTexture = webcamTexture; // Asignar la textura al material
            savePath = "/Users/javiersantana/INF 2024:2025/Interfaces Inteligentes/Laboratorio Clase/Mic and Camera Demo"; // Establecer la ruta de guardado
        }
        else
        {
            Debug.LogError("No se detectaron cámaras.");
        }
    }

    void Update()
    {
        // Iniciar la captura de video al presionar la tecla "S"
        if (Input.GetKeyDown(KeyCode.S) && !webcamTexture.isPlaying)
        {
            webcamTexture.Play();
            Debug.Log("Captura de video iniciada.");
        }

        // Pausar la captura de video al presionar la tecla "P"
        if (Input.GetKeyDown(KeyCode.P) && webcamTexture.isPlaying)
        {
            webcamTexture.Pause();
            Debug.Log("Captura de video pausada.");
        }

        // Detener la captura de video al presionar la tecla "X"
        if (Input.GetKeyDown(KeyCode.X))
        {
            webcamTexture.Stop();
            Debug.Log("Captura de video detenida.");
        }

        // Capturar un fotograma al presionar la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            CaptureFrame();
        }
    }

    void CaptureFrame()
    {
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            // Crear una textura 2D del tamaño de la textura de la cámara
            Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.RGB24, false);
            snapshot.SetPixels(webcamTexture.GetPixels());
            snapshot.Apply();

            // Guardar la textura como archivo PNG
            byte[] bytes = snapshot.EncodeToPNG();
            File.WriteAllBytes(Path.Combine(savePath, "Capture_" + captureCounter + ".png"), bytes);
            Debug.Log("Imagen guardada en: " + Path.Combine(savePath, "Capture_" + captureCounter + ".png"));

            captureCounter++; // Incrementar el contador
        }
        else
        {
            Debug.LogWarning("La cámara no está activa. No se puede capturar un fotograma.");
        }
    }
}
