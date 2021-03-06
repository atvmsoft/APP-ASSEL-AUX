﻿using Application.IO.Site.Interfaces;
using Application.IO.Site.Models.Source;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application.IO.Site.Controllers
{
    public class ControllerBase : Controller
    {
        protected Guid UserId { get; set; }

        protected ControllerBase(IUser user)
        {
            if (user.IsAuthenticated())
                UserId = user.GetUserId();
        }

        public static bool CpfDocumentValid(string cpf)
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

        public ReturnAction NegativeReturn
        {
            get
            {
                var retorno = new ReturnAction();
                foreach (var item in ModelState.Values.SelectMany(s => s.Errors).Select(s => s.ErrorMessage))
                {
                    retorno.Mensagens.Add(item);
                }

                return retorno;
            }
        }
    }
}
