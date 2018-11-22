using System; 
 using System.Collections.Generic; 
 using System.Text; 
 using System.IO; 
 using System.Net; 
 using System.Collections; 
 using System.Text.RegularExpressions; 
 using System.Threading; 
 using System.Threading.Tasks; 
 
 
  namespace program1
  { 
     public class Crawler
      { 
         private List<Task> tasks = new List<Task>(); 
         private Hashtable urls = new Hashtable(); 
        private int count = 0; 
          public static void Main(string[] args)
          { 
              try 
             { 
                 Crawler myCrawler = new Crawler(); 
                string startUrl = "http://www.cnblogs.com/dstang2000/"; 
                if (args.Length > 1) 
                     startUrl = args[0]; 
                myCrawler.urls.Add(startUrl, false);                //加入初始界面 
                 myCrawler.Crawl();                                  //爬行 
              } 
              catch (Exception e) 
             { 
                  Console.WriteLine(e.ToString()+"失败！"); 
            } 
          } 
 
 
         private void Crawl()
          { 
            Console.WriteLine("开始爬行了..."); 
              while(true) 
              { 
                  string current = null; 
                  foreach(string url in urls.Keys)                //找到下一个还没有下载过的链接 
                  { 
                      if ((bool) urls[url]) 
                          continue; 
                     current = url; 
                  } 
                  if (current == null || count > 10) 
                      break; 
                 Console.WriteLine("爬行" + current + "页面！"); 
                  tasks.Add(Task.Run(() => { Parse(this.DownLoad(current)); })); //并行处理 
                 urls[current] = true; 
                 count++; 
                  bool allcrawled = true; 
                 foreach(string url in urls.Keys)          //防止已有的url处理完，而有的还未得到新的url 
                 { 
                     if (!(bool) urls[url]) 
                     { 
                          allcrawled = false; 
                         break; 
                     } 
                 } 
                 if (allcrawled) 
                     Task.WaitAll(tasks.ToArray()); 
             } 
          } 
  
 
         public string DownLoad(string url)                         //下载网页 
         { 
            try 
             { 
                  WebClient webClient = new WebClient(); 
                 webClient.Encoding = Encoding.UTF8; 
                 string html = webClient.DownloadString(url); 
                  string fileName = count.ToString() + ".html"; 
                 File.WriteAllText(fileName, html, Encoding.UTF8); 
                  return html; 
              } 
             catch(Exception ex) 
             { 
                 Console.WriteLine(ex.Message); 
                return ""; 
             } 
          } 
  
 
          public void Parse(string html)                                   //解析html 
          { 
             string strRef = @"(href|HREF)\s*=\s*[""']https?[^"">]+[""']"; 
             MatchCollection matches = new Regex(strRef).Matches(html); 
             foreach (Match match in matches) 
             { 
                 strRef=match.Value.Substring(match.Value.IndexOf('=')+1).Trim().Trim('"','\'','>'); 
                  if (strRef.Length == 0) 
                     continue; 
                 if (urls[strRef] == null) 
                     urls[strRef] = false; 
              } 
          } 
      } 
  } 
