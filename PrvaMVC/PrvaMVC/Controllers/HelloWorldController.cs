﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrvaMVC.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public string Index()
        {
            return "Pozdravljen MVC";
        }
        public string Pozdravljen(string ime, int st=1) {
            return "pozdravljen " + ime + " ti bosne " + " kolikokrat " + st;
        }
    }
}