﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPersonalSite.Models;

namespace WebApplication1.Controllers
{
    //TODO - get these links working!
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult EducationalSite()
        {
            return View();
        }

        public ActionResult DungeonCrawler()
        {
            return View();
        }
    }
}