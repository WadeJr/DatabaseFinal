using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using Uptimize.code;

namespace Recipes.Code
{
    public static class Functions
    {
        public static bool loggedIn = false;
        public static bool admin { get; set; }
        public static string username { get; set; }


        //Get the status of user
        public static bool isAdmin(string userName)
        {
            string shortUrl = "user/status/" + userName;
            string url = ApiCall(shortUrl);
            WebRequest request = WebRequest.Create(url);
            //Set Method 
            request.Method = "get";

            string rights = "";


            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                rights = response.StatusCode.ToString();

            }
            catch (WebException we)
            {
                rights = ((HttpWebResponse)we.Response).StatusCode.ToString();

            }


            if (rights == "OK")
            {
                return true;
            }
            return false;
        }

        //Log in
        public static bool Authenticate(string userName, string password)
        {
            string shortUrl = "users/login/" + userName + "/" + password;
            string url = ApiCall(shortUrl);
            WebRequest request = WebRequest.Create(url);
            //Set Method 
            request.Method = "get";

            string code = "";
            
        

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
             
                code = response.StatusCode.ToString();

            }
            catch (WebException we)
            {
                code = ((HttpWebResponse)we.Response).StatusCode.ToString();
   
            }

           
         
            if (code == "OK")
            {
                loggedIn = true;
                username = userName;
                if(isAdmin(username))
                {
                    admin = true;
                }
                else
                {
                    admin = false;
                }
                return true;
            }
            return false;
           
        }


        //Sign up
        public static bool SignUp(string userName, string password)
        {
            string shortUrl = "users/signup/" + userName + "/" + password + "/f";
            string url = ApiCall(shortUrl);
            WebRequest request = WebRequest.Create(url);
            //Set Method 
            request.Method = "post";

            string code = "";
            admin = false;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                code = response.StatusCode.ToString();

            }
            catch (WebException we)
            {
                code = ((HttpWebResponse)we.Response).StatusCode.ToString();

            }

            if (code == "OK")
            {
                loggedIn = true;
                username = userName;
                return true;
            }
            return false;


        }

        //Display message
        public static void Alert(string message)
        {
            string cleanMessage = message.Replace("'", "\'");
            Page page = HttpContext.Current.CurrentHandler as Page;
            string script = string.Format("alert('{0}');", cleanMessage);
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true );
            }

        }

        //Log out
        public static void LogOut(string q)
        {
            if(q == "o")
            {
                loggedIn = false;
            }
        }

        //Set url for api call
        public static string ApiCall(string url)
        {
             return "http://dbdesignfinal.herokuapp.com/api/" + url + "/";
        }

        //Convert obj to json string
        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        //convert json to datatable
        public static DataTable JsonToDataTable(string json)
        {
            return (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
        }



        //Convert HttpRequest to dataTable or Display message
        public static DataTable HttpRequest_To_DataTable(string shortUrl, string method)
        {
            string json = "";

            //For Http request
            //Set url
            string url = ApiCall(shortUrl);
            WebRequest request = WebRequest.Create(url);
            //Set Method 
            request.Method = method;

            //Make Request
            try
            {

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            }
            catch (Exception) { }
            try
            {
                return JsonToDataTable(json);
            }
            catch (Exception) { }
            return new DataTable();
        }


        //Get a column from a dataTable
        public static List<string> GetColumn(string colName, DataTable dt)
        {
            List<string> data = new List<string>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
                data.Add((string)row[colName]);
            return data;
        }
    }
}







//public static DataTable HttpRequest_To_DataTable(string shortUrl, string method, string dataToPost)
//{
//    string json = "";

//    //For Http request
//    //Set url
//    string url = ApiCall(shortUrl);
//    WebRequest request = WebRequest.Create(url);
//    //Set Method 
//    request.Method = method;

//    //Make Request
//    try
//    {
//        if (method.ToLower() == "post" || method.ToLower() == "delete")
//        {
//            request.ContentType = "application/json";

//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


//            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
//            {

//                streamWriter.Write(dataToPost);
//                //streamWriter.Write(new JavaScriptSerializer().Serialize(dataToPost));
//                streamWriter.Flush();
//                streamWriter.Close();
//            }

//            var httpResponse = (HttpWebResponse)request.GetResponse();


//            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
//            {
//                string result = streamReader.ReadToEnd();
//                //Display message
//                Alert(result);
//            }


//        }
//        else if (method.ToLower() == "get")
//        {

//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            json = new StreamReader(response.GetResponseStream()).ReadToEnd();

//        }
//    }
//    catch (Exception) { }
//    try
//    {
//        return JsonToDataTable(json);
//    }
//    catch (Exception) { }
//    return new DataTable();
//}



////Convert HttpRequest to dataTable or Display message
//public static DataTable HttpRequest_To_DataTable(string shortUrl, string method, Object dataToPost = null)
//{
//    string json = "";

//    //For Http request
//    //Set url
//    string url = ApiCall(shortUrl);
//    WebRequest request = WebRequest.Create(url);
//    //Set Method 
//    request.Method = method;

//    //Make Request
//    try
//    {
//        if (method.ToLower() == "post" || method.ToLower() == "delete")
//        {
//            request.ContentType = "application/json";

//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


//            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
//            {

//                streamWriter.Write(new JavaScriptSerializer().Serialize(dataToPost));
//                streamWriter.Flush();
//                streamWriter.Close();
//            }

//            var httpResponse = (HttpWebResponse)request.GetResponse();


//            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
//            {
//                string result = streamReader.ReadToEnd();
//                //Display message
//                Alert(result);
//            }


//        }
//        else if (method.ToLower() == "get")
//        {

//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            json = new StreamReader(response.GetResponseStream()).ReadToEnd();

//        }
//    }
//    catch (Exception) { }
//    try
//    {
//        return JsonToDataTable(json);
//    }
//    catch (Exception) { }
//    return new DataTable();
//}