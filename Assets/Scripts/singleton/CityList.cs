using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityList
{
    public static List<City> cityList = new List<City>
    {
        new City(0,"map","主地图"),
        new City(1,"chengdu","成都"),
        new City(2,"hangzhou","杭州"),
        new City(3,"nanjing","南京"),
        new City(4,"foshan","佛山"),
        new City(5,"changan","长安"),
        new City(6,"beijing","北京")
    };

    public static int[,] cityDistance = new int[,]
    {
        {-1,-1,-1,-1,-1,-1,-1},
        {-1, 0,25,25,15,10,30},
        {-1, 25,0, 5,15,25,30},
        {-1, 25,5, 0,15,25,30},
        {-1, 15,15,15,0,20,40},
        {-1, 10,25,25,20,0,10},
        {-1, 30,30,30,40,10,0}
    };

}
