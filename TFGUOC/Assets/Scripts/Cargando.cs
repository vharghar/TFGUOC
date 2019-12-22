using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cargando : MonoBehaviour
{

	
	public string sceneToLoad;
	public Text percentText;
	public Image progressImage;

	// En cuanto se active el objeto, se inciará el cambio de escena
	void Start()
	{
		//Iniciamos una corrutina, en una línea de tiempo diferente al flujo principal del programa
		StartCoroutine(LoadScene());
	}

	//Corrutina
	IEnumerator LoadScene()
	{
		AsyncOperation cargando;


		cargando = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
		
		//Bloqueamos el salto automático entre escenas
		cargando.allowSceneActivation = false;

		//al 90% de carga, se produce el cambio de escena
		while (cargando.progress < 0.9f)
		{

			//Actualizamos el % de carga 
			percentText.text = string.Format("{0}%", cargando.progress * 100);

			//Actualizamos la barra de carga
			progressImage.fillAmount = cargando.progress;

			//Esperamos un frame
			yield return null;
		}

		//Mostramos la carga como finalizada
		percentText.text = "100%";
		progressImage.fillAmount = 1;

		//Activamos el salto de escena.
		cargando.allowSceneActivation = true;


	}
	
}