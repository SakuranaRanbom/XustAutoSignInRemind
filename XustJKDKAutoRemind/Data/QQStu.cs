
using System.ComponentModel.DataAnnotations;

namespace XustJKDKAutoRemind.Data
{
    public class QQStu
    {
        public QQStu( int? Id, string GH, string XM, string QQ, string Group)
        {
            this.Id = Id;
            this.GH = GH;
            this.XM = XM;
            this.QQ = QQ;
            this.Group = Group;
        }

        [Key]
        public int? Id {  get; set; }    
        public string GH { get; set; }
        public string XM { get; set; }

        public string QQ { get; set; }

        public string Group { get; set; }
        
    }
}
