using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using XustJKDKAutoRemind.Data;

namespace XustJKDKAutoRemind.Service
{
    public interface QQStuService
    {
        bool CreateStudent(string GH, string XM, string QQ, string Group);

        Task<ActionResult<List<QQStu>>> GetQQStus();

        bool RemoveStudent(string GH);
    }
}
