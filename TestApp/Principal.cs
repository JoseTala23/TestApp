using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestApp
{
    class Principal
    {
        public static List<Member> members;
        static void Main(string[] args)
        {

            members = JsonConvert.DeserializeObject<List<Member>>(File.ReadAllText("C:/Users/SESA611645/source/repos/TestApp/TestApp/data.json"));

            Console.WriteLine("----  ENTRADA  ----");
            Carcel carcel = new Carcel();
            Member member = carcel.Entrar(members.Find(x => x.Name == "Jhon"));


            reubicarSubordinados(member,member.Subordinates);
            MostrarOrganigrama(members);


            Console.WriteLine("----  SALIDA  ----");
            carcel.Salir(members,"Jhon");
            MostrarOrganigrama(members);

        }

        private static void MostrarOrganigrama(List<Member> members)
        {
            foreach (Member m in members)
            {
                if (!m.isPreso)
                {
                    Console.WriteLine("Name: " + m.Name);
                    Console.WriteLine("Seniority: " + m.Seniority);

                    Console.WriteLine("Subordinates: [");
                    foreach (string sub in m.Subordinates)
                    {
                        Console.WriteLine(sub);
                    }
                    Console.WriteLine("]");
                    Console.WriteLine("Boss: " + m.Boss);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }

            }
        }

        public static void reubicarSubordinados(Member member,List<string> subordinates)
        {
           
            if (member.isPreso)
            {
                if(member.Boss == "")
                {
                    añadirSubordinadosDeJefeAnterior(member);
                }
                else
                {
                    asignarSubordinadosAJefe(member,subordinates);
                }
            }
                              

        }

        private static void añadirSubordinadosDeJefeAnterior(Member member)
        {
            int mayor = 0;
            string subMayor = "";
            foreach(string subordinado in member.Subordinates)
            {                
                if(members.Find(x => x.Name == subordinado).Seniority > mayor && !members.Find(x => x.Name == subordinado).isPreso)
                {
                    mayor = members.Find(x => x.Name == subordinado).Seniority;
                    subMayor = subordinado;
                }
            }
            members.Find(x => x.Name == subMayor).Subordinates.AddRange(member.Subordinates);
            members.Find(x => x.Name == subMayor).Subordinates.Remove(members.Find(x => x.Name == subMayor).Name);           
            

        }

        private static void asignarSubordinadosAJefe(Member member,List<string> subordinates)
        {
            members.Find(x => x.Name == member.Boss).Subordinates.AddRange(subordinates);
        }
    }
}
