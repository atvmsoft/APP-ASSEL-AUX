using Application.IO.Site.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Application.IO.Site.Models.Services.Abstractions
{
    public abstract class AbstractionContext
    {
        protected ApplicationDbContext db;
        public TextInfo tCase;

        public AbstractionContext()
        {
            var bild = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build().GetConnectionString("DefaultConnection"));

            db = new ApplicationDbContext(bild.Options);

            tCase = new CultureInfo("pt-BR", false).TextInfo;
        }

        protected bool CpfDocumentValid(string cpf)
        {
            cpf = new Regex(@"[^\d]").Replace(cpf, "");
            if (cpf.Length != 11) return false;

            bool nEqual = true;
            for (int i = 0; i < cpf.Length - 1; i++) { if (cpf[i] != cpf[i + 1]) { nEqual = false; break; } }
            if (nEqual) return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf, digito;
            int soma, resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11) return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2) resto = 0; else resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2) resto = 0; else resto = 11 - resto;
            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
