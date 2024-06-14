using AasCore.Aas3_0;
using AutoMapper;
using FSR.Aas.GRPC.Lib.V3;
using FSR.DigitalTwin.App.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace FSR.DigitalTwin.Infra.Data;

public class AdminShellDb : IAdminShellDb
{
    private readonly AdminShellDbContext _db;
    private readonly IMapper _mapper;
    private readonly string _dbName = "AdminShellV3";

    public AdminShellDb(IMongoClient client, IMapper mapper) {
        var dbContextOptions =
            new DbContextOptionsBuilder<AdminShellDbContext>().UseMongoDB(client, _dbName);
        _db = new AdminShellDbContext(dbContextOptions.Options);
        _mapper = mapper;
    }

    public IEnvironment LoadFromDb()
    {
        throw new NotImplementedException();
    }

    public Task<IEnvironment> LoadFromDbAsync()
    {
        throw new NotImplementedException();
    }

    public void PushToDb(IEnvironment environment)
    {
        _db.Add(_mapper.Map<EnvironmentDTO>(environment));
        _db.SaveChanges();
    }

    public async Task PushToDbAsync(IEnvironment environment)
    {
        _db.Add(_mapper.Map<EnvironmentDTO>(environment));
        await _db.SaveChangesAsync();
    }
}