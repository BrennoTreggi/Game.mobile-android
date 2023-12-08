using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceSetup : ScriptableObject
{
    public ArtManager.arttype Arttype;

    [Header("Piceis")]
    public List<LevelPieceBase> LevelPiecesStart;
    public List<LevelPieceBase> LevelPiecesEnd;
    public List<LevelPieceBase> LevelPieces;

    public int piecesNumberStart = 1;
    public int piecesnumberEnd = 1;
    public int piecesnumber = 1;


}
