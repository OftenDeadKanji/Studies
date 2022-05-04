using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    A_star.Grid grid;
    [SerializeField]
    int width = 10;
    [SerializeField]
    int height = 10;
    [SerializeField]
    float cellSize = 1.0f;
    [SerializeField]
    Terrain terrain;
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    Vector2 gridPositionDiff;

    [SerializeField]
    GameObject tmpUnitFormationPrefab;

    [SerializeField]
    HeroController attackingHero;
    public HeroController AttackingHero
    {
        get { return attackingHero; }
        set { attackingHero = value; }
    }

    [SerializeField]
    HeroController defendingHero;
    public HeroController DefendingHero
    {
        get { return defendingHero; }
        set { defendingHero = value; }
    }

    Hero playerHero;
    Hero AIHero;

    UnitFormation[,] battlefield;
    GameObject[,] unitsGameObjects;

    GameObject[,] cellsSelectionVisualizators;

    [SerializeField]
    Material material_notSelected;
    [SerializeField]
    Material material_Selected;
    [SerializeField]
    Material material_Range;
    [SerializeField]
    Material material_AttackTarget;

    [SerializeField]
    Camera fightCamera;

    [Header("GUI")]
    [SerializeField]
    Image[] queueSprites;
    [SerializeField]
    Image[] queueSpritesBackground;
    [SerializeField]
    Color playerBackgroundColor;
    [SerializeField]
    Color enemyBackgroundColor;
    [SerializeField]
    TMPro.TMP_Text[] queueCounts;

    LinkedList<UnitFormation> queue;
    int unitFormationsCount = 0;
    bool isFightReady = false;

    CityManager city;
    public CityManager City
    {
        get { return city; }
        set { city = value; }
    }

    public void PrepareForFight()
    {
        battlefield = new UnitFormation[10, 10];
        unitsGameObjects = new GameObject[10, 10];
        cellsSelectionVisualizators = new GameObject[10, 10];

        queue = new LinkedList<UnitFormation>();

        if (attackingHero == null || defendingHero == null)
        {
            throw new System.Exception("At least one hero is null!");
        }

        if (attackingHero.Owner.Player == gameManager.MainPlayer.Player)
        {
            playerHero = attackingHero.Hero;
            AIHero = defendingHero.Hero;
        }
        else
        {
            playerHero = defendingHero.Hero;
            AIHero = attackingHero.Hero;
        }

        UnitFormation[] tmpQueue = new UnitFormation[20];

        for (int i = 0; i < 10; i++)
        {
            if (i < attackingHero.Hero.UnitsGroup.UnitFormations.Length && attackingHero.Hero.UnitsGroup.UnitFormations[i].Unit.Type != UnitType.None)
            {
                battlefield[0, i] = attackingHero.Hero.UnitsGroup.UnitFormations[i];
                if (battlefield[0, i] != null)
                {
                    tmpQueue[unitFormationsCount++] = battlefield[0, i];
                    grid.GridArray[0, i] = float.PositiveInfinity;

                    unitsGameObjects[0, i] = Instantiate(tmpUnitFormationPrefab, GetGridCellCenterWoldPosition(new Vector2Int(0, i)), Quaternion.identity);
                    unitsGameObjects[0, i].transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                    var unitFormationManager = unitsGameObjects[0, i].GetComponent<UnitFormationManager>();
                    if (unitFormationManager != null)
                    {
                        unitFormationManager.FightCamera = fightCamera;
                        unitFormationManager.UnitFormation = battlefield[0, i];
                    }
                }
            }

            if (i < defendingHero.Hero.UnitsGroup.UnitFormations.Length && defendingHero.Hero.UnitsGroup.UnitFormations[i].Unit.Type != UnitType.None)
            {
                battlefield[9, i] = defendingHero.Hero.UnitsGroup.UnitFormations[i];
                if (battlefield[9, i] != null)
                {
                    tmpQueue[unitFormationsCount++] = battlefield[9, i];
                    grid.GridArray[9, i] = float.PositiveInfinity;

                    unitsGameObjects[9, i] = Instantiate(tmpUnitFormationPrefab, GetGridCellCenterWoldPosition(new Vector2Int(9, i)), Quaternion.identity);
                    unitsGameObjects[9, i].transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
                    var unitFormationManager = unitsGameObjects[9, i].GetComponent<UnitFormationManager>();
                    if (unitFormationManager != null)
                    {
                        unitFormationManager.FightCamera = fightCamera;
                        unitFormationManager.UnitFormation = battlefield[9, i];
                    }
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                cellsSelectionVisualizators[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cellsSelectionVisualizators[i, j].transform.position = new Vector3(0.5f, -50.498f, 0.5f) + new Vector3(i, 0.0f, j);
                cellsSelectionVisualizators[i, j].transform.localScale = new Vector3(0.95f, 1.0f, 0.95f);
                cellsSelectionVisualizators[i, j].GetComponent<MeshRenderer>().material = material_notSelected;

                cellsSelectionVisualizators[i, j].transform.parent = GameObject.Find("_Dynamic").transform;
            }
        }

        for (int i = 0; i < unitFormationsCount; i++)
        {
            queue.AddLast(tmpQueue[i]);
        }

        var rand = new System.Random();
        queue.OrderBy(item => rand.Next());

        UpdateQueueGUI();

        grid.CreateGraph();

        isFightReady = true;
    }

    void UpdateQueueGUI()
    {
        for (int i = 0; i < queueSprites.Length; i++)
        {
            if (i < queue.Count)
            {
                var unitFormation = queue.ElementAt(i);

                queueSprites[i].gameObject.SetActive(true);
                queueSprites[i].sprite = unitFormation.Unit.Icon;

                queueSpritesBackground[i].gameObject.SetActive(true);
                queueSpritesBackground[i].color = IsItPlayerUnitFormation(unitFormation) ? playerBackgroundColor : enemyBackgroundColor;

                queueCounts[i].gameObject.SetActive(true); 
                queueCounts[i].text = unitFormation.Count.ToString();
            }
            else
            {
                queueSprites[i].gameObject.SetActive(false);
                queueSpritesBackground[i].gameObject.SetActive(false);
                queueCounts[i].gameObject.SetActive(false);
            }
        }
    }
    bool isItPlayerTurn()
    {
        foreach (var unitFormation in playerHero.UnitsGroup.UnitFormations)
        {
            if (unitFormation != null && unitFormation.Unit.Type != UnitType.None)
            {
                if (queue.First.Value == unitFormation)
                {
                    return true;
                }
            }
        }

        return false;
    }

    bool IsItPlayerUnitFormation(UnitFormation unitFormation)
    {
        foreach (var unitForm in playerHero.UnitsGroup.UnitFormations)
        {
            if (unitForm != null && unitForm.Unit.Type != UnitType.None)
            {
                if (unitFormation == unitForm)
                {
                    return true;
                }
            }
        }

        return false;
    }

    bool isItAIUnitFormation(Vector2Int pos)
    {
        foreach (var unitFormation in AIHero.UnitsGroup.UnitFormations)
        {
            if (unitFormation != null && unitFormation.Unit.Type != UnitType.None)
            {
                if (battlefield[pos.x, pos.y] == unitFormation)
                {
                    return true;
                }
            }
        }

        return false;
    }

    bool IsItUnitFromDefendingHero(UnitFormation unitFormation)
    {
        foreach (var unitForm in defendingHero.Hero.UnitsGroup.UnitFormations)
        {
            if (unitForm != null && unitForm.Unit.Type != UnitType.None)
            {
                if (unitFormation == unitForm)
                {
                    return true;
                }
            }
        }

        return false;
    }

    Vector3 GetGridCellCenterWoldPosition(Vector2Int grid)
    {
        return terrain.transform.position + new Vector3(gridPositionDiff.x, 0.0f, gridPositionDiff.y) + (new Vector3(1.0f, 0.0f, 0.0f) * grid.x * cellSize) + (new Vector3(0.0f, 0.0f, 1.0f) * grid.y * cellSize) + new Vector3(0.5f, 0.0f, 0.5f) * cellSize;
    }

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        grid = new A_star.Grid(width, height);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                grid.GridArray[i, j] = 1.0f;
            }
        }
        grid.CreateGraph();

        isFightReady = false;
    }
    bool updateTurn = true;
    void Update()
    {
        if (isFightReady)
        {
            Vector3 translation = terrain.transform.position;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Vector3 p0 = translation + new Vector3(i, 0, j);
                    Vector3 p1 = translation + new Vector3(i, 0, j) + new Vector3(cellSize, 0.0f, cellSize);

                    p0.x += gridPositionDiff.x;
                    p0.z += gridPositionDiff.y;

                    p1.x += gridPositionDiff.x;
                    p1.z += gridPositionDiff.y;

                    Debug.DrawLine(new Vector3(p0.x, p0.y + 0.05f, p0.z), new Vector3(p1.x, p0.y + 0.05f, p0.z));
                    Debug.DrawLine(new Vector3(p0.x, p0.y + 0.05f, p0.z), new Vector3(p0.x, p0.y + 0.05f, p1.z));
                }
            }
            if (fightCamera != null && updateTurn)
            {
                if (isItPlayerTurn())
                {
                    playerTurnUpdate();
                }
                else
                {
                    AITurn();
                }
            }
        }
    }

    void playerTurnUpdate()
    {
        Vector2Int startPos = Vector2Int.zero;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (battlefield[i, j] == queue.First.Value)
                {
                    startPos = new Vector2Int(i, j);
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var rangePath = A_star.A_star.FindPath(startPos, new Vector2Int(i, j), grid);
                if (rangePath.Count > queue.First.Value.Unit.MaxDistancePerTurn || grid.GridArray[i, j] == float.PositiveInfinity)
                {
                    cellsSelectionVisualizators[i, j].GetComponent<MeshRenderer>().material = material_notSelected;
                }
                else
                {
                    cellsSelectionVisualizators[i, j].GetComponent<MeshRenderer>().material = material_Range;
                }
            }
        }

        Ray ray = fightCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            int x = (int)hit.point.x;
            int z = (int)hit.point.z;

            if (grid.GridArray[x, z] != float.PositiveInfinity || isItAIUnitFormation(new Vector2Int(x, z)))
            {
                Vector2Int? attackTarget = null;
                Vector2Int endPos = new Vector2Int(x, z);
                if (isItAIUnitFormation(new Vector2Int(x, z)))
                {
                    attackTarget = new Vector2Int(x, z);

                    if (queue.First.Value.Unit.Type != UnitType.Ranged && queue.First.Value.Unit.Type != UnitType.UpgradedRanged)
                    {
                        float x_frac = Mathf.Repeat(hit.point.x, 1.0f);

                        float z_frac = Mathf.Repeat(hit.point.z, 1.0f);

                        if (x_frac < 0.25f)
                        {
                            if (x == 0)
                            {
                                return;
                            }

                            if (z_frac < 0.25f)
                            {
                                if (z == 0)
                                {
                                    return;
                                }

                                endPos = new Vector2Int(x - 1, z - 1);
                            }
                            else if (z_frac > 0.75f)
                            {
                                if (z == 9)
                                {
                                    return;
                                }

                                endPos = new Vector2Int(x - 1, z + 1);
                            }
                            else
                            {
                                endPos = new Vector2Int(x - 1, z);
                            }
                        }
                        else if (x_frac > 0.75f)
                        {
                            if (x == 9)
                            {
                                return;
                            }

                            if (z_frac < 0.25f)
                            {
                                if (z == 0)
                                {
                                    return;
                                }
                                endPos = new Vector2Int(x + 1, z - 1);
                            }
                            else if (z_frac > 0.75f)
                            {
                                if (z == 9)
                                {
                                    return;
                                }
                                endPos = new Vector2Int(x + 1, z + 1);
                            }
                            else
                            {
                                endPos = new Vector2Int(x + 1, z);
                            }
                        }
                        else
                        {
                            if (z_frac < 0.25f)
                            {
                                if (z == 0)
                                {
                                    return;
                                }
                                endPos = new Vector2Int(x, z - 1);
                            }
                            else if (z_frac > 0.75f)
                            {
                                if (z == 9)
                                {
                                    return;
                                }
                                endPos = new Vector2Int(x, z + 1);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }

                if ((queue.First.Value.Unit.Type != UnitType.Ranged && queue.First.Value.Unit.Type != UnitType.UpgradedRanged) &&
                    (startPos.x != endPos.x && startPos.y != endPos.y) && grid.GridArray[endPos.x, endPos.y] == float.PositiveInfinity)
                {
                    return;
                }

                if (queue.First.Value.Unit.Type != UnitType.Ranged && queue.First.Value.Unit.Type != UnitType.UpgradedRanged)
                {
                    var path = A_star.A_star.FindPath(startPos, endPos, grid);
                    if (path.Count <= queue.First.Value.Unit.MaxDistancePerTurn)
                    {
                        foreach (var pos in path)
                        {
                            cellsSelectionVisualizators[pos.x, pos.y].GetComponent<MeshRenderer>().material = material_Selected;
                        }

                        if (attackTarget != null)
                        {
                            cellsSelectionVisualizators[(int)attackTarget?.x, (int)attackTarget?.y].GetComponent<MeshRenderer>().material = material_AttackTarget;
                        }

                        //check click - if yes then move
                        if (Input.GetMouseButtonDown(0))
                        {
                            //check if attack

                            updateTurn = false;
                            for (int i = 0; i < 10; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    cellsSelectionVisualizators[i, j].GetComponent<MeshRenderer>().material = material_notSelected;
                                }
                            }

                            StartCoroutine(MoveUnitFormationAndAttack(startPos, endPos, attackTarget, path));

                        }
                    }
                }
                else
                {
                    if(attackTarget != null)
                    {
                        cellsSelectionVisualizators[(int)attackTarget?.x, (int)attackTarget?.y].GetComponent<MeshRenderer>().material = material_AttackTarget;

                        if(Input.GetMouseButtonDown(0))
                        {
                            updateTurn = false;
                            for (int i = 0; i < 10; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    cellsSelectionVisualizators[i, j].GetComponent<MeshRenderer>().material = material_notSelected;
                                }
                            }

                            StartCoroutine(MoveUnitFormationAndAttack(startPos, startPos, attackTarget, null));
                        }
                    }
                    else
                    {
                        var path = A_star.A_star.FindPath(startPos, endPos, grid);
                        if (path.Count <= queue.First.Value.Unit.MaxDistancePerTurn)
                        {
                            foreach (var pos in path)
                            {
                                cellsSelectionVisualizators[pos.x, pos.y].GetComponent<MeshRenderer>().material = material_Selected;
                            }
                        }

                        if (Input.GetMouseButtonDown(0))
                        {
                            updateTurn = false;
                            for (int i = 0; i < 10; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    cellsSelectionVisualizators[i, j].GetComponent<MeshRenderer>().material = material_notSelected;
                                }
                            }

                            StartCoroutine(MoveUnitFormationAndAttack(startPos, endPos, attackTarget, null));
                        }
                    }
                }
            }
        }
    }

    void AITurn()
    {
        UnitFormation unitFormation = queue.First.Value;
        UnitFormation playerUnitFormation = null;
        foreach(var formation in playerHero.UnitsGroup.UnitFormations)
        {
            if(formation != null && formation.Unit.Type != UnitType.None)
            {
                playerUnitFormation = formation;
                break;
            }
        }
        Vector2Int unitFormationPos = Vector2Int.zero;
        Vector2Int playerUnitFormationPos = Vector2Int.zero;
        for (int i = 0; i < 10; i++)
        {
            for(int j = 0;j < 10; j++)
            {
                if(battlefield[i, j] == playerUnitFormation)
                {
                    playerUnitFormationPos = new Vector2Int(i, j);
                }
                else if(battlefield[i, j] == unitFormation)
                {
                    unitFormationPos = new Vector2Int(i, j);
                }
            }
        }

        var pathToPlayer = A_star.A_star.FindPath(unitFormationPos, playerUnitFormationPos, grid);
        if(pathToPlayer.Count <= unitFormation.Unit.MaxDistancePerTurn)
        {
            //playerUnitFormation can be attacked
            var endPos = pathToPlayer[pathToPlayer.Count - 2];


            updateTurn = false;
            StartCoroutine(MoveUnitFormationAndAttack(unitFormationPos, endPos, playerUnitFormationPos));

            return;
        }

        List<Vector2Int> inRange = new List<Vector2Int>();
        List<int> distanceToPlayerUnitFormation = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var path = A_star.A_star.FindPath(unitFormationPos, new Vector2Int(i, j), grid);
                if(path.Count <= unitFormation.Unit.MaxDistancePerTurn)
                {
                    inRange.Add(new Vector2Int(i, j));

                    var pathToPlayerUnitFormation = A_star.A_star.FindPath(inRange.Last(), playerUnitFormationPos, grid);
                    distanceToPlayerUnitFormation.Add(pathToPlayerUnitFormation.Count);
                }
            }
        }

        int idx = distanceToPlayerUnitFormation.Select((item, index) => (item, index)).Min().index;
        
        updateTurn = false;

        StartCoroutine(MoveUnitFormationAndAttack(unitFormationPos, inRange[idx], null));
    }

    void EndTurn()
    {
        queue.AddLast(queue.First.Value);
        queue.RemoveFirst();

        if (IsFightOver())
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if(cellsSelectionVisualizators[i, j] != null)
                    {
                        Destroy(cellsSelectionVisualizators[i, j]);
                    }

                    if(unitsGameObjects[i, j] != null)
                    {
                        Destroy(unitsGameObjects[i, j]);
                    }
                }
            }
            gameManager.EndFight(attackingHero, defendingHero, city);
        }

        UpdateQueueGUI();

        UpdateGrid();
    }

    bool IsFightOver()
    {
        bool hasPlayerUnits = false;
        for (int i = 0; i < playerHero.UnitsGroup.UnitFormations.Length; ++i)
        {
            if (playerHero.UnitsGroup.UnitFormations[i].Unit.Type != UnitType.None)
            {
                if (playerHero.UnitsGroup.UnitFormations[i].Count <= 0)
                {
                    playerHero.UnitsGroup.UnitFormations[i] = new UnitFormation(Unit.CreateUnitNone(), 0);
                }
                else
                {
                    hasPlayerUnits = true;
                }
            }
        }

        bool hasAIUnits = false;
        for (int i = 0; i < AIHero.UnitsGroup.UnitFormations.Length; ++i)
        {
            if (AIHero.UnitsGroup.UnitFormations[i].Unit.Type != UnitType.None)
            {
                if (AIHero.UnitsGroup.UnitFormations[i].Count <= 0)
                {
                    AIHero.UnitsGroup.UnitFormations[i] = new UnitFormation(Unit.CreateUnitNone(), 0);
                }
                else
                {
                    hasAIUnits = true;
                }
            }
        }

        return hasPlayerUnits != hasAIUnits;
    }

    void UpdateGrid()
    {
        if (true)
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    if (battlefield[i, j] != null)
                    {
                        grid.GridArray[i, j] = float.PositiveInfinity;
                    }
                    else
                    {
                        grid.GridArray[i, j] = 1.0f;
                    }
                }
            }
        }
        grid.CreateGraph();
    }

    IEnumerator MoveUnitFormationAndAttack(Vector2Int startPos, Vector2Int endPos, Vector2Int? attackTarget = null, List<Vector2Int> path = null)
    {
        if (path == null)
        {
            path = A_star.A_star.FindPath(startPos, endPos, grid);
        }

        while (path.Count > 1)
        {

            startPos = path[0];
            endPos = path[1];

            if (Vector3.Distance(unitsGameObjects[startPos.x, startPos.y].transform.position, GetGridCellCenterWoldPosition(endPos)) < 0.01f)
            {
                //moveing to next grid cell completed
                unitsGameObjects[startPos.x, startPos.y].transform.position = GetGridCellCenterWoldPosition(endPos);

                battlefield[endPos.x, endPos.y] = battlefield[startPos.x, startPos.y];
                battlefield[startPos.x, startPos.y] = null;

                unitsGameObjects[startPos.x, startPos.y].transform.position = GetGridCellCenterWoldPosition(endPos);
                unitsGameObjects[endPos.x, endPos.y] = unitsGameObjects[startPos.x, startPos.y];
                unitsGameObjects[startPos.x, startPos.y] = null;

                path.RemoveAt(0);
            }
            else
            {
                //move it
                unitsGameObjects[startPos.x, startPos.y].transform.position += (GetGridCellCenterWoldPosition(endPos) - GetGridCellCenterWoldPosition(startPos)) * Time.fixedDeltaTime;
            }

            yield return null;
        }
        //attack
        if (attackTarget != null)
        {
            //attack animation

            unitsGameObjects[endPos.x, endPos.y].transform.LookAt(unitsGameObjects[(int)attackTarget?.x, (int)attackTarget?.y].transform);

            //attack animation

            UnitFormation attacking = battlefield[endPos.x, endPos.y];
            UnitFormation defending = battlefield[(int)(attackTarget?.x), (int)(attackTarget?.y)];

            int attackPower = attacking.Unit.AttackPower * attacking.Count;
            if(city != null && IsItUnitFromDefendingHero(attacking))
            {
                attackPower = (int)(attackPower * 1.5f);
            }
            //float defensePower = defending.Unit.DefensePower * defending.Count;

            int startHealth = defending.Unit.Health * defending.Count;
            int endHealth = startHealth - attackPower;

            defending.Count = (endHealth / defending.Unit.Health);

            if (defending.Count <= 0)
            {
                queue.Remove(defending);

                battlefield[(int)(attackTarget?.x), (int)(attackTarget?.y)] = null;

                Destroy(unitsGameObjects[(int)(attackTarget?.x), (int)(attackTarget?.y)]);
                unitsGameObjects[(int)(attackTarget?.x), (int)(attackTarget?.y)] = null;
            }
        }

        updateTurn = true;
        EndTurn();
    }
}
