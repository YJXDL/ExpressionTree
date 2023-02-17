using ExpressionTreeToString;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Reflection;

namespace 表达式树
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Book> books = new List<Book>
            {
                new Book{Name=".Net面试宝典",Price=50},
                new Book{Name="C#基础",Price=150}
            };

            //Expression 会生成查找语句
            Expression<Func<Book, bool>> e1 = b => b.Price > 50;
            Expression<Func<Book, Book, int>> AddRes = (e1, e2) => e1.Price + e2.Price;
            textBox1.Text = AddRes.ToString("Object notation", "C#");

            //Func 把所有数据找到在内存中查找
            Func<Book, bool> f1 = b => b.Price > 50;
            Func<Book, Book, int> f2 = (e1, e2) => e1.Price + e2.Price;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParameterExpression paramExprB = Expression.Parameter(typeof(Book), "b");
            ConstantExpression constExpr5 = Expression.Constant(5);
            MemberExpression memExprePrice = Expression.MakeMemberAccess(paramExprB, typeof(Book).GetProperty("Price"));
            BinaryExpression exprCompare;
            string s=Console.ReadLine();
            if(s=="1")
            {
                exprCompare = Expression.GreaterThan(memExprePrice, constExpr5);
            }
            else
            {
                exprCompare = Expression.LessThan(memExprePrice, constExpr5);
            }

            BinaryExpression binaryExpression = Expression.GreaterThan(memExprePrice, constExpr5);
            Expression<Func<Book, bool>> exprRoot = Expression.Lambda<Func<Book, bool>>(binaryExpression, paramExprB);
            using (MyDbContext ctx = new MyDbContext())
            {
                ctx.Books.Where(exprRoot).ToArray();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ExpressionTreeToString 来简化动态构造表达式树的代码
            //可以用ExpressionTreeToString 的ToString("Factory methods","C#")输出类似于工厂方法的
            Expression<Func<Book, bool>> e1 = b => b.Price > 50;
            Expression<Func<Book, Book, int>> AddRes = (e1, e2) => e1.Price + e2.Price;
            textBox1.Text = AddRes.ToString("Factory methods", "C#");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var books= QueryBooks("price", 3);
            foreach(Book book in books)
            {
                Console.WriteLine(book);
            }
        }
        static IEnumerable<Book> QueryBooks(string propertyName, object value)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                Expression<Func<Book,bool>> e1= e=>e.Price== (int)value;
                return ctx.Books.Where(e1).ToList();
            }
        }
    }
}