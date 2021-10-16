using System.Collections.Generic;
using XustJKDKAutoRemind.Data;

namespace XustJKDKAutoRemind.Service
{
    public class Transform
    {
        public static QQStuService _QQStuService {  get; set; }
        public Transform(QQStuService qQStuService)
        {
            _QQStuService = qQStuService;
        }


        public List<QQStu> GetStuMatched()
        {

           return  _QQStuService.GetQQStus().Result.Value;
        }
    }
}
