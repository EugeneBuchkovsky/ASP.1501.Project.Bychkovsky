using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Infrastructure
{
    public class TagModule
    {
        public static string[] ReturnTags(string tagString)
        {
            string[] tags = tagString.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            return tags;
        }
    }
}
