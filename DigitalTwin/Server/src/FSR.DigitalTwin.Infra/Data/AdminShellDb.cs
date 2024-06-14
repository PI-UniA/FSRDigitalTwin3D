using AasCore.Aas3_0;
using AasxServerStandardBib.Interfaces;
using FSR.DigitalTwin.App.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace FSR.DigitalTwin.Infra.Data;

public class AdminShellDb : IAdminShellDb
{
    private readonly IAdminShellPackageEnvironmentService _pkgEnvService;
    private readonly AdminShellDbContext _db;

    public AdminShellDb(IAdminShellPackageEnvironmentService pkgEnvService) {
        _pkgEnvService = pkgEnvService;

        var mongoClient = new MongoClient("<Your MongoDB Connection URI>");
        var dbContextOptions =
            new DbContextOptionsBuilder<AdminShellDbContext>().UseMongoDB(mongoClient, "<Database Name>");
        _db = new AdminShellDbContext(dbContextOptions.Options);
    }

    public IEnvironment LoadFromDb()
    {
        throw new NotImplementedException();
    }

    public Task<IEnvironment> LoadFromDbAsync()
    {
        throw new NotImplementedException();
    }

    public IEnvironment PushToDb()
    {
        throw new NotImplementedException();
    }

    public Task<IEnvironment> PushToDbAsync()
    {
        throw new NotImplementedException();
    }
}