using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 表达式树
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("T_Books");
            builder.HasKey(it => it.BookID);
            builder.Property(it => it.Name).HasMaxLength(250).IsRequired();
            builder.Property(it => it.Price).IsRequired();
            builder.Property(it => it.AuthorName).HasMaxLength(50);
        }
    }
}
