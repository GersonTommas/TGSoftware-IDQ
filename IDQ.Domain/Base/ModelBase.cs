using IDQ.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Base
{
    public class ModelBase : PropertyChangedBase
    {
        public int Id { get; set; }

        public virtual void updateModel() { }

        internal Decimal updatePrecioFinal(int sentCantidadFaltante, deudorModel sentDeudor, Decimal sentPrecio, productoModel sentProducto, Decimal sentPrecioPagado)
        {
            return sentCantidadFaltante > 0
                                        ? sentDeudor is not null
                                            ? sentDeudor.Nivel switch
                                            {
                                                1 => sentPrecio,
                                                2 => sentProducto is not null ? sentProducto.PrecioActual : sentPrecio,
                                                _ => sentProducto is not null ? sentProducto.PrecioActual * 1.05m : sentPrecio,
                                            }
                                            : sentPrecioPagado
                                        : 0;
        }
    }
}
