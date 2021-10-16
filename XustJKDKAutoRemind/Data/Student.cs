using System.Collections.Generic;

namespace XustJKDKAutoRemind.Data
{
    public class Data
    {
        public List<Student> data { get; set; }



        
        
        
    }
    public class Student
    {
        public string GH { get; set; } //学号

        public int LB { get; set; }

        public string? LXFS {  get; set; }//手机 

        public string PXID { get; set; } // 班级

        public string SFXS { get; set; }

        public string SZXKS {  get; set; }

        public string SZXKSID { get; set; }
        public string SZYX {  get; set;}
        public string XB {  get; set; }
        public string XM { get; set;  }


    }


    
}
