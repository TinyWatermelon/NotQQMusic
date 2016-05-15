using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace NotQQMuisc
{
    public static class GetJson
    {
        public static string Getjson(string api)
        {
            string content = "";
            HttpClient httpClient = new HttpClient();
            System.Net.Http.HttpResponseMessage response;
            response = httpClient.GetAsync(new Uri(api)).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                content = response.Content.ReadAsStringAsync().Result;
            }
            return content;
        }
        //    string Content = "";
        //    string exceptionInfo = "";
        //    var request = HttpWebRequest.Create(api);
        //    request.Method = "GET";
        //    request.BeginGetResponse(async (result) =>
        //    {
        //        try
        //        {
        //            HttpWebRequest httpWebRequest = (HttpWebRequest)result.AsyncState;
        //            WebResponse webRespose = httpWebRequest.EndGetResponse(result);
        //            using (Stream stream = webRespose.GetResponseStream())
        //            using (StreamReader reader = new StreamReader(stream))
        //            {
        //                string content = reader.ReadToEnd();
        //                Content = content;
        //            }
        //        }
        //        catch (WebException e)
        //        {
        //            switch (e.Status)
        //            {
        //                case WebExceptionStatus.ConnectFailure:
        //                    exceptionInfo = "ConnectFailure";
        //                    break;
        //                case WebExceptionStatus.MessageLengthLimitExceeded:
        //                    exceptionInfo = "MessageLengthLimitExceeded";
        //                    break;
        //                case WebExceptionStatus.Pending:
        //                    exceptionInfo = "Pending";
        //                    break;
        //                case WebExceptionStatus.SendFailure:
        //                    exceptionInfo = "SendFailure";
        //                    break;
        //                case WebExceptionStatus.UnknownError:
        //                    exceptionInfo = "UnknownError";
        //                    break;
        //                case WebExceptionStatus.Success:
        //                    exceptionInfo = "Success";
        //                    break;
        //                default:
        //                    exceptionInfo = "Unknown";
        //                    break;
        //            }
        //        }
        //        if (exceptionInfo != "")
        //        {
        //            await new MessageDialog(exceptionInfo).ShowAsync();
        //        }
        //    }, request);
        //    return Content;
        //}
    }
}
