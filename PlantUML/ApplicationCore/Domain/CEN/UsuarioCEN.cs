using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Domain.CEN;

public class UsuarioCEN
{
    private readonly IRepository<Usuario, long> _usuarioRepo;
    private readonly IUnitOfWork _uow;

    public UsuarioCEN(IRepository<Usuario, long> usuarioRepo, IUnitOfWork uow)
    {
        _usuarioRepo = usuarioRepo;
        _uow = uow;
    }

    // CRUD Básico

    public Usuario Registrar(string nombre, string email, string contrasenya)
    {
        // Verificar email único
        var existente = _usuarioRepo.GetAll().FirstOrDefault(u => u.Email == email);
        if (existente != null)
            throw new Exception("El email ya está registrado");

        var usuario = new Usuario
        {
            Nombre = nombre,
            Email = email,
            Contrasenya = contrasenya // Nota: En producción debería hashearse
        };

        var created = _usuarioRepo.New(usuario);
        _uow.SaveChanges();
        return created;
    }

    public void Modify(long id, string nombre = null, string email = null, string contrasenya = null, string telefono = null, string direccion = null)
    {
        var usuario = _usuarioRepo.GetById(id);
        if (usuario == null)
            throw new Exception($"Usuario con ID {id} no encontrado");

        if (!string.IsNullOrEmpty(nombre))
            usuario.Nombre = nombre;
        if (!string.IsNullOrEmpty(email))
            usuario.Email = email;
        if (!string.IsNullOrEmpty(contrasenya))
            usuario.Contrasenya = contrasenya;
        if (telefono != null)
            usuario.Telefono = telefono;
        if (direccion != null)
            usuario.Direccion = direccion;

        _usuarioRepo.Modify(usuario);
        _uow.SaveChanges();
    }

    public void Destroy(long id)
    {
        _usuarioRepo.Destroy(id);
        _uow.SaveChanges();
    }

    public Usuario ReadOID(long id)
    {
        return _usuarioRepo.GetById(id);
    }

    public IList<Usuario> ReadAll()
    {
        return _usuarioRepo.GetAll().ToList();
    }

    // Operación Login (Custom)

    public Usuario Login(string email, string contrasenya)
    {
        var usuario = _usuarioRepo.GetAll()
            .FirstOrDefault(u => u.Email == email && u.Contrasenya == contrasenya);

        if (usuario == null)
            throw new Exception("Credenciales inválidas");

        return usuario;
    }

    // Operaciones Custom

    public Usuario BuscarPorEmail(string email)
    {
        return _usuarioRepo.GetAll().FirstOrDefault(u => u.Email == email);
    }

    public bool CambiarContrasenya(long id, string contrasenyaAntigua, string contrasenyaNueva)
    {
        var usuario = _usuarioRepo.GetById(id);
        if (usuario == null)
            throw new Exception($"Usuario con ID {id} no encontrado");

        if (usuario.Contrasenya != contrasenyaAntigua)
            return false;

        usuario.Contrasenya = contrasenyaNueva;
        _usuarioRepo.Modify(usuario);
        _uow.SaveChanges();
        return true;
    }

    // ReadFilter

    public IList<Usuario> ReadFilter(
        string nombre = null,
        string email = null,
        string telefono = null)
    {
        var query = _usuarioRepo.GetAll();

        if (!string.IsNullOrEmpty(nombre))
            query = query.Where(u => u.Nombre.Contains(nombre));

        if (!string.IsNullOrEmpty(email))
            query = query.Where(u => u.Email.Contains(email));

        if (!string.IsNullOrEmpty(telefono))
            query = query.Where(u => u.Telefono != null && u.Telefono.Contains(telefono));

        return query.ToList();
    }
}
