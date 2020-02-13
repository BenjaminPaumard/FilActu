using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using Microsoft.Ajax.Utilities;
using FilActualite.Models;

namespace FilActualite.Controllers
{
    public class APIController : Controller
    {
        NewsApiClient newsApiClient;
        public APIController()
        {
            newsApiClient = new NewsApiClient("da89aa40e24f4d10a30b4582174e4fff");
        }
        // GET: API
        public ArticlesResult Acceuil()
        {
            var articlesResponse = this.newsApiClient.GetTopHeadlines(new TopHeadlinesRequest
            {
                Language = Languages.FR
            });
            return articlesResponse;
        }

        public ArticlesResult ActuByCat(Categorie categories, string type = null)
        {
            var date = new DateTime();
            if (type != null & categories.Nom == "Sport")
            {
                var articlesResponse = this.newsApiClient.GetEverything(new EverythingRequest
                {
                    Q = type,
                    SortBy = SortBys.Popularity,
                    Language = Languages.FR,
                    From = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0)
                });
                return articlesResponse;
            } else
            {
                var articlesResponse = this.newsApiClient.GetEverything(new EverythingRequest
                {
                    Q = categories.Nom,
                    SortBy = SortBys.Popularity,
                    Language = Languages.FR,
                    From = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0)
                });
                return articlesResponse;
            }
        }
    }
}
