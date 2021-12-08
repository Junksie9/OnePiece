using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

namespace OnePiece.Helpers
{
    public static class Cifrado
    {
        public static string GetHash(string cadena)
        {
            var algoritmo = SHA512.Create();
            var arreglo = Encoding.UTF8.GetBytes(cadena + "ProyectoFinal");
            var hash = algoritmo.ComputeHash(arreglo).Select(x=>x.ToString("X2"));
            return string.Join("",hash);

        }
    }
}
