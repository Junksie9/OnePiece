﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePiece.Models;

namespace OnePiece.Services
{
    public class ArcoServices
    {
        public List<Arco> Arcos { get; set; }
        public ArcoServices(onepieceContext context)
        {
            Arcos = context.Arcos.OrderBy(x => x.NombreArco).ToList();
        }
    }
}
