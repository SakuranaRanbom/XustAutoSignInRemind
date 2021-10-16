using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using XustJKDKAutoRemind.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace XustJKDKAutoRemind.Service
{
    public class QQStuServiceImpl : QQStuService
    {
        public QQStuContext _dataContext;

        public QQStuServiceImpl(QQStuContext stuContext)
        {
            _dataContext= stuContext;
        }
        public bool CreateStudent(string GH, string XM, string QQ, string Group)
        {
            var user = _dataContext.QQStus.SingleOrDefault(s => s.GH.Equals(GH));
            if(user == null)
            {
                _dataContext.QQStus.Add(new QQStu
                (
                    null,
                    GH = GH,
                    XM = XM,
                    QQ = QQ,
                    Group = Group
                ));
            }
            if(_dataContext.SaveChanges() > 0)
            {
                return true;
            } else
            {
                return false;
            }
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult<List<QQStu>>> GetQQStus()
        {
            if(_dataContext.QQStus.ToListAsync() == null)
            {
                Console.WriteLine("NULL");
            }
            return await _dataContext.QQStus.ToListAsync();
        }

        public bool RemoveStudent(string GH)
        {
            var user = _dataContext.QQStus.SingleOrDefault(s => s.GH.Equals(GH));
            if(user != null)
            {
                _dataContext.QQStus.Remove(user);
            } else
            {
                return false;
            }
            if(_dataContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
