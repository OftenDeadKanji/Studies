using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class HeroController : MonoBehaviour, IInteractive
{
	[SerializeField]
	GameObject distance;

	PlayerController owner;
	public PlayerController Owner
	{
		get { return owner; }
		set { owner = value; }
    }
	[SerializeField]
	Hero.PredefinedHero predefined;
	public Hero.PredefinedHero Predefined
    {
		get { return predefined; }
		set { predefined = value; }
    }

	[SerializeField]
    Hero hero = null;
	public Hero Hero
    {
		get { return hero; }
		set { hero = value; }
    }

    [SerializeField]
	bool isMainHero;
	public bool IsMainHero
    {
		get { return isMainHero; }
		set { isMainHero = value; }
    }

	GameManager gameManager;
	GameObject interactArea;

	NavMeshAgent navMeshAgent;
	[SerializeField]
	LineRenderer yesPathRenderer;
	[SerializeField]
	LineRenderer noPathRenderer;

	bool isGoing = false;
	public bool IsGoing
    {
		get { return isGoing; }
		set { isGoing = value; }
    }

	public void Interact(HeroController whoInteracted)
	{
		Debug.Log("Hero interaction!");

		if (this.Owner == whoInteracted.Owner)
		{

		}
		else
		{
			gameManager.StartFight(whoInteracted, this, null);
		}
	}

	public void Die()
    {
		if(this.isMainHero)
        {
			List<CityManager> playerCities = new List<CityManager>();

			var cities = GameObject.FindGameObjectsWithTag("City");
			foreach(var city in cities)
            {
				var cityManager = city.GetComponent<CityManager>();
				if(cityManager != null)
                {
					if(cityManager.City.Owner == this.Owner.Player)
                    {
						playerCities.Add(cityManager);
                    }
                }
            }

			if(playerCities.Count > 0)
            {
				var nearestCity =
					playerCities
					.OrderBy(city => Vector3.Distance(city.gameObject.transform.position, gameObject.transform.position))
					.FirstOrDefault();

				var cityPos = nearestCity.CityRespawnPoint.transform.position;
				gameObject.transform.position = new Vector3(cityPos.x, gameObject.transform.position.y, cityPos.z);

				navMeshAgent.destination = gameObject.transform.position;
				prevPos = gameObject.transform.position;
            }
			else
            {
				owner.Player.Heroes.Remove(hero);
				if(owner.Player.Heroes.Count == 0)
                {
					owner.Die();
                }
				else
                {
					Destroy(gameObject);
                }
            }
        }
		else
        {
			Destroy(gameObject);
		}
    }

	private void Awake()
	{
		var gameManagerObject = GameObject.Find("GameManager");
		if (gameManagerObject == null)
		{
			throw new Exception("Game manger game object not found!");
		}

		gameManager = gameManagerObject.GetComponent<GameManager>();
		if (gameManager == null)
		{
			throw new Exception("GameManger object not found!");
		}
		var interactAreaTransform = transform.Find("InteractArea");
		if (interactAreaTransform != null)
		{
			interactArea = interactAreaTransform.gameObject;
		}
		else
		{
			Debug.Log("interactArea object not found!");
		}

		hero = Hero.CreatePredefinedHero(predefined);

		prevPos = transform.position;

		navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
	}

	private void OnMouseDown()
	{
		gameManager.SetMainPlayerDirection(interactArea.transform.position, interactArea);
	}

	public float distanceThisTurn = 0.0f;
	Vector3 prevPos;

	void Update()
    {
		if (predefined != Hero.PredefinedHero.Empty)
		{
			distance.transform.rotation = gameManager.MainCamera.transform.rotation;

			UpdateOnPath();

			if (distanceThisTurn >= hero.HeroStats.MaxDistancePerTurn || isGoing == false)
			{
				transform.position = prevPos;
				isGoing = false;
			}
			else
			{
				Vector3 pos = transform.position;
				distanceThisTurn += Vector3.Distance(prevPos, pos);
				prevPos = pos;
			}
			float left = 0.0f;
			
			if (hero.HeroStats.MaxDistancePerTurn > 0)
			{
				left = (hero.HeroStats.MaxDistancePerTurn - distanceThisTurn) / hero.HeroStats.MaxDistancePerTurn * 100.0f;
			}

			left = left < 0.0f ? 0.0f : left;
			
			distance.transform.localScale = new Vector3(left, distance.transform.localScale.y, distance.transform.localScale.z);
		}
	}

	void UpdateOnPath()
    {
		yesPathRenderer.positionCount = 0;
		noPathRenderer.positionCount = 0;

		if(Vector3.Distance(navMeshAgent.destination, transform.position) > navMeshAgent.stoppingDistance)
        {
			if (navMeshAgent.hasPath)
			{
				var path = navMeshAgent.path;

				if(path.corners.Length < 2)
                {
					return;
                }
				
				float distanceLeft = hero.HeroStats.MaxDistancePerTurn - distanceThisTurn;
				
				List<Vector3> yes = new List<Vector3>();
				List<Vector3> no = new List<Vector3>();

				yes.Add(path.corners[0]);

				bool isStillYes = true;
				for (int i = 1; i < path.corners.Length; i++)
                {
					if (isStillYes)
					{
						Vector3 prevPointPos = new Vector3(path.corners[i - 1].x, path.corners[i - 1].y, path.corners[i - 1].z);
						Vector3 nextPointPos = new Vector3(path.corners[i].x, path.corners[i].y, path.corners[i].z);

						Vector3 vec = nextPointPos - prevPointPos;
						if (vec.magnitude < distanceLeft)
						{
							distanceLeft -= vec.magnitude;
							yes.Add(path.corners[i]);
						}
						else
						{
							Vector3 firstPart = vec.normalized * distanceLeft;
							Vector3 secondPart = vec - firstPart;

							yes.Add(firstPart + prevPointPos);

							no.Add(firstPart + prevPointPos);
							no.Add(nextPointPos);

							isStillYes = false;
						}
					}
					else
                    {
						no.Add(path.corners[i]);
					}
				}

				yesPathRenderer.positionCount = yes.Count;
				for(int i = 0; i < yes.Count; i++)
                {
					yesPathRenderer.SetPosition(i, yes[i]);
                }

				noPathRenderer.positionCount = no.Count;
				for (int i = 0; i < no.Count; i++)
				{
					noPathRenderer.SetPosition(i, no[i]);
				}
			}
        }
    }

	public void SetDestination(Vector3 dest)
    {
		navMeshAgent.SetDestination(dest);
    }
}
