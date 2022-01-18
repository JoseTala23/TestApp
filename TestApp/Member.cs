using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TestApp
{
    class Member
    {       
        public string Name { get; set; }      
        public int Seniority { get; set; }        
        public List<string> Subordinates { get; set; }        
        public string Boss { get; set; }

        public bool isPreso { get; set; }

        public Member(string name,int seniority,List<string> subordinates,string boss)
        {
            this.Name = name;
            this.Seniority = seniority;
            this.Subordinates = subordinates;
            this.Boss = boss;
        }

        public Member(){}

        public string getName()
        {
            return this.Name;
        }

        public void setName(string name)
        {
            this.Name = name;
        }

        public int getSeniority()
        {
            return this.Seniority;
        }

        public void setSeniority(int seniority)
        {
            this.Seniority = seniority;
        }

        public List<string> getSubordinates()
        {
            return this.Subordinates;
        }

        public void setSubordinates(List<string> subordinates)
        {
            this.Subordinates = subordinates;
        }

        public string getBoss()
        {
            return this.Boss;
        }

        public void setBoss(string boss)
        {
            this.Boss = boss;
        }

        public bool getIsPreso()
        {
            return this.isPreso;
        }

        public void setIsPreso(bool isPreso)
        {
            this.isPreso = isPreso;
        }
    }
}
