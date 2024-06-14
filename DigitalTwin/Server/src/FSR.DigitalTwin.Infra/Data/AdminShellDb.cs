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
    private readonly string _dbName = "AdminShellV3";

    public AdminShellDb(IAdminShellPackageEnvironmentService pkgEnvService, IMongoClient client) {
        _pkgEnvService = pkgEnvService;

        var dbContextOptions =
            new DbContextOptionsBuilder<AdminShellDbContext>().UseMongoDB(client, _dbName);
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
        IEnvironment environment = new AasCore.Aas3_0.Environment() {
            // TODO
        };
        _db.Add(environment);
        _db.SaveChanges();
        return environment;
    }

    public async Task<IEnvironment> PushToDbAsync()
    {
        IEnvironment environment = new AasCore.Aas3_0.Environment() {
            // TODO
        };
        _db.Add(environment);
        await _db.SaveChangesAsync();
        return environment;
    }
}