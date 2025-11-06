
using System;
// Definición clase PagoEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class PagoEN
{
/**
 *	Atributo idPago
 */
private int idPago;



/**
 *	Atributo attribute
 */
private string attribute;



/**
 *	Atributo fechaPago
 */
private Nullable<DateTime> fechaPago;



/**
 *	Atributo monto
 */
private float monto;



/**
 *	Atributo pedido_0
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN pedido_0;






public virtual int IdPago {
        get { return idPago; } set { idPago = value;  }
}



public virtual string Attribute {
        get { return attribute; } set { attribute = value;  }
}



public virtual Nullable<DateTime> FechaPago {
        get { return fechaPago; } set { fechaPago = value;  }
}



public virtual float Monto {
        get { return monto; } set { monto = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN Pedido_0 {
        get { return pedido_0; } set { pedido_0 = value;  }
}





public PagoEN()
{
}



public PagoEN(int idPago, string attribute, Nullable<DateTime> fechaPago, float monto, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN pedido_0
              )
{
        this.init (IdPago, attribute, fechaPago, monto, pedido_0);
}


public PagoEN(PagoEN pago)
{
        this.init (pago.IdPago, pago.Attribute, pago.FechaPago, pago.Monto, pago.Pedido_0);
}

private void init (int idPago
                   , string attribute, Nullable<DateTime> fechaPago, float monto, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN pedido_0)
{
        this.IdPago = idPago;


        this.Attribute = attribute;

        this.FechaPago = fechaPago;

        this.Monto = monto;

        this.Pedido_0 = pedido_0;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PagoEN t = obj as PagoEN;
        if (t == null)
                return false;
        if (IdPago.Equals (t.IdPago))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdPago.GetHashCode ();
        return hash;
}
}
}
