using Microsoft.EntityFrameworkCore;
using PropproAssistant.Models;
using System;
using System.IO;

namespace PropproAssistant.Data;

public class AppDbContext : DbContext
{
    public DbSet<Bidding> Biddings { get; set; }

    public string DbPath { get; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var directoryPath = Path.Combine(path, "PropproAssistant");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        DbPath = Path.Combine(directoryPath, "bidding.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}
