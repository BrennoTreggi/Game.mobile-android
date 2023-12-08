using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Maneger : MonoBehaviour
{
    public Transform container;
    public float timePieces = .3f;
    private int _index;


    public List<GameObject> Levels;
    public List<LevelPieceSetup> levelPiecesSetup;

   
    [SerializeField] public List<LevelPieceBase> _spaunerPieces = new List<LevelPieceBase>();


    private GameObject _correntlevel;
    private LevelPieceSetup PieceSetup;



    private void Awake()
    {
        //SpawNextLevel();
        CreateLevelPieces();
    }

    private void SpawNextLevel()
    {
    
        if (_correntlevel != null)
        {
            Destroy( _correntlevel );
            _index++;
            // 0 >= 2
            if (_index >= Levels.Count)
            {
                ResetLevelIndex();
            }
        }
        _correntlevel = Instantiate(Levels[_index], container);
        _correntlevel.transform.localPosition = Vector3.zero;    
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    #region Number Piece


    private void CreateLevelPieces()
    {
        // StartCoroutine(CreateLevelPiecesCorotine);

        CleanSpawnepieces();

        if (_correntlevel != null)
        {
            _index++;
            

            if (_index >= levelPiecesSetup.Count)
            {
                ResetLevelIndex();
            }
        }
        PieceSetup = levelPiecesSetup[_index];
        
        for (int i = 0; i < PieceSetup.piecesNumberStart; i++)
        {
            CreatelevelPiace(PieceSetup.LevelPiecesStart);

        }
        for (int i = 0; i < PieceSetup.piecesnumber; i++)
        {
            CreatelevelPiace(PieceSetup.LevelPieces);

        }
        for (int i = 0; i < PieceSetup.piecesnumberEnd; i++)
        {
            CreatelevelPiace(PieceSetup.LevelPiecesEnd);
           
        }

        ColorManager.Instance.ChangeColorByType(PieceSetup.Arttype);

    }


    private void CreatelevelPiace(List<LevelPieceBase> list)
    {
        var Piece = list[Random.Range(0, list.Count)];
        var spaunerPieces = Instantiate( Piece, container);

        if (_spaunerPieces.Count > 0)
        {
           var lastPiece = _spaunerPieces[_spaunerPieces.Count - 1];

            spaunerPieces.transform.position = lastPiece.EndPiece.position;

        }
      
        else
        {
            spaunerPieces.transform.localPosition = Vector3.zero;
        }
        
        
        foreach (var p in spaunerPieces.GetComponentsInChildren<ArtPiece>())
        {

            p.ChangerPiece(ArtManager.Instance.GetSetupbyType(PieceSetup.Arttype).gameObject);

        }


        _spaunerPieces.Add(spaunerPieces);
    }

    private void CleanSpawnepieces()
    {

        for (int i = _spaunerPieces.Count - 1; i >= 0; i -- )
        {
            Destroy(_spaunerPieces[i].gameObject);

        }
        _spaunerPieces.Clear();
    }

    IEnumerator CreateLevelPiecesCorotine()
    {
        _spaunerPieces = new List<LevelPieceBase>();
        for (int i = 0; i < PieceSetup.piecesnumber; i++)
        {
            CreatelevelPiace(PieceSetup.LevelPieces);
            yield return new WaitForSeconds(timePieces);
        }
    }
     
    #endregion

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.D)) 
        {
            SpawNextLevel();
        }
    }



}
