using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseParticleEmitter : MonoBehaviour
{

	[SerializeField] private ParticleSystem collisionParticles = default;
	[SerializeField] private Transform collisionTransform = default;

	public static ReleaseParticleEmitter instance;

	void Awake()
	{
		instance = this;
	}

	public void ParticlesHere(Vector3 position)
	{
		collisionTransform.gameObject.SetActive(true);
		collisionTransform.position = position + new Vector3(0f, 0f, 8f);
		collisionParticles.Emit(5);
	}

}
