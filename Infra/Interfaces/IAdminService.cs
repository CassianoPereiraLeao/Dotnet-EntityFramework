using Api.Domain.Entities;
using Api.Domain.DTOs.Admin;

namespace Api.Infra.Interfaces;

public interface IAdminService
{
    Admin? Login(AdminDTO adminDTO);

}
