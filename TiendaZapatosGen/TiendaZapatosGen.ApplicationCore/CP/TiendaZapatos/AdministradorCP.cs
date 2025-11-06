
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
public partial class AdministradorCP : GenericBasicCP
{
public AdministradorCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public AdministradorCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
