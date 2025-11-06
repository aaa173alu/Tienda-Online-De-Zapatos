
using System;
using System.Text;
using System.Collections.Generic;
using TiendaZapatosGen.ApplicationCore.Exceptions;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.Utils;



namespace TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos
{
public partial class CarritoCP : GenericBasicCP
{
public CarritoCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public CarritoCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
