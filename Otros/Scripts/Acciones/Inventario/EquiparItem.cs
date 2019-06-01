﻿using Bot_Dofus_1._29._1.Otros.Entidades.Personajes.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Dofus_1._29._1.Otros.Scripts.Acciones.Inventario
{
    class EquiparItem : AccionesScript
    {
        public int modelo_id { get; private set; }

        public EquiparItem(int _modelo_id)
        {
            modelo_id = _modelo_id;
        }

        internal override async Task<ResultadosAcciones> proceso(Cuenta cuenta)
        {
            ObjetosInventario objeto = cuenta.juego.personaje.inventario.get_Objeto_Modelo_Id(modelo_id);

            if (objeto != null && cuenta.juego.personaje.inventario.equipar_Objeto(objeto))
                await Task.Delay(500);

            return ResultadosAcciones.HECHO;
        }
    }
}