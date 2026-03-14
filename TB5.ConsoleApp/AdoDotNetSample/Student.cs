using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB5.ConsoleApp.AdoDotNetSample
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string StudentNo { get; set; }
        public int Marks { get; private set; }
        public void Pay()
        {

        }
        public void SetMark(int mark)
        {
            Marks = mark;
        }
        /// <summary>
        /// Get Grade it will get A or B
        /// </summary>
        /// <returns></returns>
        public string Grade()
        {
            return Marks > 80 ? "A" : "B";
        }
    }
}