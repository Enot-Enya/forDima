using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    struct Workers
    {
        public int Id { get; set; }
        public DateTime SetTime { get; set; }
        public string  FullName { get; set; }
        public uint Age { get; set; }
        public uint Height { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string BirthdayPlace { get; set; }

        public Workers(int Id, DateTime SetTime, string FullName, uint Age, uint Height, DateTime BirthdayDate, string BirthdayPlace)
        {
            this.Id=Id;
            this.SetTime=SetTime;
            this.FullName = FullName;
            this.Age = Age;
            this.Height = Height;
            this.BirthdayDate = BirthdayDate;
            this.BirthdayPlace = BirthdayPlace;
        }
       
    }
}
