using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 虾皮PP
{
    public class ai
    {
        public static string Detect(String PictureBase64)
        {
            act act = new act();
            string token = act.getAccessToken();
            string host = "https://aip.baidubce.com/rest/2.0/face/v3/detect?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"image\":\"" + PictureBase64 + "\",\"image_type\":\"BASE64\",\"face_field\":\"age,beauty,expression,face_shape,gender,glasses,race,quality,face_type\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            Console.WriteLine("人脸检测与属性分析:");
            Console.WriteLine(result);
            return result;
        }
    }
}
