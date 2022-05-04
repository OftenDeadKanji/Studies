using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> players;
    public List<GameObject> Players
    {
        get { return players; }
    }
    
    PlayerController _mainPlayer;
    public PlayerController MainPlayer
    {
        get { return _mainPlayer; }
    }

    GameObject destinationGameObject;
    
    [SerializeField]
    Camera mainCamera;
    public Camera MainCamera
    {
        get { return mainCamera; }
    }

    [Header("GUI")]
    [SerializeField]
    GameObject explorationGUI;
    [SerializeField]
    Image selectedHeroSprite; 
    [SerializeField]
    TMPro.TMP_Text goldValue;
    [SerializeField]
    TMPro.TMP_Text woodValue;
    [SerializeField]
    TMPro.TMP_Text stoneValue;

    public enum Day
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
    }

    Day day;
    [SerializeField]
    TMPro.TMP_Text dayText;

    void Start()
    {
        InitializePlayers();

        if (goldValue == null || woodValue == null || stoneValue == null)
        {
            throw new System.Exception("At least one of GUI elements is null!");
        }

        if (mainCamera == null)
        {
            throw new System.Exception("mainCammera object is null!");
        }

        day = Day.Monday;
        dayText.text = day.ToString();
    }

    void InitializePlayers()
    {
        players = new List<GameObject>();


        var _players = GameObject.Find("_Players");
        if (_players == null)
        {
            throw new Exception("Object _players not found!");
        }

        foreach (Transform player in _players.transform)
        {
            var playerController = player.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                if (playerController.IsThisMainPlayer)
                {
                    _mainPlayer = playerController;
                    selectedHeroSprite.sprite = _mainPlayer.CurrentlyChosenHero.Hero.Icon;
                }
            }
            else
            {
                throw new Exception(player.name + " doesn't contain PlayerController!");
            }
        }
    }

    bool controlEnabled = true;
    private void Update()
    {
        IsTheGameOver();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        UpdateInfoOnGUI();

        if (_mainPlayer.CurrentlyChosenHero != null)
        {
            if (_mainPlayer.CurrentlyChosenHero.distanceThisTurn >= _mainPlayer.CurrentlyChosenHero.Hero.HeroStats.MaxDistancePerTurn)
            {
                if (this.destinationGameObject != null)
                {
                    this.destinationGameObject.SetActive(false);
                    this.destinationGameObject = null;
                }
            }
            else
            {
                if (controlEnabled)
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                        {

                            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit;

                            if (Physics.Raycast(ray, out hit))
                            {
                                if (hit.collider.gameObject.tag.Equals("terrain"))
                                {
                                    SetMainPlayerDirection(hit.point, null, true);
                                }
                            }
                        }
                    }
                }
            }
            if (Vector3.Distance(_mainPlayer.CurrentlyChosenHero.transform.position, _mainPlayer.CurrentlyChosenHero.GetComponent<NavMeshAgent>().destination) < 0.1)
            {
                selectedTerrain = false;
            }
        }
    }

    void IsTheGameOver()
    {
        if(_mainPlayer == null)
        {
            //defeat
            Database.AddDefeat(LogedUser.UserName);

            SceneManager.LoadScene("Defeat");
        }
        else if(players.Count == 1)
        {
            //victory
            Database.AddVictory(LogedUser.UserName);

            SceneManager.LoadScene("Victory");
        }
    }

    void UpdateInfoOnGUI()
    {
        goldValue.text = _mainPlayer.Player.Resources.Gold.ToString();
        woodValue.text = _mainPlayer.Player.Resources.Wood.ToString();
        stoneValue.text = _mainPlayer.Player.Resources.Stone.ToString();

        if(_mainPlayer == null || _mainPlayer.CurrentlyChosenHero == null)
        {
            selectedHeroSprite.sprite = null;
        }
    }

    public void callback_EndTurn()
    {
        //do AI stuff

        var heroes = GameObject.FindGameObjectsWithTag("Hero");
        foreach (var hero in heroes)
        {
            var heroController = hero.GetComponent<HeroController>();
            heroController.distanceThisTurn = 0;
        }

        var cities = GameObject.FindGameObjectsWithTag("City");
        foreach (var city in cities)
        {
            var cityController = city.GetComponent<CityManager>();
            cityController.City.NextDay();
        }

        var resourceBuildings = GameObject.FindGameObjectsWithTag("ResourceBuilding");
        foreach(var resourceBuilding in resourceBuildings)
        {
            var manager = resourceBuilding.GetComponent<ResourceBuildingManager>();
            manager.NextDay();
        }

        if (day == Day.Sunday)
        {
            day = Day.Monday;
            foreach (var city in cities)
            {
                var cityController = city.GetComponent<CityManager>();
                cityController.City.NextWeek();
            }
        }
        else
        {
            day++;
        }
        dayText.text = day.ToString();
    }

    public void callback_PrevHero()
    {
        if (_mainPlayer != null)
        {
            var heroesCount = _mainPlayer.Player.Heroes.Count;

            if (_mainPlayer.CurrentlyChosenHeroNumber == 0)
            {
                _mainPlayer.CurrentlyChosenHeroNumber = heroesCount - 1;
            }
            else
            {
                _mainPlayer.CurrentlyChosenHeroNumber--;
            }

            _mainPlayer.ChooseNewHero();
            var forward = mainCamera.transform.forward;
            mainCamera.transform.position = _mainPlayer.CurrentlyChosenHero.gameObject.transform.position - forward * 10;

            MoveCameraToCurrentHero();
        }
    }

    public void callback_NextHero()
    {
        if (_mainPlayer != null)
        {
            var heroesCount = _mainPlayer.Player.Heroes.Count;

            if (_mainPlayer.CurrentlyChosenHeroNumber == heroesCount - 1)
            {
                _mainPlayer.CurrentlyChosenHeroNumber = 0;
            }
            else
            {
                _mainPlayer.CurrentlyChosenHeroNumber++;
            }

            _mainPlayer.ChooseNewHero();

            MoveCameraToCurrentHero();
        }
    }

    public void MoveCameraToCurrentHero()
    {
        var forward = mainCamera.transform.forward;
        mainCamera.transform.position = _mainPlayer.CurrentlyChosenHero.gameObject.transform.position - forward * 10;
    }
    bool selectedTerrain = false;
    Vector3 selectedPos;
    public void SetMainPlayerDirection(Vector3 destination, GameObject destinationGameObject, bool isItTerrainClick = false)
    {
        var hero = _mainPlayer.CurrentlyChosenHero;
        if (hero.gameObject.activeSelf)
        {
            if (hero != null)
            {
                var navMeshAgent = hero.GetComponent<NavMeshAgent>();
                if (navMeshAgent == null)
                {
                    throw new System.Exception("Component NavMeshAgent not found!");
                }

                if (this.destinationGameObject == null && selectedTerrain == false)
                {
                    //destination not selected

                    if (isItTerrainClick)
                    {
                        selectedTerrain = true;
                        selectedPos = destination;

                        navMeshAgent.destination = selectedPos;
                        hero.IsGoing = false;
                    }
                    else
                    {
                        this.destinationGameObject = destinationGameObject;
                        navMeshAgent.destination = this.destinationGameObject.transform.position;

                        hero.IsGoing = false;
                    }
                }
                else if (this.destinationGameObject != null || selectedTerrain == true)
                {
                    if (selectedTerrain && isItTerrainClick)
                    {
                        //confirmed or changed

                        if (Vector3.Distance(selectedPos, destination) < 0.5f)
                        {
                            navMeshAgent.destination = selectedPos;

                            hero.IsGoing = true;
                        }
                        else
                        {
                            selectedPos = destination;
                            navMeshAgent.destination = selectedPos;

                            hero.IsGoing = false;
                        }
                    }
                    else if (selectedTerrain && !isItTerrainClick)
                    {
                        selectedTerrain = false;

                        navMeshAgent.destination = destinationGameObject.transform.position;
                        this.destinationGameObject = destinationGameObject;

                        hero.IsGoing = false;
                    }
                    else if (this.destinationGameObject != null && isItTerrainClick)
                    {
                        selectedTerrain = true;
                        selectedPos = destination;

                        navMeshAgent.destination = selectedPos;

                        this.destinationGameObject.SetActive(false);
                        this.destinationGameObject = null;

                        hero.IsGoing = false;
                    }
                    else if (this.destinationGameObject != null && !isItTerrainClick)
                    {
                        if (this.destinationGameObject == destinationGameObject)
                        {
                            navMeshAgent.destination = this.destinationGameObject.transform.position;
                            this.destinationGameObject.SetActive(true);

                            hero.IsGoing = true;
                        }
                        else
                        {
                            this.destinationGameObject.SetActive(false);
                            navMeshAgent.destination = destinationGameObject.transform.position;
                            this.destinationGameObject = destinationGameObject;

                            hero.IsGoing = false;
                        }
                    }
                }
            }
        }
    }

    public void StartFight(HeroController attacking, HeroController defending, CityManager city)
    {
        //if one hero is "empty" - has no units
        if (!defending.Hero.UnitsGroup.HasAnyUnits())
        {
            defending.Die();
        }
        else if (!attacking.Hero.UnitsGroup.HasAnyUnits())
        {
            attacking.Die();
        }
        else
        {
            controlEnabled = false;
            StartCoroutine(LoadFightSceneAsync(attacking, defending, city));
        }
    }

    IEnumerator LoadFightSceneAsync(HeroController attacking, HeroController defending, CityManager city)
    {
        var loadingState = SceneManager.LoadSceneAsync("Fight", LoadSceneMode.Additive);

        while (!loadingState.isDone)
        {
            yield return null;
        }

        mainCamera.gameObject.SetActive(false);
        explorationGUI.SetActive(false);

        GameObject fightManagerGameObject = GameObject.Find("FightManager");
        if (fightManagerGameObject != null)
        {
            var fightManager = fightManagerGameObject.GetComponent<FightManager>();
            if (fightManager != null)
            {
                fightManager.AttackingHero = attacking;
                fightManager.DefendingHero = defending;

                fightManager.City = city;

                fightManager.PrepareForFight();
            }
        }
    }

    public void EndFight(HeroController attacking, HeroController defending, CityManager city)
    {
        if(attacking.Hero.UnitsGroup.HasAnyUnits())
        {
            if(city != null)
            {
                city.City.Owner = attacking.Owner.Player;
            }

            if (defending.Predefined != Hero.PredefinedHero.Empty)
            {
                defending.Die();
            }
        }
        else
        {
            if(city != null)
            {
                for(int i = 0; i < 10; i++)
                {
                    city.City.Inside.UnitFormations[i] = defending.Hero.UnitsGroup.UnitFormations[i];
                    defending.Hero.UnitsGroup.UnitFormations[i] = new UnitFormation(Unit.CreateUnitNone(), 0);
                }
                if(defending.Predefined != Hero.PredefinedHero.Empty)
                {
                    city.City.HeroInside = defending.Hero;
                }
            }
            attacking.Die();
        }
        
        mainCamera.gameObject.SetActive(true);
        explorationGUI.SetActive(true);
        controlEnabled = true;

        SceneManager.UnloadSceneAsync("Fight");
    }

    public void EnterCity(City city, Hero hero)
    {
        controlEnabled = false;
        StartCoroutine(LoadCityAsync(city, hero));
    }

    IEnumerator LoadCityAsync(City city, Hero hero)
    {
        var loadingState = SceneManager.LoadSceneAsync("City", LoadSceneMode.Additive);

        while (!loadingState.isDone)
        {
            yield return null;
        }

        mainCamera.gameObject.SetActive(false);
        explorationGUI.SetActive(false);

        if (hero != null)
        {
            var heroes = GameObject.FindGameObjectsWithTag("Hero");
            foreach (var heroObj in heroes)
            {
                var heroController = heroObj.GetComponent<HeroController>();
                if (heroController.Hero == hero)
                {
                    heroObj.SetActive(false);
                    break;
                }
            }
        }
        GameObject cityOverviewGameObject = GameObject.Find("CityOverview");
        if (cityOverviewGameObject != null)
        {
            var cityOverview = cityOverviewGameObject.GetComponent<CityOverviewManager>();
            if (cityOverview != null)
            {
                if (hero != null)
                {
                    city.AddVisitingHero(hero);
                }

                cityOverview.SetCity(city);
            }
            else
            {
                throw new Exception("CityOverviewManager not found!");
            }
        }
        else
        {
            throw new Exception("CityOverviewGameObject not found!");
        }
    }

    public void ExitCity()
    {
        mainCamera.gameObject.SetActive(true);
        explorationGUI.SetActive(true);

        controlEnabled = true;

        SceneManager.UnloadSceneAsync("City");
    }
}
