//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.18444
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class SAffector : MonoBehaviour
{
	SParticleEffect pEffect;
	//public Vector3 gravity = new Vector3(0,-1.0f,0);
	
	public SAffector ()
	{

		//Emitter.particles.
	}
	void Start () 
	{
		pEffect = this.GetComponent<SParticleEffect> ();
	}
	void Update () 
	{
		List<SParticle> allParticles = pEffect.particles;

		for (int i = 0; i<allParticles.Count(); i++) 
		{
			SParticle currP = allParticles[i];
			//TODO: 
			//Należy uaktualnić wartości parametrów wszystkich cząsteczek
			//parametry powinny być uaktualniane w zależności od czasu jaki upłynął od ostatniej klatki - Time.deltaTime
			//np pozycja która powinna być uaktualniona zgodnie ze wzorem 
			//position = position + position*deltaTime
			//takie parametry jak kolor czy rozmiar powinny być skalowane w zależności od 
			//wieku cząsteczki np endColor*lifeTime/maxlifeTime
			//takie parametry jak grawitacja czy wiatr powinny być ustalane globalnie i możliwe do edycji w edytorze Unity
			//...
		}

	}

}

