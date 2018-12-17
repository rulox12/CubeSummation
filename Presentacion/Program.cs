using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string readConsulta = Console.ReadLine();
            int numConsultas = Int32.Parse(readConsulta);
            int dimMatriz;
            int numOperaciones;
            for(int i = 0; i < numConsultas; i++)
            {
                readConsulta = Console.ReadLine();
                string[] words = readConsulta.Split(' ');
                dimMatriz = Int32.Parse(words[0]);
                numOperaciones = Int32.Parse(words[1]);
                long[,,] matriz = new long[dimMatriz+1, dimMatriz+1, dimMatriz+1];
                List<string> list = new List<string>();
                for (int j = 0; j < numOperaciones; j++)
                {
                    string[] operacion = Console.ReadLine().Split(' ');
                    if(operacion[0] == "UPDATE")
                    {
                        int posx = Int32.Parse(operacion[1]);
                        int posy = Int32.Parse(operacion[2]);
                        int posz = Int32.Parse(operacion[3]);
                        if (matriz[posx, posy, posz] != 0)
                        {
                            if (matriz[posx, posy, posz] == -1)
                            {
                                list[0] = operacion[1] + " " + operacion[2] + " " + operacion[3] + " " + operacion[4];
                            }
                            else{
                                list[unchecked((int)matriz[posx, posy, posz])] = operacion[1] + " " + operacion[2] + " " + operacion[3] + " " + operacion[4];
                            }
                        }
                        else
                        {
                            list.Add(operacion[1] + " " + operacion[2] + " " + operacion[3] + " " + operacion[4]);
                            if(list.Count() - 1 == 0)
                            {
                                matriz[posx, posy, posz] = -1;
                            }
                            else
                            {
                                matriz[posx, posy, posz] = list.Count() - 1;
                            }
                        }
                    }
                    else if(operacion[0] == "QUERY")
                    {
                        long sum=0;
                        int posx1 = Int32.Parse(operacion[1]);
                        int posy1 = Int32.Parse(operacion[2]);
                        int posz1 = Int32.Parse(operacion[3]);
                        int posx2 = Int32.Parse(operacion[4]);
                        int posy2 = Int32.Parse(operacion[5]);
                        int posz2 = Int32.Parse(operacion[6]);
                        for (int h = 0; h < list.Count(); h++)
                        {
                            string[] position = list[h].Split(' ');
                            int x = Int32.Parse(position[0]);
                            int y = Int32.Parse(position[1]);
                            int z = Int32.Parse(position[2]);
                            long  value = Int32.Parse(position[3]);
                            if (x >= posx1 && x <= posx2 && y >= posy1 && y <= posy2 && z >= posz1 && z <= posz2)
                            {
                                sum +=value; 
                            }
                        }
                        Console.WriteLine(sum);
                    }
                }

            }
        }
        
    }
}
