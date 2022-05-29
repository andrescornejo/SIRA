﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atestados.Utilitarios.Puntos
{
    public static class Puntos
    {
        public struct Total
        {
            public const int MAXIMO_PROFESIONAL_2 = 24;
            public const int MAXIMO_PROFESIONAL_3 = 72;
            public const int MAXIMO_PROFESIONAL_4 = 144;
        }
        public struct Libro
        {
            public const int MAXIMO_POR_LIBRO = 14;
            public const int MAXIMO_PROFESIONAL_2 = 24;
            public const int MAXIMO_PROFESIONAL_3 = 72;
            public const int MAXIMO_PROFESIONAL_4 = 144;
        }

        public struct Articulo
        {
            public const int UN_AUTOR = 4;
            public const int DOS_AUTORES = 6;
            public const int TRES_O_MAS_AUTORES = 4;
            public const int MAXIMO_PROFESIONAL_2 = 8;
            public const int MAXIMO_PROFESIONAL_3 = 20;
        }

    }

}
