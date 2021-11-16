using System.Collections.Generic;
using UnityEngine;

public static class DataPlayer
{
    private static AllData alldata;
    private const string datacode = "dataplayer";

   static DataPlayer()
   {
       alldata = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(datacode));
       if (alldata == null)
       {
           alldata = new AllData(0);
           SaveData();
       }
   }
   public static void SaveData()
   {
       var dataJson = JsonUtility.ToJson(alldata);
       PlayerPrefs.SetString(datacode, dataJson);
   }
   public static void Addcoin(int coin)
   {
       alldata.Addcoin(coin);
       SaveData();
   }
   public static int Getcoin()
   {
       return alldata.Getcoin();
   }
   public static int GetCurrentCar()
   {
       return alldata.GetCurrentCar();
   }
   public static void SetCurrentCar(int index)
   {
       alldata.SetCurrentCar(index);
       SaveData();
   }
}
public class AllData
{
   private int coin;
   private int currentcar;

   public AllData(int Coin)
   {
       coin = Coin;
   }
   public void Addcoin(int amount)
   {
       coin += amount;
   }
   public int Getcoin()
   {
       int coinUI = coin;
       return coinUI;
   }
   public int GetCurrentCar()
   {
       int index = currentcar;
       return index;
   }
   public void SetCurrentCar(int index)
   {
       currentcar= index;
   }
}