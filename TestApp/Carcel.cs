using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    class Carcel
    {

        public Member Entrar(Member member)
        {
            member.isPreso = true;
            return member;
        }

        public List<Member> Salir(List<Member> members, string name)
        {

            members.Find(x => x.Name == name).isPreso = false;

            recuperarSubordinados(members, name);

            return members;
        }

        private void recuperarSubordinados(List<Member> members, string name)
        {
            Member m = members.Find(x => x.Name == name);
            List<string> subAux = new List<string>();

            foreach(Member member in members)
            {
                if(member.Name != m.Name)
                {
                    subAux.AddRange(member.Subordinates);
                    foreach (string sub in subAux)
                    {
                        if (m.Subordinates.Contains(sub))
                        {
                            member.Subordinates.Remove(sub);
                        }
                    }
                }
            }

        }
    }
}
