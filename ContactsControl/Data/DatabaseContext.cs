using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsControl.Data
{
    public class DatabaseContext : DbContext
    {
        /*
         * DbContext é herdado pelo pacote EntityFramework. A classe DatabaseContext herda o DbContext.
         * O construtor DatabaseContext recebe o DbContextOptions que é tipado como a classe DatabaseContext.
         * O options é injetado dentro do construtor padrão (DbContext).
         */
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        }

        /*
         * As tabelas criadas são vinculadas por meio da criação de um construtor.
         * DbSet especifíca a classe que representa a tabela no banco de dados (ContactModel).
         * A tabela recebe o nome Contacts e ela é get e set.
         */
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
