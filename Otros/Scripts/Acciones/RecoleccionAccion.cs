﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bot_Dofus_1._29._1.Otros.Scripts.Acciones
{
    internal class RecoleccionAccion : AccionesScript
    {
        public List<short> elementos { get; private set; }

        public RecoleccionAccion(List<short> _elementos) => elementos = _elementos;

        internal override Task<ResultadosAcciones> proceso(Account cuenta)
        {
            if (cuenta.game.manejador.recoleccion.get_Puede_Recolectar(elementos))
            {
                if (!cuenta.game.manejador.recoleccion.get_Recolectar(elementos))
                    return resultado_fallado;

                return resultado_procesado;
            }
            return resultado_hecho;
        }
    }
}
