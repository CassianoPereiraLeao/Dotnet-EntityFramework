using Api.Domain.DTOs.Admin;
using Api.Domain.Entities;
using Api.Infra.Data;
using Api.Infra.Interfaces;

public class AdminService : IAdminService
{
    private readonly AppDbContext _context;
    public AdminService(AppDbContext context)
    {
        _context = context;
    }

    public Admin? Login(AdminDTO adminDTO)
    {

        var context_admin = _context.Admins;
        var where = context_admin.Where(a => a.Email.Value == adminDTO.Email.Value);
        var admin = where.FirstOrDefault();

        if (admin != null && admin.Password.Verify(adminDTO.Password.Value))
        {
            return admin;
        }

        throw new Exception("Email ou senha inválidos");
    }
}