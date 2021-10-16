
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XustJKDKAutoRemind.Service; 
namespace XustJKDKAutoRemind.Data
{
    public class ClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _cookies = "";
        private readonly HttpClient _httpClient = new HttpClient();
        //private readonly QQStuContext context;
        public List<Student> data {  get; set; }

        public List<QQStu> StudentLists = new List<QQStu>();

        public List<string> QQs = new List<string>();
        private void Init()
        {

        }

        private readonly IDbContextFactory<QQStuContext> dbContextFactory;
        public ClientService()
        {
            
        }

        public ClientService(IHttpClientFactory httpClientFactory, IServiceProvider provider)
        {
            _httpClientFactory = httpClientFactory;
            
            //dbContextFactory = provider.GetRequiredService<IDbContextFactory<QQStuContext>>();
            
        }

        public async Task GetCookie()
        {
            //var client = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://ehallplatform.xust.edu.cn");
            var res = await _httpClient.GetAsync("/default/jkdkgl/mobile/wsbrymx.jsp?uid=NDQxMkE5MjgzRjc2NThGOTZFNDU1OTY1MDIxQ0Q5NTQ=&cxsj=2021-10-15&cxlx=0&bmid=%274006073%27&bmjb=3");
            var headers = res.Headers.ToString();
            var reg = new Regex("JSESSIONID=.*?(?=;)");;
            Match match = reg.Match(headers);
            var cookies = match.Value;
            
            //Console.WriteLine(cookies);
            _cookies = cookies;
        }

        public async Task GetStuList(string daystr)
        {
            await GetCookie();
            
            StringContent stringContent = new StringContent("{\"bmid\": \"4006073\",\"cxsj\": \""+daystr+"\",\"cxbmjb\": \"3\",\"cxlx\": \"0\"}");
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Console.WriteLine(_cookies);
            _httpClient.DefaultRequestHeaders.Add("Cookie", _cookies);
            var res = await _httpClient.PostAsync("/default/jkdkgl/mobile/com.primeton.eos.jkdkgl.WSBRYCX.CXWSBRY.biz.ext",stringContent );
            //Console.WriteLine(res.Content.ReadAsStringAsync().Result);
            
            var jso = JsonConvert.DeserializeObject<Data>(res.Content.ReadAsStringAsync().Result);
            
            foreach (var i in jso.data)
            {
                //Console.WriteLine(i.XM + ",");
            }
             data = jso.data;
        }

        public async Task GetOkList(string daystr)
        {
            Init();
            await GetStuList(daystr);
            foreach(var i in data)
            {
                foreach(var j in StudentLists)
                {
                    if(i.GH.Equals(j.GH))
                    {
                        QQs.Add(j.QQ);
                    }
                }
            }

            foreach(var i in QQs)
            {
                Console.WriteLine(i);
            }
            //using var db = dbContextFactory.CreateDbContext();
            //var ls =await db.QQStus.ToListAsync();
            
        }

        public async void SendBot(string daystr)
        {
            await GetOkList(daystr);
            if(!QQs.Count.Equals(0))
            {
                string total = "";
                foreach (var i in QQs)
                {
                    total += "[CQ:at,qq=";
                    total += i;
                    total += "] ";
                }
                total += "等" + QQs.Count.ToString() + "人";
                var client = new RestClient("http://xxxx:12667/send_group_msg?group_id=553xxxx85&message=" + total + "今日未健康打卡，请尽快打卡！");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
            }
            
        }
    }
}

