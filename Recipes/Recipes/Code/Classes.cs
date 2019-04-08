using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipes.Code
{
    public class Recipe
    {
        public string name { get; set; }
        public string rid { get; set; }
    }

    public class Ingredient
    {
        public string name { get; set; }
        public string iid { get; set; }

    }
    
    public class Favorites
    {
        public string username { get; set; }
        public string rid { get; set; }
    }

    public class Users
    {
        public string username { get; set; }
        public string password { get; set; }
        public string status { get; set; }
    }

    public class AreOf
    {
        public string iid { get; set; }
        public string rid { get; set; }
    }
}