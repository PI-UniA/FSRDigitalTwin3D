using FSR.DigitalTwin.App.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace FSR.DigitalTwin.Infra.Data;

public class DigitalTwinDb : IDigitalTwinDb
{

    private readonly DigitalTwinDbContext _db;
    // private readonly IMapper _mapper;
    private readonly string _dbName = "AdminShellV3";

    public DigitalTwinDb(IMongoClient client) {
        var dbContextOptions =
            new DbContextOptionsBuilder<DigitalTwinDbContext>().UseMongoDB(client, _dbName);
        _db = new DigitalTwinDbContext(dbContextOptions.Options);
    }

    public void PullFromDb()
    {
        // TODO
    }

    public Task PullFromDbAsync()
    {
        // TODO
        return Task.CompletedTask;
    }

    public void PushToDb()
    {
        // TODO
    }

    public Task PushToDbAsync()
    {
        // TODO
        return Task.CompletedTask;
    }
}