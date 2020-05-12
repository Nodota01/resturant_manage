using Insight.Database;
using System;
using System.Reflection;
using System.Text;

namespace ConsoleApp1.domain
{
    class Patient
    {
        public uint Id { get; set; }

        public string name { get; set; }

        public ushort Age { get; set; }

        public bool Gender { get; set; }

        //籍贯
        public string Native_place { get; set; }

        //婚姻
        public bool? Is_merried { get; set; }

        //职业
        public string Occupation { get; set; }

        //居住地
        public string Address { get; set; }

        public DateTime Insert_date { get; set; }

        public DateTime Update_date { get; set; }

        public Patient() 
        {
            Random random = new Random();
            this.Id  = (uint)random.Next(0, 0xffffff);
        }
        public Patient(string name, ushort age)
        {
            this.name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return Id.ToString() + name + Age.ToString() + Gender + Native_place + Is_merried + Occupation + Address + Insert_date + Update_date;
        }
    }
}
