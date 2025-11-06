
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
public partial class AyudaCP : GenericBasicCP
{
public AyudaCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public AyudaCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
