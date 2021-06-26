using SignalRInCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRInCoreMVC
{
    public static class DataCenter
    {
        public static List<Article> Articles = new List<Article> 
        {
            new Article {ArticleId=1, ArticleName= "A1000" },
            new Article {ArticleId=1, ArticleName= "A2000" },
            new Article {ArticleId=1, ArticleName= "A3000" },
            new Article {ArticleId=1, ArticleName= "A4000" },
            new Article {ArticleId=1, ArticleName= "A5000" },
        };
    }
}
