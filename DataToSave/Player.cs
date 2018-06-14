using System;
using System.Collections;
using System.Collections.Generic;

public class Player : ISaveAndLoad
{
    public int health;
    public float POSITIONx;
    public float POSITIONy;
    public float POSITIONz;

    public void Load(int LoadingIndex)
    {
        PlayerData pd = SavingManager.LoadData<PlayerData>(PlayerData.key, LoadingIndex);

        POSITIONx = pd.POSx;
        POSITIONy = pd.POSy;
        POSITIONz = pd.POSz;

        health = pd.life;
    }

    public void Save(int SavingIndex)
    {
        PlayerData pd = new PlayerData(POSITIONx, POSITIONy, POSITIONz, health);
        SavingManager.SaveData<PlayerData>(pd, SavingIndex);
    }
}

[System.Serializable]
public class PlayerData : SavebleObject
{
    public static string key = "Player";

    public float POSx;
    public float POSy;
    public float POSz;

    public int life;

    public PlayerData(float x, float y, float z, int life)
    {
        POSx = x;
        POSy = y;
        POSz = z;

        this.life = life;
    }

    public override string GetKey()
    {
        return key;
    }

    public override string GetPrefabPath()
    {
        return "Prefabs/FPSController";
    }

    public override bool isInstantiatable()
    {
        return true;
    }
}
