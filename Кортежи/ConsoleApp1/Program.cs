using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class WayList<T1,T2,T3>:List<Tuple<T1,T2,T3>>
    {
        public void Add(T1 item,T2 item1, T3 item2)
        {
            Add(new Tuple<T1, T2, T3>(item, item1, item2)); //кортеж
        }
    }

    public class WaySystems
    {
        int[,] cityArr;
        public WaySystems(WayList<int,int,int> cityList)
        {
            cityArr = createArray(cityList);
        }
        private int[,] createArray(WayList<int, int, int> cityList)
        {
            cityList.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            int max = cityList[0].Item2;
            cityList.Sort((a, b) => b.Item1.CompareTo(a.Item1));
            max = max <= cityList[0].Item1 ? cityList[0].Item1+1 : max+1;
            int[,] array = new int[max,max];

            foreach (var way in cityList)
                array[way.Item1, way.Item2] = way.Item3;

            return array;
        }
        public void printCities()
        {
            for (int i = 0; i < cityArr.GetLength(0); i++)
            {
                for (int j = 0; j < cityArr.GetLength(1); j++)
                    Console.Write(cityArr[i, j] + "  ");
                Console.WriteLine("\n");
            }
        }

        public void minWay()
        {
            int min = 0;
            int imin=0, jmin=0;
            for (int i = 0; i < cityArr.GetLength(0); i++)
                for (int j = 0; j < cityArr.GetLength(1); j++)
                    if ((min > cityArr[i, j] && cityArr[i, j] != 0) ||(min==0))
                    {
                        min = cityArr[i, j];
                        imin = i;
                        jmin = j;
                    }
            Console.WriteLine("Минимальный путь = {0} Между городами {1} и {2}", min, imin, jmin + "\n");
        }

        public void maxWay()
        {
            int max = 0;
            int imax = 0, jmax = 0;
            for (int i = 0; i < cityArr.GetLength(0); i++)
                for (int j = 0; j < cityArr.GetLength(1); j++)
                    if (max < cityArr[i, j] && cityArr[i, j] != 0)
                    {
                        max = cityArr[i, j];
                        imax = i;
                        jmax = j;
                    }
            Console.WriteLine("Максимальный путь = {0} Между городами {1} и {2}", max, imax, jmax + "\n");
        }

        public void sumWay()
        {
            int sum = 0;
            for (int i = 0; i < cityArr.GetLength(0); i++)
                for (int j = 0; j < cityArr.GetLength(1); j++)
                    sum += cityArr[i, j];
            Console.WriteLine("Сумма всех путей = {0}", sum);
        }

        private int[,] floid()
        {
            int[,] floidArr = cityArr;
            int n = floidArr.GetLength(1);
            for (int k = 0; k < n; k++)
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j && floidArr[i, k] != 0 && floidArr[k, j] != 0)
                        {
                            if (floidArr[i, j] == 0)
                                floidArr[i, j] = floidArr[i, k] + floidArr[k, j];
                            else
                                if (floidArr[i, j] > (floidArr[i, k] + floidArr[k, j]))
                                floidArr[i, j] = floidArr[i, k] + floidArr[k, j];
                        }
                    }
            return floidArr;
        }


        public void minWayCities(int city1, int city2) 
        {
            int[,] matrix = floid();

            if (matrix[city1, city2] == 0)
                Console.WriteLine("Отсутствует дорога для {0} и {1}", city1, city2 + "\n");
            else
                Console.WriteLine("Минимальный путь = {0} Между городами {1} и {2}", matrix[city1, city2], city1, city2 + "\n");
        }

        public void minWayCitiesAll(int city1)
        {
            int[,] matrix = floid();

            for (int i = 0; i < matrix.GetLength(1); i++) Console.Write("{0}  ", i);
            Console.WriteLine("\n");
            for (int i = 0; i < matrix.GetLength(1); i++) Console.Write("{0} ", matrix[city1,i]);
            Console.WriteLine("\n");
        }

    }
    class Program
    {
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Green;
            var cityList = new WayList<int, int, int> {
                {0,2,5},
                {1,3,7},
                {0,4,9},
                {3,1,1},
                {4,0,13}
            };
            WaySystems way = new WaySystems(cityList);
            way.printCities();
            way.minWay();
            way.maxWay();
            way.sumWay();
            way.minWayCities(0,3);
            way.minWayCitiesAll(1);
        }
    }
}
