using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using System.Linq;

namespace LivrariaMendes.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Livro.Any())
            {
                var felipe = context.Autor.Add(
                    new Autor { Nome = "Felipe", SobreNome = "Mendes" }).Entity;
                var eduardo = context.Autor.Add(
                    new Autor { Nome = "Eduardo", SobreNome = "Baltazar" }).Entity;
                var ze = context.Autor.Add(
                    new Autor { Nome = "José", SobreNome = "Souza" }).Entity;

                context.Livro.AddRange(

                    new Livro()
                    {
                        Titulo = "O Café da tia",
                        Autor = felipe,
                        Genero = "Ação",
                        Preco = 60.00M,
                        Ano = 2002
                    },
                    new Livro()
                    {
                        Titulo = "Chamando o Jovem",
                        Autor = ze,
                        Genero = "Teror",
                        Preco = 90.00M,
                        Ano = 1989
                    },
                    new Livro()
                    {
                        Titulo = "Gosto tanto de voce leãozinho",
                        Autor = eduardo,
                        Genero = "Comedia",
                        Preco = 100.00M,
                        Ano = 2000
                    }
                    );
                context.SaveChanges();

            }
        }
    }
}
