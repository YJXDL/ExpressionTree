using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 表达式树
{
    internal class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string AuthorName { get; set; }

        public override string? ToString()
        {
            return "         书的编号"+BookID.ToString() +"        书名"+ Name +"      书的价格"+ Price.ToString() +"      作者："+ AuthorName;
        }
    }
}
